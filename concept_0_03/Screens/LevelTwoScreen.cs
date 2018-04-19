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
    class LevelTwoScreen : IGameScreen
    {
        private bool m_exitGame;
        private readonly IGameScreenManager m_ScreenManager;

        private List<Component> m_components;
        private SoundEffect click;

        private SoundEffect bgSong;
        private SoundEffectInstance bgMusic;
        private bool isMusicStopped = false;
        private bool wasOptionsOpen = false;
        private bool wasFightOpen = false;
        private bool fightStarted = false;

        private int numOfEnemies = 3;

        private Player Player;
        private Sprite Obstacle;

        #region Enemy One Variables
        private Vector2 enemyOnePosition = new Vector2(300,400);
        private Rectangle enemyOneBounds = new Rectangle(150, 250, 200, 200);
        private int enemyMovementLeftRight;
        private int enemyMovementUpDown;
        bool enemyOneDefeated = false;

        bool getNewRandom = false;
        #endregion

        private Random random1 = new Random(Guid.NewGuid().GetHashCode());
        private Random random2 = new Random(Guid.NewGuid().GetHashCode());

        private Timer timer = new Timer();
        private Timer fightStartTimer = new Timer();

        public bool IsPaused { get; private set; }

        public LevelTwoScreen(IGameScreenManager gameScreenManager)
        {
            m_ScreenManager = gameScreenManager;

            #region Timer Stuff

            enemyMovementLeftRight = random1.Next(1, 21);
            enemyMovementUpDown = random2.Next(1, 21);

            timer.AutoReset = true;
            timer.Interval = 400;
            timer.Start();

            fightStartTimer.AutoReset = false;
            fightStartTimer.Interval = 800;
            fightStartTimer.Start();

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
            click = content.Load<SoundEffect>("SFX/Select_Click");

            bgSong = content.Load<SoundEffect>("Music/Pixelland");

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

            Player = new Player(Game1.activePlayerTexture);
            Obstacle = new Sprite(content.Load<Texture2D>("Enemies/wraith"))
            {
                Position = enemyOnePosition
            };

            m_components = new List<Component>()
            {
                Player,
                Obstacle,
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

            #region Player Intersecting Stuff
            /*
            if (Player.Rectangle.Intersects(Obstacle.Rectangle))
            {
                bgMusic.Pause();
                isMusicStopped = true;
                m_ScreenManager.PushScreen(new FightScreen(m_ScreenManager));
                enemyOneDefeated = true;

                Player.Position = new Vector2(Player.Position.X + 5, Player.Position.Y);
                Obstacle.Position = new Vector2(-30, -50);

                wasFightOpen = true;
            }
            */
            #endregion

            if (fightStarted == false)
            {
                fightStartTimer.Elapsed += new ElapsedEventHandler(StartFight);
            }

            if (fightStarted == true)
            {
                numOfEnemies -= 1;

                if (numOfEnemies < 0)
                {
                    m_ScreenManager.PopScreen();
                }
                else
                {
                    if (Game1.m_audioState == Game1.AudioState.PLAYING)
                        Game1.currentInstance.Stop();

                    m_ScreenManager.PushScreen(new FightScreen(m_ScreenManager, "み", "mi"));

                    fightStarted = false;
                }
                
            }
            

            if (isMusicStopped == true && wasOptionsOpen == true)
            {
                isMusicStopped = false;
                wasOptionsOpen = false;
            }
            
            #region Enemy One Movement -- CURRENTLY DISABLED
            /*
            

            if (Obstacle.Position.X > enemyOneBounds.Left && Obstacle.Position.Y > enemyOneBounds.Top &&
                Obstacle.Position.X < enemyOneBounds.Right && Obstacle.Position.Y < enemyOneBounds.Bottom)
            {
                timer.Elapsed += new ElapsedEventHandler(GetNewRandom);

                if (getNewRandom == true)
                {
                    enemyMovementLeftRight = random1.Next(1, 21);
                    enemyMovementUpDown = random2.Next(1, 21);
                    getNewRandom = false;

                }

                if (enemyMovementLeftRight < 6)
                {
                    if (Obstacle.Position.X < enemyOneBounds.Right - 2)
                    {
                        enemyOnePosition.X += 2;
                    }
                    else
                    {
                        enemyMovementLeftRight = random1.Next(1, 21);
                    }
                }
                else if (enemyMovementLeftRight >= 16)
                {
                    if (Obstacle.Position.X > enemyOneBounds.Left + 2)
                    {
                        enemyOnePosition.X -= 2;
                    }
                    else
                    {
                        enemyMovementLeftRight = random1.Next(1, 21);
                    }
                }

                if (enemyMovementUpDown >= 11 && enemyMovementUpDown < 16)
                {
                    if (Obstacle.Position.Y < enemyOneBounds.Bottom - 2)
                    {
                        enemyOnePosition.Y += 2;
                    }
                    else
                    {
                        enemyMovementUpDown = random2.Next(1, 21);
                    }
                }
                else if (enemyMovementUpDown >= 6 && enemyMovementUpDown < 11)
                {
                    if (Obstacle.Position.Y > enemyOneBounds.Top + 2)
                    {
                        enemyOnePosition.Y -= 2;
                    }
                    else
                    {
                        enemyMovementUpDown = random2.Next(1, 21);
                    }
                }

                Obstacle.Position = enemyOnePosition;
            }

            */
            #endregion
        }

        private void StartFight(object sender, ElapsedEventArgs e)
        {
            fightStarted = true;

            if (Game1.m_audioState == Game1.AudioState.PLAYING)
                Game1.currentInstance.Stop();

            isMusicStopped = true;

            wasFightOpen = true;
        }

        private void GetNewRandom(object sender, ElapsedEventArgs e)
        {
            getNewRandom = true;
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
                if (Game1.m_audioState == Game1.AudioState.PLAYING)
                    Game1.currentInstance.Stop();

                isMusicStopped = true;
                wasOptionsOpen = true;

                m_ScreenManager.PushScreen(new OptionsScreen(m_ScreenManager));
            }

            if (keyboard.IsKeyDown(Keys.Enter) && numOfEnemies >= 0)
            {
                fightStartTimer.Stop();
                fightStartTimer.Start();
            }
        }

        public void Dispose()
        {
            
        }
    }
}
