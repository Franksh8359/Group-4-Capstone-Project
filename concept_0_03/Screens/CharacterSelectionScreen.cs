using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace concept_0_03
{
    class CharacterSelectionScreen : IGameScreen
    {
        private bool m_exitGame;
        private readonly IGameScreenManager m_ScreenManager;
        private Command m_command;

        private List<Component> m_components;
        private SoundEffect click;

        private SoundEffect bgSong;

        #region Player UI variables

        public static Texture2D player01;
        public static Texture2D player02;
        public static Texture2D player03;

        public static Texture2D player01_Fight;
        public static Texture2D player02_Fight;
        public static Texture2D player03_Fight;

        private Sprite player01_Box;
        private Sprite player02_Box;
        private Sprite player03_Box;

        private Texture2D checkedBox;
        private Texture2D uncheckedBox;
        private string whichCharacter = "Player01";

        private Sprite player01_port;
        private Sprite player02_port;
        private Sprite player03_port;

        #endregion

        public bool IsPaused { get; private set; }

        public CharacterSelectionScreen(IGameScreenManager gameScreenManager)
        {
            m_ScreenManager = gameScreenManager;
            m_command = new Command(m_ScreenManager);
        }

        public void ChangeBetweenScreens()
        {
            if (m_exitGame)
            {
                m_ScreenManager.Exit();
            }
        }

        public void Init(ContentManager content)
        {
            click = content.Load<SoundEffect>("SFX/Select_Click");
            bgSong = content.Load<SoundEffect>("Music/Off to Osaka");

            #region Music

            switch (Game1.m_audioState)
            {
                case Game1.AudioState.OFF:
                    Game1.currentInstance = bgSong.CreateInstance();

                    Game1.currentInstance.IsLooped = true;
                    break;
                case Game1.AudioState.PAUSED:
                    Game1.currentInstance = bgSong.CreateInstance();

                    Game1.currentInstance.IsLooped = true;
                    break;
                case Game1.AudioState.PLAYING:
                    Game1.currentInstance = bgSong.CreateInstance();

                    Game1.currentInstance.IsLooped = true;
                    Game1.currentInstance.Play();
                    break;
            }

            #endregion

            uncheckedBox = content.Load<Texture2D>("Menu/Grey/grey_circle");
            checkedBox = content.Load<Texture2D>("Menu/Red/red_boxTick");

            var screenBackground = new Sprite(content.Load<Texture2D>("BGs/bgMountainsSmaller"))
            {
                Position = new Vector2(-100, -2)
            };

            Sprite backPanel = new Sprite(content.Load<Texture2D>("textboxes/textbox620x400"))
            {
                Position = new Vector2(90, 85)
            };

            #region Character Portraits

            player01_port = new Sprite(content.Load<Texture2D>("Player/player01_port"));
            player02_port = new Sprite(content.Load<Texture2D>("Player/player02_port"));
            player03_port = new Sprite(content.Load<Texture2D>("Player/player03_port"));

            player01_port.Position = new Vector2(125, 125);
            player02_port.Position = new Vector2(325, 125);
            player03_port.Position = new Vector2(525, 125);

            player01_Box = new Sprite(checkedBox);
            player02_Box = new Sprite(uncheckedBox);
            player03_Box = new Sprite(uncheckedBox);

            player01_Box.Position = new Vector2(182, 350);
            player02_Box.Position = new Vector2(382, 350);
            player03_Box.Position = new Vector2(582, 350);

            #endregion

            #region Character Textures

            player01 = content.Load<Texture2D>("Player/player01_Front");
            player02 = content.Load<Texture2D>("Player/player02_Front");
            player03 = content.Load<Texture2D>("Player/player03_Front");

            player01_Fight = content.Load<Texture2D>("Player/player01_Fight");
            player02_Fight = content.Load<Texture2D>("Player/player02_Fight");
            player03_Fight = content.Load<Texture2D>("Player/player03_Fight");

            whichCharacter = "Player01";
            Game1.activePlayerTexture = player01;
            Game1.activePlayer_FightTexture = player01_Fight;

            #endregion

            #region Character 01 Button
            var character01Button = new Button(content.Load<Texture2D>("Menu/Red/red_button03"), content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(105, 300),
                Text = "Character One",
            };

            character01Button.Click += Character01Button_Click;
            #endregion
            #region Character 02 Button
            var character02Button = new Button(content.Load<Texture2D>("Menu/Blue/blue_button03"), content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(305, 300),
                Text = "Character Two",
            };

            character02Button.Click += Character02Button_Click;
            #endregion
            #region Character 03 Button
            var character03Button = new Button(content.Load<Texture2D>("Menu/Red/red_button03"), content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(505, 300),
                Text = "Character Three",
            };

            character03Button.Click += Character03Button_Click;
            #endregion
            #region Start Button
            var startButton = new Button(content.Load<Texture2D>("Menu/Red/red_button03"), content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(305, 400),
                Text = "Start Game",
            };

            startButton.Click += StartButton_Click;
            #endregion

            m_components = new List<Component>()
            {
                screenBackground,
                backPanel,

                #region Portraits

                player01_port,
                player02_port,
                player03_port,

                #endregion

                #region Check Boxes

                player01_Box,
                player02_Box,
                player03_Box,

                #endregion

                #region Buttons

                character01Button,
                character02Button,
                character03Button,

                startButton,
                
                #endregion
            };
        }

        #region Button Method Region

        private void StartButton_Click(object sender, EventArgs e)
        {
            m_command.StartGame(m_ScreenManager);
        }

        private void Character01Button_Click(object sender, EventArgs e)
        {
            click.Play();

            whichCharacter = m_command.ChoosePlayerOne();
        }

        private void Character02Button_Click(object sender, EventArgs e)
        {
            click.Play();

            whichCharacter = m_command.ChoosePlayerTwo();
        }

        private void Character03Button_Click(object sender, EventArgs e)
        {
            click.Play();

            whichCharacter = m_command.ChoosePlayerThree();
        }

        #endregion

        public void Pause()
        {
            IsPaused = true;
        }

        public void Resume()
        {
            IsPaused = false;
        }

        public void Update(GameTime gameTime)
        {
            foreach (var component in m_components)
                component.Update(gameTime);

            if (whichCharacter == "Player01")
            {
                player01_Box.Texture = checkedBox;
                player02_Box.Texture = uncheckedBox;
                player03_Box.Texture = uncheckedBox;
            }
            else if (whichCharacter == "Player02")
            {
                player01_Box.Texture = uncheckedBox;
                player02_Box.Texture = checkedBox;
                player03_Box.Texture = uncheckedBox;
            }
            else if (whichCharacter == "Player03")
            {
                player01_Box.Texture = uncheckedBox;
                player02_Box.Texture = uncheckedBox;
                player03_Box.Texture = checkedBox;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in m_components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public void HandleInput(GameTime gameTime)
        {
            var keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Escape))
            {
                m_exitGame = true;
            }

            if (keyboard.IsKeyDown(Keys.Back))
            {
                m_command.OpenOptionsMenu(m_ScreenManager);
            }
        }

        public void Dispose()
        {
            
        }
    }
}
