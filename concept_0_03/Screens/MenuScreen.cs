using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace concept_0_03
{
    class MenuScreen : IGameScreen
    {
        private bool m_exitGame;
        private readonly IGameScreenManager m_ScreenManager;

        private Text m_titleText;
        private List<Component> m_components;
        private SoundEffect click;

        private SoundEffect bgSong;
        private SoundEffectInstance bgMusic;
        private bool isMusicStopped = false;

        public bool IsPaused { get; private set; }

        #region Touch Input Testing -- Nonfunctional

        TouchCollection touchCollection;

        #endregion

        public MenuScreen(IGameScreenManager gameScreenManager)
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
            #region Touch Input Testing -- Nonfunctional
            
            TouchPanel.EnabledGestures = GestureType.Tap | GestureType.DoubleTap;

            #endregion

            SpriteFont m_font = content.Load <SpriteFont>("Fonts/TitleFont");
            click = content.Load<SoundEffect>("SFX/Select_Click");

            bgSong = content.Load<SoundEffect>("Music/Bit Quest");
            bgMusic = bgSong.CreateInstance();

            bgMusic.IsLooped = true;
            bgMusic.Play();

            var screenBackground = new Sprite(content.Load<Texture2D>("BGs/bgMountainsSmaller"));
            screenBackground.Position = new Vector2(-100, -2);

            #region Title Stuff
            string titleText = "Japakeys";
            var x = (800 / 2) - (m_font.MeasureString(titleText).X / 2);
            var y = 100;
            Vector2 m_textPosition = new Vector2(x, y);
            Color m_color = Color.Black;

            m_titleText = new Text(titleText, m_font, m_textPosition, m_color);
            #endregion

            #region Button Variables

            var buttonTexture = content.Load<Texture2D>("Menu/Grey/grey_button04");
            var buttonFont = content.Load<SpriteFont>("Fonts/Font");

            #endregion

            #region New Game Button

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(305, 200),
                Text = "New Game",
            };

            newGameButton.Click += NewGameButton_Click;

            #endregion
            #region Load Button

            var loadGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(305, 250),
                Text = "Load Game",
            };

            loadGameButton.Click += LoadGameButton_Click;

            #endregion
            #region Options Button

            var optionsGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(305, 300),
                Text = "Options",
            };

            optionsGameButton.Click += OptionsGameButton_Click;

            #endregion
            #region Quit Button

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(305, 350),
                Text = "Quit",
            };

            quitGameButton.Click += QuitGameButton_Click;

            #endregion

            m_components = new List<Component>()
            {
                screenBackground,

                newGameButton,
                loadGameButton,
                optionsGameButton,
                quitGameButton,
            };
        }

        #region Button Methods
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            click.Play();
            bgMusic.Stop();
            m_ScreenManager.ChangeScreen(new CharacterSelectionScreen(m_ScreenManager));
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            click.Play();

            Console.WriteLine("Load Game");
        }

        private void OptionsGameButton_Click(object sender, EventArgs e)
        {
            bgMusic.Stop();
            isMusicStopped = true;

            m_ScreenManager.PushScreen(new OptionsScreen(m_ScreenManager));
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            m_exitGame = true;
        }
        #endregion

        #region Touch Methods

        private void NewGameButton_Pressed()
        {
            click.Play();
            bgMusic.Stop();
            m_ScreenManager.ChangeScreen(new CharacterSelectionScreen(m_ScreenManager));
        }

        private void LoadGameButton_Pressed()
        {
            click.Play();

            Console.WriteLine("Load Game");
        }

        private void OptionsButton_Pressed()
        {
            bgMusic.Stop();
            isMusicStopped = true;

            m_ScreenManager.PushScreen(new OptionsScreen(m_ScreenManager));
        }

        private void QuitButton_Pressed()
        {
            m_exitGame = true;
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

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in m_components)
                component.Draw(gameTime, spriteBatch);

            m_titleText.Draw(spriteBatch);

            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            foreach (var component in m_components)
                component.Update(gameTime);

            if (isMusicStopped == true)
            {
                isMusicStopped = false;
                bgMusic.Play();
            }
        }

        public void HandleInput(GameTime gameTime)
        {
            var keyboard = Keyboard.GetState();

            #region Touch Input Testing -- Nonfunctional

            touchCollection = TouchPanel.GetState();

            foreach (TouchLocation tl in touchCollection)
            {
                if (tl.State == TouchLocationState.Pressed &&
                tl.Position.X > 305 &&
                tl.Position.X < 495 &&
                tl.Position.Y > 200 &&
                tl.Position.Y < 249)
                {
                    NewGameButton_Pressed();
                }

                if (tl.State == TouchLocationState.Pressed &&
                tl.Position.X > 305 &&
                tl.Position.X < 495 &&
                tl.Position.Y > 250 &&
                tl.Position.Y < 299)
                {
                    LoadGameButton_Pressed();
                }

                if (tl.State == TouchLocationState.Pressed &&
                tl.Position.X > 305 &&
                tl.Position.X < 495 &&
                tl.Position.Y > 300 &&
                tl.Position.Y < 349)
                {
                    OptionsButton_Pressed();
                }

                if (tl.State == TouchLocationState.Pressed &&
                tl.Position.X > 305 &&
                tl.Position.X < 495 &&
                tl.Position.Y > 350 &&
                tl.Position.Y < 499)
                {
                    QuitButton_Pressed();
                }
            }

            #endregion

            if (keyboard.IsKeyDown(Keys.Escape))
            {
                m_exitGame = true;
            }
        }

        public void Dispose()
        {
            
        }
    }
}
