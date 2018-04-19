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
        private Command m_command;

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
        private Sprite Companion;

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

        public int levelsUnlocked = 1;

        #endregion

        public WorldMapScreen(IGameScreenManager gameScreenManager)
        {
            m_ScreenManager = gameScreenManager;
            m_command = new Command(m_ScreenManager);

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

            Sprite background = new Sprite(content.Load<Texture2D>("WorldMap/map"));
            Texture2D levelEntrance = content.Load<Texture2D>("WorldMap/levelEntrance");

            Player = new Player(Game1.activePlayerTexture)
            {
                playerCanMove = false,
                Position = new Vector2(-5, 240)
            };

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

            Companion = new Sprite(content.Load<Texture2D>("NPCs/carl"))
            {
                Position = new Vector2(LevelOne.Position.X + 50, LevelOne.Position.Y + 2)
            };

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
                Companion,
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

            #region Move Companion to Current Locked Level

            switch (levelsUnlocked)
            {
                case 0:
                    break;
                case 1:
                    Companion.Position = new Vector2(LevelOne.Position.X + 50, LevelOne.Position.Y + 2);
                    break;
                case 2:
                    Companion.Position = new Vector2(LevelTwo.Position.X - 50, LevelTwo.Position.Y + 2);
                    break;
                case 3:
                    Companion.Position = new Vector2(LevelThree.Position.X + 50, LevelThree.Position.Y + 2);
                    break;
                case 4:
                    Companion.Position = new Vector2(LevelFour.Position.X + 50, LevelFour.Position.Y + 2);
                    break;
                case 5:
                    Companion.Position = new Vector2(LevelFive.Position.X + 50, LevelFive.Position.Y + 2);
                    break;
                case 6:
                    Companion.Position = new Vector2(LevelSix.Position.X + 50, LevelSix.Position.Y + 2);
                    break;
                case 7:
                    Companion.Position = new Vector2(LevelSeven.Position.X + 50, LevelSeven.Position.Y + 2);
                    break;
                case 8:
                    Companion.Position = new Vector2(LevelEight.Position.X + 50, LevelEight.Position.Y + 2);
                    break;
                case 9:
                    Companion.Position = new Vector2(LevelNine.Position.X + 50, LevelNine.Position.Y + 2);
                    break;
                case 10:
                    Companion.Position = new Vector2(LevelTen.Position.X + 50, LevelTen.Position.Y + 2);
                    break;
                case 11:
                    Companion.Position = new Vector2(LevelEleven.Position.X + 50, LevelEleven.Position.Y + 2);
                    break;
                case 12:
                    break;

            }

            #endregion
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
                m_command.OpenOptionsMenu(m_ScreenManager);
            }

            #region Enter Level

            if (keyboard.IsKeyDown(Keys.Enter))
            {
                levelsUnlocked = m_command.EnterLevel(currentLevel, m_ScreenManager, levelsUnlocked);
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
                        MovePlayer(0);

                        break;
                    case 2:
                        Player.Position = LevelOne.Position;
                        MovePlayer(1);

                        break;
                    case 3:
                        Player.Position = LevelTwo.Position;
                        MovePlayer(2);

                        break;
                    case 4:
                        Player.Position = LevelThree.Position;
                        MovePlayer(3);

                        break;
                    case 5:
                        Player.Position = LevelFour.Position;
                        MovePlayer(4);

                        break;
                    case 6:
                        Player.Position = LevelFive.Position;
                        MovePlayer(5);

                        break;
                    case 7:
                        Player.Position = LevelSix.Position;
                        MovePlayer(6);

                        break;
                    case 8:
                        Player.Position = LevelSeven.Position;
                        MovePlayer(7);

                        break;
                    case 9:
                        Player.Position = LevelEight.Position;
                        MovePlayer(8);

                        break;
                    case 10:
                        Player.Position = LevelNine.Position;
                        MovePlayer(9);

                        break;
                    case 11:
                        Player.Position = LevelTen.Position;
                        MovePlayer(10);

                        break;
                    case 12:
                        Player.Position = LevelEleven.Position;
                        MovePlayer(11);

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
                        MovePlayer(1);

                        break;
                    case 1:
                        Player.Position = LevelTwo.Position;
                        MovePlayer(2);

                        break;
                    case 2:
                        Player.Position = LevelThree.Position;
                        MovePlayer(3);

                        break;
                    case 3:
                        Player.Position = LevelFour.Position;
                        MovePlayer(4);

                        break;
                    case 4:
                        Player.Position = LevelFive.Position;
                        MovePlayer(5);

                        break;
                    case 5:
                        Player.Position = LevelSix.Position;
                        MovePlayer(6);

                        break;
                    case 6:
                        Player.Position = LevelSeven.Position;
                        MovePlayer(7);

                        break;
                    case 7:
                        Player.Position = LevelEight.Position;
                        MovePlayer(8);

                        break;
                    case 8:
                        Player.Position = LevelNine.Position;
                        MovePlayer(9);

                        break;
                    case 9:
                        Player.Position = LevelTen.Position;
                        MovePlayer(10);

                        break;
                    case 10:
                        Player.Position = LevelEleven.Position;
                        MovePlayer(11);

                        break;
                    case 11:
                        // no level 12 shrugs????
                        break;

                }
            }

            #endregion
        }

        private void MovePlayer(int _newLevel)
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
