using System;
using System.Collections.Generic;
using System.Timers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace concept_0_03
{
    class WorldMapScreen : IGameScreen
    {
        private bool m_exitGame;
        private readonly IGameScreenManager m_ScreenManager;

        public bool IsPaused { get; private set; }

        private List<Component> m_components;

        #region Music & Sound Effect Variables
        private SoundEffect bgSong;
        private SoundEffectInstance bgMusic;
        private SoundEffect click;

        private bool isMusicStopped = false;
        #endregion

        private int currentLevel = 0;
        private Timer moveToNextLevel = new Timer();
        bool justMovedToNextLevel = false;

        #region Level Entrance and Player Variables

        private Player Player;

        #region Level Entrance Variables
        private LevelEntrance LevelOne;
        private LevelEntrance LevelTwo;
        private LevelEntrance LevelThree;
        private LevelEntrance LevelFour;
        private LevelEntrance LevelFive;
        private LevelEntrance LevelSix;
        private LevelEntrance LevelSeven;
        private LevelEntrance LevelEight;
        private LevelEntrance LevelNine;
        private LevelEntrance LevelTen;
        private LevelEntrance LevelEleven;
        #endregion

        #endregion

        public WorldMapScreen(IGameScreenManager gameScreenManager)
        {
            m_ScreenManager = gameScreenManager;

            #region Timer Stuff
            
            moveToNextLevel.Interval = 500;

            #endregion
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
            SpriteFont m_font = content.Load<SpriteFont>("Fonts/Font");
            click = content.Load<SoundEffect>("SFX/Select_Click");

            bgSong = content.Load<SoundEffect>("Music/Carpe Diem");
            bgMusic = bgSong.CreateInstance();

            bgMusic.IsLooped = true;
            bgMusic.Volume = 0.5f;
            bgMusic.Play();

            Sprite background = new Sprite(content.Load<Texture2D>("WorldMap/map"));
            Texture2D levelEntrance = content.Load<Texture2D>("WorldMap/levelEntrance");

            Player = new Player(Game1.activePlayerTexture);
            Player.playerCanMove = false;

            #region Level Entrance Rendering

            #region Level One

            LevelOne = new LevelEntrance(levelEntrance, new Vector2(73, 70), "1-1");

            #endregion
            #region Level Two

            LevelTwo = new LevelEntrance(levelEntrance, new Vector2(185, 174), "1-2");

            #endregion
            #region Level Three

            LevelThree = new LevelEntrance(levelEntrance, new Vector2(110, 365), "1-3");

            #endregion
            #region Level Four

            LevelFour = new LevelEntrance(levelEntrance, new Vector2(235, 505), "1-4");

            #endregion
            #region Level Five

            LevelFive = new LevelEntrance(levelEntrance, new Vector2(295, 363), "1-5");

            #endregion
            #region Level Six

            LevelSix = new LevelEntrance(levelEntrance, new Vector2(400, 272), "1-6");

            #endregion
            #region Level Seven

            LevelSeven = new LevelEntrance(levelEntrance, new Vector2(389, 125), "1-7");

            #endregion
            #region Level Eight

            LevelEight = new LevelEntrance(levelEntrance, new Vector2(515,50), "1-8");

            #endregion
            #region Level Nine

            LevelNine = new LevelEntrance(levelEntrance, new Vector2(618, 148), "1-9");

            #endregion
            #region Level Ten

            LevelTen = new LevelEntrance(levelEntrance, new Vector2(600, 311), "1-10");

            #endregion
            #region Level Eleven

            LevelEleven = new LevelEntrance(levelEntrance, new Vector2(683, 479), "1-11");

            #endregion

            #endregion

            Player.Position = new Vector2(-5, 240);

            m_components = new List<Component>()
            {
                background,

                #region Level Entrances

                LevelOne,
                LevelTwo,
                LevelThree,
                LevelFour,
                LevelFive,
                LevelSix,
                LevelSeven,
                LevelEight,
                LevelNine,
                LevelTen,
                LevelEleven,

                #endregion

                Player,
            };
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

            moveToNextLevel.Elapsed += MoveToNextLevel_Elapsed;
        }

        private void MoveToNextLevel_Elapsed(object sender, ElapsedEventArgs e)
        {
            justMovedToNextLevel = false;
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

            #region Enter Level

            if (keyboard.IsKeyDown(Keys.Enter))
            {
                switch (currentLevel)
                {
                    case 0:
                        break;
                    case 1:
                        bgMusic.Pause();
                        isMusicStopped = true;

                        m_ScreenManager.PushScreen(new LevelOneScreen(m_ScreenManager));
                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:

                        break;
                    case 8:

                        break;
                    case 9:

                        break;
                    case 10:

                        break;
                    case 11:

                        break;
                    case 12:

                        break;
                }
            }

            #endregion
            #region Move Player Left

            if (keyboard.IsKeyDown(Keys.Left) && justMovedToNextLevel == false)
            {
                switch (currentLevel)
                {
                    case 0:
                        break;
                    case 1:
                        Player.Position = new Vector2(-5, 240);
                        movePlayer(0);

                        break;
                    case 2:
                        Player.Position = LevelOne.Position;
                        movePlayer(1);

                        break;
                    case 3:
                        Player.Position = LevelTwo.Position;
                        movePlayer(2);

                        break;
                    case 4:
                        Player.Position = LevelThree.Position;
                        movePlayer(3);

                        break;
                    case 5:
                        Player.Position = LevelFour.Position;
                        movePlayer(4);

                        break;
                    case 6:
                        Player.Position = LevelFive.Position;
                        movePlayer(5);

                        break;
                    case 7:
                        Player.Position = LevelSix.Position;
                        movePlayer(6);

                        break;
                    case 8:
                        Player.Position = LevelSeven.Position;
                        movePlayer(7);

                        break;
                    case 9:
                        Player.Position = LevelEight.Position;
                        movePlayer(8);

                        break;
                    case 10:
                        Player.Position = LevelNine.Position;
                        movePlayer(9);

                        break;
                    case 11:
                        Player.Position = LevelTen.Position;
                        movePlayer(10);

                        break;
                    case 12:
                        Player.Position = LevelEleven.Position;
                        movePlayer(11);

                        break;

                }
            }

            #endregion
            #region Move Player Right

            if (keyboard.IsKeyDown(Keys.Right) && justMovedToNextLevel == false)
            {
                switch (currentLevel)
                {
                    case 0:
                        Player.Position = LevelOne.Position;
                        movePlayer(1);

                        break;
                    case 1:
                        Player.Position = LevelTwo.Position;
                        movePlayer(2);

                        break;
                    case 2:
                        Player.Position = LevelThree.Position;
                        movePlayer(3);

                        break;
                    case 3:
                        Player.Position = LevelFour.Position;
                        movePlayer(4);

                        break;
                    case 4:
                        Player.Position = LevelFive.Position;
                        movePlayer(5);

                        break;
                    case 5:
                        Player.Position = LevelSix.Position;
                        movePlayer(6);

                        break;
                    case 6:
                        Player.Position = LevelSeven.Position;
                        movePlayer(7);

                        break;
                    case 7:
                        Player.Position = LevelEight.Position;
                        movePlayer(8);

                        break;
                    case 8:
                        Player.Position = LevelNine.Position;
                        movePlayer(9);

                        break;
                    case 9:
                        Player.Position = LevelTen.Position;
                        movePlayer(10);

                        break;
                    case 10:
                        Player.Position = LevelEleven.Position;
                        movePlayer(11);

                        break;
                    case 11:
                        // no level 12 shrugs????
                        break;

                }
            }

            #endregion
        }

        private void movePlayer(int _newLevel)
        {
            currentLevel = _newLevel;

            justMovedToNextLevel = true;
            moveToNextLevel.Start();
        }

        public void Dispose()
        {
            
        }
    }
}
