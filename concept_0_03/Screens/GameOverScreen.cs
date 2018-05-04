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
    class GameOverScreen : IGameScreen
    {
        private bool m_exitGame;
        private readonly IGameScreenManager m_ScreenManager;

        private List<Component> m_components;
        private SoundEffect click;

        private SoundEffect bgSong;
        private SoundEffectInstance bgMusic;
        private bool isMusicStopped = false;
        private Text gameOver;

        public bool IsPaused { get; private set; }

        public GameOverScreen(IGameScreenManager gameScreenManager)
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
            #region Game Over Text Rendering
            Vector2 m_Position = new Vector2(350, 150);
            Color m_Color = Color.Black;

            gameOver = new Text("Game Over", content.Load<SpriteFont>("Fonts/TitleFont"), m_Position, m_Color);
            gameOver.CenterHorizontal(800, 150);
            #endregion

            // Background
            var background = new Sprite(content.Load<Texture2D>("BGs/bgGameOver"));

            #region Button Variables

            var buttonTexture = content.Load<Texture2D>("Menu/Grey/grey_button04");
            var buttonFont = content.Load<SpriteFont>("Fonts/Font");

            #endregion
            #region Menu Button

            var menuButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(305, 250),
                Text = "Return to Menu"
            };

            menuButton.Click += MenuButton_Click;

            #endregion
            #region Quit Button

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(305, 300),
                Text = "Quit",
            };

            quitGameButton.Click += QuitGameButton_Click;

            #endregion

            m_components = new List<Component>()
            {
                background,
                menuButton,
                quitGameButton,
            };
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            m_ScreenManager.ChangeScreen(new MenuScreen(m_ScreenManager));
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            m_exitGame = true;
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
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            gameOver.Draw(spriteBatch);

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
        }

        public void Dispose()
        {
            
        }
    }
}
