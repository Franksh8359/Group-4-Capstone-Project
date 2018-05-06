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

        private int currentWorld = 1;
        private Sprite background;

        private Texture2D mapOne;
        private Texture2D mapTwo;
        private Texture2D mapThree;

        #region Level Entrance and Player Variables

        private Player Player;
        private Sprite Companion;

        #region Level Entrance Variables
        #region World One
        private LevelEntrance LevelOne;    // 1-1
        private LevelEntrance LevelTwo;    // 1-2
        private LevelEntrance LevelThree;  // 1-3
        private LevelEntrance LevelFour;   // 1-4
        private LevelEntrance LevelFive;   // 1-5
        private LevelEntrance LevelSix;    // 1-6
        private LevelEntrance LevelSeven;  // 1-7
        private LevelEntrance LevelEight;  // 1-8
        private LevelEntrance LevelNine;   // 1-9
        private LevelEntrance LevelTen;    // 1-10
        private LevelEntrance LevelEleven; // 1-11
        #endregion
        #region World Two
        private LevelEntrance LevelTwelve;    // 2-1
        private LevelEntrance LevelThirteen;  // 2-2
        private LevelEntrance LevelFourteen;  // 2-3
        private LevelEntrance LevelFifteen;   // 2-4
        private LevelEntrance LevelSixteen;   // 2-5
        private LevelEntrance LevelSeventeen; // 2-6
        private LevelEntrance LevelEighteen;  // 2-7
        private LevelEntrance LevelNineteen;  // 2-8
        private LevelEntrance LevelTwenty;    // 2-9
        private LevelEntrance LevelTwentyOne; // 2-10
        private LevelEntrance LevelTwentyTwo; // 2-11
        #endregion
        #region World Three
        private LevelEntrance LevelTwentyThree;  // 3-1
        private LevelEntrance LevelTwentyFour;   // 3-2
        private LevelEntrance LevelTwentyFive;   // 3-3
        private LevelEntrance LevelTwentySix;    // 3-4
        private LevelEntrance LevelTwentySeven;  // 3-5
        private LevelEntrance LevelTwentyEight;  // 3-6
        private LevelEntrance LevelTwentyNine;   // 3-7
        private LevelEntrance LevelThirty;       // 3-8
        private LevelEntrance LevelThirtyOne;    // 3-9
        private LevelEntrance LevelThirtyTwo;    // 3-10
        private LevelEntrance LevelThirtyThree;  // 3-11
        private LevelEntrance LevelThirtyFour;   // 3-12
        #endregion
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

            #region Set Map Textures

            mapOne = content.Load<Texture2D>("WorldMap/map");
            mapTwo = content.Load<Texture2D>("WorldMap/map2");
            mapThree = content.Load<Texture2D>("WorldMap/map3");

            #endregion

            background = new Sprite(mapOne);
            Texture2D levelEntrance = content.Load<Texture2D>("WorldMap/levelEntrance");

            Player = new Player(Game1.activePlayerTexture)
            {
                playerCanMove = false,
                Position = new Vector2(-5, 240)
            };

            #region Level Entrance Rendering

            #region World One
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
            #region World Two
            #region Level One

            LevelTwelve = new LevelEntrance(levelEntrance, new Vector2(20, 85), "2-1")
            {
                Colour = Color.Transparent
            };

            #endregion
            #region Level Two

            LevelThirteen = new LevelEntrance(levelEntrance, new Vector2(77, 242), "2-2")
            {
                Colour = Color.Transparent
            };

            #endregion
            #region Level Three

            LevelFourteen = new LevelEntrance(levelEntrance, new Vector2(187, 124), "2-3")
            {
                Colour = Color.Transparent
            };

            #endregion
            #region Level Four

            LevelFifteen = new LevelEntrance(levelEntrance, new Vector2(186, 345), "2-4")
            {
                Colour = Color.Transparent
            };

            #endregion
            #region Level Five

            LevelSixteen = new LevelEntrance(levelEntrance, new Vector2(270, 505), "2-5")
            {
                Colour = Color.Transparent
            };

            #endregion
            #region Level Six

            LevelSeventeen = new LevelEntrance(levelEntrance, new Vector2(405, 433), "2-6")
            {
                Colour = Color.Transparent
            };

            #endregion
            #region Level Seven

            LevelEighteen = new LevelEntrance(levelEntrance, new Vector2(361, 221), "2-7")
            {
                Colour = Color.Transparent
            };

            #endregion
            #region Level Eight

            LevelNineteen = new LevelEntrance(levelEntrance, new Vector2(518, 245), "2-8")
            {
                Colour = Color.Transparent
            };

            #endregion
            #region Level Nine

            LevelTwenty = new LevelEntrance(levelEntrance, new Vector2(623, 392), "2-9")
            {
                Colour = Color.Transparent
            };

            #endregion
            #region Level Ten

            LevelTwentyOne = new LevelEntrance(levelEntrance, new Vector2(661, 200), "2-10")
            {
                Colour = Color.Transparent
            };

            #endregion
            #region Level Eleven

            LevelTwentyTwo = new LevelEntrance(levelEntrance, new Vector2(738, 10), "2-11")
            {
                Colour = Color.Transparent
            };

            #endregion
            #endregion
            #region World Three
            #region Level One

            LevelTwentyThree = new LevelEntrance(levelEntrance, new Vector2(25, 485), "3-1")
            {
                Colour = Color.Transparent
            };

            #endregion
            #region Level Two

            LevelTwentyFour = new LevelEntrance(levelEntrance, new Vector2(50, 325), "3-2")
            {
                Colour = Color.Transparent
            };

            #endregion
            #region Level Three

            LevelTwentyFive = new LevelEntrance(levelEntrance, new Vector2(30, 120), "3-3")
            {
                Colour = Color.Transparent
            };

            #endregion
            #region Level Four

            LevelTwentySix = new LevelEntrance(levelEntrance, new Vector2(190, 47), "3-4")
            {
                Colour = Color.Transparent
            };

            #endregion
            #region Level Five

            LevelTwentySeven = new LevelEntrance(levelEntrance, new Vector2(335, 135), "3-5")
            {
                Colour = Color.Transparent
            };

            #endregion
            #region Level Six

            LevelTwentyEight = new LevelEntrance(levelEntrance, new Vector2(287, 268), "3-6")
            {
                Colour = Color.Transparent
            };

            #endregion
            #region Level Seven

            LevelTwentyNine = new LevelEntrance(levelEntrance, new Vector2(217, 384), "3-7")
            {
                Colour = Color.Transparent
            };

            #endregion
            #region Level Eight

            LevelThirty = new LevelEntrance(levelEntrance, new Vector2(375, 505), "3-8")
            {
                Colour = Color.Transparent
            };

            #endregion
            #region Level Nine

            LevelThirtyOne = new LevelEntrance(levelEntrance, new Vector2(510, 420), "3-9")
            {
                Colour = Color.Transparent
            };

            #endregion
            #region Level Ten

            LevelThirtyTwo = new LevelEntrance(levelEntrance, new Vector2(505, 234), "3-10")
            {
                Colour = Color.Transparent
            };

            #endregion
            #region Level Eleven

            LevelThirtyThree = new LevelEntrance(levelEntrance, new Vector2(610, 90), "3-11")
            {
                Colour = Color.Transparent
            };

            #endregion
            #region Level Twelve

            LevelThirtyFour = new LevelEntrance(levelEntrance, new Vector2(750, 250), "3-12")
            {
                Colour = Color.Transparent
            };
            #endregion
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
                LevelOne, LevelTwo, LevelThree, LevelFour, LevelFive,
                LevelSix, LevelSeven, LevelEight, LevelNine, LevelTen,
                LevelEleven, LevelTwelve, LevelThirteen, LevelFourteen,
                LevelFifteen, LevelSixteen, LevelSeventeen, LevelEighteen,
                LevelNineteen, LevelTwenty, LevelTwentyOne,
                LevelTwentyTwo, LevelTwentyThree, LevelTwentyFour,
                LevelTwentyFive, LevelTwentySix, LevelTwentySeven,
                LevelTwentyEight, LevelTwentyNine, LevelThirty,
                LevelThirtyOne, LevelThirtyTwo, LevelThirtyThree,
                LevelThirtyFour,
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
                
                #region World One
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
                #endregion
                #region World Two
                case 12:
                    Companion.Position = new Vector2(LevelTwelve.Position.X + 50, LevelTwelve.Position.Y + 2);
                    break;
                case 13:
                    Companion.Position = new Vector2(LevelThirteen.Position.X - 50, LevelThirteen.Position.Y + 2);
                    break;
                case 14:
                    Companion.Position = new Vector2(LevelFourteen.Position.X, LevelFourteen.Position.Y + 52);
                    break;
                case 15:
                    Companion.Position = new Vector2(LevelFifteen.Position.X - 5, LevelFifteen.Position.Y - 52);
                    break;
                case 16:
                    Companion.Position = new Vector2(LevelSixteen.Position.X, LevelSixteen.Position.Y - 50);
                    break;
                case 17:
                    Companion.Position = new Vector2(LevelSeventeen.Position.X - 50, LevelSeventeen.Position.Y - 50);
                    break;
                case 18:
                    Companion.Position = new Vector2(LevelEighteen.Position.X - 50, LevelEighteen.Position.Y + 2);
                    break;
                case 19:
                    Companion.Position = new Vector2(LevelNineteen.Position.X, LevelNineteen.Position.Y + 52);
                    break;
                case 20:
                    Companion.Position = new Vector2(LevelTwenty.Position.X, LevelTwenty.Position.Y - 52);
                    break;
                case 21:
                    Companion.Position = new Vector2(LevelTwentyOne.Position.X - 50, LevelTwentyOne.Position.Y + 2);
                    break;
                case 22:
                    Companion.Position = new Vector2(LevelTwentyTwo.Position.X, LevelTwentyTwo.Position.Y + 50);
                    break;
                #endregion
                #region World Three
                case 23:
                    Companion.Position = new Vector2(LevelTwentyThree.Position.X - 2, LevelTwentyThree.Position.Y + 50);
                    break;
                case 24:
                    Companion.Position = new Vector2(LevelTwentyFour.Position.X + 50, LevelTwentyFour.Position.Y + 2);
                    break;
                case 25:
                    Companion.Position = new Vector2(LevelTwentyFive.Position.X + 50, LevelTwentyFive.Position.Y + 2);
                    break;
                case 26:
                    Companion.Position = new Vector2(LevelTwentySix.Position.X + 50, LevelTwentySix.Position.Y + 2);
                    break;
                case 27:
                    Companion.Position = new Vector2(LevelTwentySeven.Position.X + 50, LevelTwentySeven.Position.Y + 2);
                    break;
                case 28:
                    Companion.Position = new Vector2(LevelTwentyEight.Position.X + 50, LevelTwentyEight.Position.Y + 2);
                    break;
                case 29:
                    Companion.Position = new Vector2(LevelTwentyNine.Position.X - 50, LevelTwentyNine.Position.Y + 2);
                    break;
                case 30:
                    Companion.Position = new Vector2(LevelThirty.Position.X + 2, LevelThirty.Position.Y - 52);
                    break;
                case 31:
                    Companion.Position = new Vector2(LevelThirtyOne.Position.X - 50, LevelThirtyOne.Position.Y + 2);
                    break;
                case 32:
                    Companion.Position = new Vector2(LevelThirtyTwo.Position.X - 50, LevelThirtyTwo.Position.Y + 2);
                    break;
                case 33:
                    Companion.Position = new Vector2(LevelThirtyThree.Position.X, LevelThirtyThree.Position.Y + 52);
                    break;
                case 34:
                    Companion.Position = new Vector2(LevelThirtyFour.Position.X - 50, LevelThirtyFour.Position.Y - 2);
                    break;

                #endregion

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
                    #region World One
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
                        ChangeWorld(1);
                        Player.Position = LevelEleven.Position;
                        MovePlayer(11);

                        break;
                    #endregion
                    #region World Two
                    case 13:
                        Player.Position = LevelTwelve.Position;
                        MovePlayer(12);

                        break;
                    case 14:
                        Player.Position = LevelThirteen.Position;
                        MovePlayer(13);

                        break;
                    case 15:
                        Player.Position = LevelFourteen.Position;
                        MovePlayer(14);

                        break;
                    case 16:
                        Player.Position = LevelFifteen.Position;
                        MovePlayer(15);

                        break;
                    case 17:
                        Player.Position = LevelSixteen.Position;
                        MovePlayer(16);

                        break;
                    case 18:
                        Player.Position = LevelSeventeen.Position;
                        MovePlayer(17);

                        break;
                    case 19:
                        Player.Position = LevelEighteen.Position;
                        MovePlayer(18);

                        break;
                    case 20:
                        Player.Position = LevelNineteen.Position;
                        MovePlayer(19);

                        break;
                    case 21:
                        Player.Position = LevelTwenty.Position;
                        MovePlayer(20);

                        break;
                    case 22:
                        Player.Position = LevelTwentyOne.Position;
                        MovePlayer(21);

                        break;
                    case 23:
                        ChangeWorld(2);

                        Player.Position = LevelTwentyTwo.Position;
                        MovePlayer(22);
                        break;
                    #endregion
                    #region World Three
                    case 24:
                        Player.Position = LevelTwentyThree.Position;
                        MovePlayer(23);

                        break;
                    case 25:
                        Player.Position = LevelTwentyFour.Position;
                        MovePlayer(24);

                        break;
                    case 26:
                        Player.Position = LevelTwentyFive.Position;
                        MovePlayer(25);

                        break;
                    case 27:
                        Player.Position = LevelTwentySix.Position;
                        MovePlayer(26);

                        break;
                    case 28:
                        Player.Position = LevelTwentySeven.Position;
                        MovePlayer(27);

                        break;
                    case 29:
                        Player.Position = LevelTwentyEight.Position;
                        MovePlayer(28);

                        break;
                    case 30:
                        Player.Position = LevelTwentyNine.Position;
                        MovePlayer(29);

                        break;
                    case 31:
                        Player.Position = LevelThirty.Position;
                        MovePlayer(30);

                        break;
                    case 32:
                        Player.Position = LevelThirtyOne.Position;
                        MovePlayer(31);

                        break;
                    case 33:
                        Player.Position = LevelThirtyTwo.Position;
                        MovePlayer(32);

                        break;
                    case 34:
                        Player.Position = LevelThirtyThree.Position;
                        MovePlayer(33);

                        break;
                    case 35:
                        Player.Position = LevelThirtyFour.Position;
                        MovePlayer(34);

                        break;
                    #endregion
                }
            }

            #endregion
            #region Move Player Right

            if (keyboard.IsKeyDown(Keys.Right) && justMovedToNextLevel == false)
            {
                switch (currentLevel)
                {
                    #region World One
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
                    #endregion
                    #region World Two
                    case 11:
                        Player.Position = LevelTwelve.Position; // 2-1
                        MovePlayer(12);
                        ChangeWorld(2);

                        break;
                    case 12:
                        Player.Position = LevelThirteen.Position; // 2-2
                        MovePlayer(13);

                        break;
                    case 13:
                        Player.Position = LevelFourteen.Position; // 2-3
                        MovePlayer(14);

                        break;
                    case 14:
                        Player.Position = LevelFifteen.Position; // 2-4
                        MovePlayer(15);

                        break;
                    case 15:
                        Player.Position = LevelSixteen.Position; // 2-5
                        MovePlayer(16);

                        break;
                    case 16:
                        Player.Position = LevelSeventeen.Position; // 2-6
                        MovePlayer(17);

                        break;
                    case 17:
                        Player.Position = LevelEighteen.Position; // 2-7
                        MovePlayer(18);

                        break;
                    case 18:
                        Player.Position = LevelNineteen.Position; // 2-8
                        MovePlayer(19);

                        break;
                    case 19:
                        Player.Position = LevelTwenty.Position; // 2-9
                        MovePlayer(20);

                        break;
                    case 20:
                        Player.Position = LevelTwentyOne.Position; // 2-10
                        MovePlayer(21);

                        break;
                    case 21:
                        Player.Position = LevelTwentyTwo.Position; // 2-11
                        MovePlayer(22);

                        break;

                    #endregion
                    #region World Three

                    case 22:
                        Player.Position = LevelTwentyThree.Position; // 3-1
                        MovePlayer(23);

                        ChangeWorld(3);
                        break;
                    case 23:
                        Player.Position = LevelTwentyFour.Position; // 3-2
                        MovePlayer(24);

                        break;
                    case 24:
                        Player.Position = LevelTwentyFive.Position; // 3-3
                        MovePlayer(25);

                        break;
                    case 25:
                        Player.Position = LevelTwentySix.Position; // 3-4
                        MovePlayer(26);

                        break;
                    case 26:
                        Player.Position = LevelTwentySeven.Position; // 3-5
                        MovePlayer(27);

                        break;
                    case 27:
                        Player.Position = LevelTwentyEight.Position; // 3-6
                        MovePlayer(28);

                        break;
                    case 28:
                        Player.Position = LevelTwentyNine.Position; // 3-7
                        MovePlayer(29);

                        break;
                    case 29:
                        Player.Position = LevelThirty.Position; // 3-8
                        MovePlayer(30);

                        break;
                    case 30:
                        Player.Position = LevelThirtyOne.Position; // 3-9
                        MovePlayer(31);

                        break;
                    case 31:
                        Player.Position = LevelThirtyTwo.Position; // 3-10
                        MovePlayer(32);

                        break;
                    case 32:
                        Player.Position = LevelThirtyThree.Position; // 3-11
                        MovePlayer(33);

                        break;
                    case 33:
                        Player.Position = LevelThirtyFour.Position; // 3-12
                        MovePlayer(34);

                        break;
                    
                    #endregion
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

        private void ChangeWorld(int _newWorld)
        {
            switch (_newWorld)
            {
                case 1:
                    #region Hide World Two Entrances
                    LevelTwelve.Colour = Color.Transparent;
                    LevelThirteen.Colour = Color.Transparent;
                    LevelFourteen.Colour = Color.Transparent;
                    LevelFifteen.Colour = Color.Transparent;
                    LevelSixteen.Colour = Color.Transparent;
                    LevelSeventeen.Colour = Color.Transparent;
                    LevelEighteen.Colour = Color.Transparent;
                    LevelNineteen.Colour = Color.Transparent;
                    LevelTwenty.Colour = Color.Transparent;
                    LevelTwentyOne.Colour = Color.Transparent;
                    LevelTwentyTwo.Colour = Color.Transparent;
                    #endregion

                    currentWorld = 1;
                    background.Texture = mapOne;

                    #region Making World One Entrances Visible

                    LevelOne.Colour = new Color(255, 255, 255, 255);
                    LevelTwo.Colour = new Color(255, 255, 255, 255);
                    LevelThree.Colour = new Color(255, 255, 255, 255);
                    LevelFour.Colour = new Color(255, 255, 255, 255);
                    LevelFive.Colour = new Color(255, 255, 255, 255);
                    LevelSix.Colour = new Color(255, 255, 255, 255);
                    LevelSeven.Colour = new Color(255, 255, 255, 255);
                    LevelEight.Colour = new Color(255, 255, 255, 255);
                    LevelNine.Colour = new Color(255, 255, 255, 255);
                    LevelTen.Colour = new Color(255, 255, 255, 255);
                    LevelEleven.Colour = new Color(255, 255, 255, 255);

                    #endregion

                    #region Hiding Companion
                    if (levelsUnlocked > 11)
                    {
                        Companion.Colour = Color.Transparent;
                    }
                    else
                    {
                        Companion.Colour = new Color(255, 255, 255, 255);
                    }
                    #endregion

                    break;
                case 2:
                    if (currentWorld == 1)
                    {
                        #region Hiding World One Entrances
                        LevelOne.Colour = Color.Transparent;
                        LevelTwo.Colour = Color.Transparent;
                        LevelThree.Colour = Color.Transparent;
                        LevelFour.Colour = Color.Transparent;
                        LevelFive.Colour = Color.Transparent;
                        LevelSix.Colour = Color.Transparent;
                        LevelSeven.Colour = Color.Transparent;
                        LevelEight.Colour = Color.Transparent;
                        LevelNine.Colour = Color.Transparent;
                        LevelTen.Colour = Color.Transparent;
                        LevelEleven.Colour = Color.Transparent;
                        #endregion
                    }
                    else if(currentWorld == 3)
                    {
                        #region Hiding World Three Entrances
                        LevelTwentyThree.Colour = Color.Transparent;
                        LevelTwentyFour.Colour = Color.Transparent;
                        LevelTwentyFive.Colour = Color.Transparent;
                        LevelTwentySix.Colour = Color.Transparent;
                        LevelTwentySeven.Colour = Color.Transparent;
                        LevelTwentyEight.Colour = Color.Transparent;
                        LevelTwentyNine.Colour = Color.Transparent;
                        LevelThirty.Colour = Color.Transparent;
                        LevelThirtyOne.Colour = Color.Transparent;
                        LevelThirtyTwo.Colour = Color.Transparent;
                        LevelThirtyThree.Colour = Color.Transparent;
                        LevelThirtyFour.Colour = Color.Transparent;
                        #endregion
                    }

                    #region Hiding Companion
                    if (levelsUnlocked < 12 || levelsUnlocked > 22)
                    {
                        Companion.Colour = Color.Transparent;
                    }
                    else
                    {
                        Companion.Colour = new Color(255, 255, 255, 255);
                    }
                    #endregion

                    #region Making World Two Entrances Visible
                    LevelTwelve.Colour = new Color(255, 255, 255, 255);
                    LevelThirteen.Colour = new Color(255, 255, 255, 255);
                    LevelFourteen.Colour = new Color(255, 255, 255, 255);
                    LevelFifteen.Colour = new Color(255, 255, 255, 255);
                    LevelSixteen.Colour = new Color(255, 255, 255, 255);
                    LevelSeventeen.Colour = new Color(255, 255, 255, 255);
                    LevelEighteen.Colour = new Color(255, 255, 255, 255);
                    LevelNineteen.Colour = new Color(255, 255, 255, 255);
                    LevelTwenty.Colour = new Color(255, 255, 255, 255);
                    LevelTwentyOne.Colour = new Color(255, 255, 255, 255);
                    LevelTwentyTwo.Colour = new Color(255, 255, 255, 255);
                    #endregion

                    currentWorld = 2;
                    background.Texture = mapTwo;

                    break;
                case 3:
                    #region Hide World Two Entrances
                    LevelTwelve.Colour = Color.Transparent;
                    LevelThirteen.Colour = Color.Transparent;
                    LevelFourteen.Colour = Color.Transparent;
                    LevelFifteen.Colour = Color.Transparent;
                    LevelSixteen.Colour = Color.Transparent;
                    LevelSeventeen.Colour = Color.Transparent;
                    LevelEighteen.Colour = Color.Transparent;
                    LevelNineteen.Colour = Color.Transparent;
                    LevelTwenty.Colour = Color.Transparent;
                    LevelTwentyOne.Colour = Color.Transparent;
                    LevelTwentyTwo.Colour = Color.Transparent;
                    #endregion

                    #region Hiding Companion
                    if (levelsUnlocked < 23)
                    {
                        Companion.Colour = Color.Transparent;
                    }
                    else
                    {
                        Companion.Colour = new Color(255, 255, 255, 255);
                    }
                    #endregion

                    currentWorld = 3;
                    background.Texture = mapThree;

                    #region Making World Three Entrances Visible
                    LevelTwentyThree.Colour = new Color(255, 255, 255, 255);
                    LevelTwentyFour.Colour = new Color(255, 255, 255, 255);
                    LevelTwentyFive.Colour = new Color(255, 255, 255, 255);
                    LevelTwentySix.Colour = new Color(255, 255, 255, 255);
                    LevelTwentySeven.Colour = new Color(255, 255, 255, 255);
                    LevelTwentyEight.Colour = new Color(255, 255, 255, 255);
                    LevelTwentyNine.Colour = new Color(255, 255, 255, 255);
                    LevelThirty.Colour = new Color(255, 255, 255, 255);
                    LevelThirtyOne.Colour = new Color(255, 255, 255, 255);
                    LevelThirtyTwo.Colour = new Color(255, 255, 255, 255);
                    LevelThirtyThree.Colour = new Color(255, 255, 255, 255);
                    LevelThirtyFour.Colour = new Color(255, 255, 255, 255);
                    #endregion

                    break;
            }
        }

        public void Dispose()
        {
            
        }
    }
}
