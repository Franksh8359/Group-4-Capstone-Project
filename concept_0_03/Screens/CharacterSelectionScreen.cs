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

        private List<Component> m_components;
        private SoundEffect click;

        private SoundEffect bgSong;
        private SoundEffectInstance bgMusic;
        private bool isMusicStopped = false;

        #region Player UI variables

        public static Texture2D player01;
        public static Texture2D player02;
        public static Texture2D player03;

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
            bgMusic = bgSong.CreateInstance();

            uncheckedBox = content.Load<Texture2D>("Menu/Grey/grey_circle");
            checkedBox = content.Load<Texture2D>("Menu/Red/red_boxTick");

            bgMusic.IsLooped = true;
            bgMusic.Play();

            var screenBackground = new Sprite(content.Load<Texture2D>("BGs/bgMountainsSmaller"));
            screenBackground.Position = new Vector2(-100, -2);

            Sprite backPanel = new Sprite(content.Load<Texture2D>("textboxes/textbox620x400"));

            backPanel.Position = new Vector2(90, 85);

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

            whichCharacter = "Player01";
            Game1.activePlayerTexture = player01;

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

        private void StartButton_Click(object sender, EventArgs e)
        {
            bgMusic.Stop();
            click.Play();

            m_ScreenManager.ChangeScreen(new WorldMapScreen(m_ScreenManager));
        }

        private void Character01Button_Click(object sender, EventArgs e)
        {
            click.Play();

            Game1.activePlayerTexture = player01;
            whichCharacter = "Player01";
        }

        private void Character02Button_Click(object sender, EventArgs e)
        {
            click.Play();

            Game1.activePlayerTexture = player02;
            whichCharacter = "Player02";
        }

        private void Character03Button_Click(object sender, EventArgs e)
        {
            click.Play();

            Game1.activePlayerTexture = player03;
            whichCharacter = "Player03";
        }

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
                player01_Box._texture = checkedBox;
                player02_Box._texture = uncheckedBox;
                player03_Box._texture = uncheckedBox;
            }
            else if (whichCharacter == "Player02")
            {
                player01_Box._texture = uncheckedBox;
                player02_Box._texture = checkedBox;
                player03_Box._texture = uncheckedBox;
            }
            else if (whichCharacter == "Player03")
            {
                player01_Box._texture = uncheckedBox;
                player02_Box._texture = uncheckedBox;
                player03_Box._texture = checkedBox;
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
                bgMusic.Pause();
                isMusicStopped = true;

                m_ScreenManager.PushScreen(new OptionsScreen(m_ScreenManager));
            }
        }

        public void Dispose()
        {
            
        }
    }
}
