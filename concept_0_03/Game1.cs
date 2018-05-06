using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace concept_0_03
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        #region Traveling Textures
        // KEEPS CURRENT PLAYER
        public static Texture2D activePlayerTexture;
        public static Texture2D activePlayer_FightTexture;

        // KEEPS CURRENT COMPANION
        public static Texture2D activeCompanionTexture;
        public static Texture2D activeCompanion_FightTexture;

        // KEEPS CURRENT ENEMY
        public static Texture2D activeEnemyTexture;
        #endregion

        public static SoundEffect currentSong;
        public static SoundEffectInstance currentInstance;

        #region Song Variables
        
        // might be needed

        #endregion

        private IGameScreenManager m_screenManager;

        public enum GameState
        {
            STARTUP,
            RUNNING,
            PAUSED,
            LOADING,
            IN_FIGHT
        }

        public enum AudioState
        {
            PLAYING,
            PAUSED,
            OFF
        }

        public static GameState m_gameState;
        public static AudioState m_audioState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferHeight = 600,
                PreferredBackBufferWidth = 800,
            };
            IsMouseVisible = true;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            m_gameState = GameState.STARTUP;
            m_audioState = AudioState.OFF;

        }
        
        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            activePlayerTexture = Content.Load<Texture2D>("Player/player01_Front");

            activeCompanionTexture = Content.Load<Texture2D>("NPCs/carl");
            activeCompanion_FightTexture = Content.Load<Texture2D>("NPCs/Carl_Fight");

            // TODO: use this.Content to load your game content here
            m_screenManager = new GameScreenManager(spriteBatch, Content);
            m_screenManager.OnGameExit += Exit;

            m_screenManager.ChangeScreen(new MenuScreen(m_screenManager));

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            if(m_screenManager != null)
            {
                m_screenManager.Dispose();
            }
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            m_screenManager.ChangeBetweenScreens();

            m_screenManager.HandleInput(gameTime);
            m_screenManager.Update(gameTime);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            m_screenManager.Draw(gameTime);

            Window.Title = "Japakeys";

            base.Draw(gameTime);
        }
    }
}
