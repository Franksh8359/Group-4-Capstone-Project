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
    class FightScreen : IGameScreen
    {
        private bool m_exitGame;
        private readonly IGameScreenManager m_ScreenManager;

        private bool isMusicOn;
        private bool wasOptionsOpened;

        private List<Component> m_components;
        private SoundEffect click;

        public bool IsPaused { get; private set; }

        private SoundEffect bgSong;
        private SoundEffectInstance bgMusic;
        private KeyboardState oldState;

        private Timer canAnswerTimer = new Timer();
        private bool canAnswer = false;

        private Stage.StageData stageData = new Stage.StageData(); //CREATE A NEW STAGEDATA LIST
        private string stageID;
        private Question lastQuest = new Question();
        float cdTimer = 0;

        #region Question Variables

        private string optionOne;
        private string optionTwo;
        private string optionThree;
        private string optionFour;
        private string currentWord;
        private string questionWord;


        #endregion

        #region UI Variables
        
        private Text m_TimerText;

        //HEALTH BARS
        private Rectangle playerHPBar;
        private Rectangle enemyHPBar;
        private Rectangle pHPBarBG;
        private Rectangle eHPBarBG;
        private Texture2D HPTexture;

        private int hpBarYPos = 560;
        private int pHPBarXPos = 10;
        private int eHPBarXPos = 540;
        private int hpBarLength = 250;
        private int hpBarWidth = 30;
        private int enemyHealth = 0;
        private int playerHealth = 50;
        private int enemyMaxHealth = 0;
        private int playerMaxHealth = 50;

        //SPRITES
        private Sprite Player;
        private Sprite Companion;

        //QUESTION
        private Text m_questionText;
        private Button answerButton1;
        private Button answerButton2;
        private Button answerButton3;
        private Button answerButton4;
        #endregion

        public FightScreen(IGameScreenManager gameScreenManager, string stage_ID)
        {
            m_ScreenManager = gameScreenManager;

            //SET STAGE ID
            stageID = stage_ID;
            //SET THE STAGE DATA
            stageData.SetStageData(stageID);
            //SET BATTLE SPRITES, QUESTIONS, TIMER, ETC
            cdTimer = stageData.Timer;
            enemyHealth = stageData.EnemyHP;
            enemyMaxHealth = stageData.EnemyHP;

            SetNewQuestion();

            canAnswerTimer.Interval = 400;
            canAnswerTimer.Start();
        }

        public FightScreen(IGameScreenManager gameScreenManager, string m_currentWord, string m_questionWord)
        {
            m_ScreenManager = gameScreenManager;

            currentWord = m_currentWord;
            questionWord = m_questionWord;
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
            SpriteFont m_Japanese = content.Load<SpriteFont>("Fonts/Japanese");
            click = content.Load<SoundEffect>("SFX/Select_Click");
            bgSong = content.Load<SoundEffect>("Music/Reformat");

            HPTexture = content.Load<Texture2D>("Health/health");
            pHPBarBG = new Rectangle(pHPBarXPos - 3, hpBarYPos - 3, 256, 36);
            eHPBarBG = new Rectangle(eHPBarXPos - 3, hpBarYPos - 3, 256, 36);

            Sprite ground = new Sprite(content.Load<Texture2D>("standingGround"))
            {
                Position = new Vector2(0, 502)
            };

            Player = new Sprite(Game1.activePlayer_FightTexture)
            {
                Position = new Vector2(120, 325)
            };

            Companion = new Sprite(Game1.activeCompanion_FightTexture)
            {
                Position = new Vector2(25, 425)
            };

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

            var screenBackground = new Sprite(content.Load<Texture2D>("BGs/bgCloudsSmaller"))
            {
                Position = new Vector2(-100, -2)
            };

            var questionBackground = new Sprite(content.Load<Texture2D>("textboxes/textbox600x180"))
            {
                Position = new Vector2(100, 32)
            };

            #region Question Rendering

            Vector2 m_questionPosition = new Vector2(1, 70);
            Color m_questionColor = Color.Black;

            m_questionText = new Text(questionWord, m_Japanese, m_questionPosition, m_questionColor);
            m_questionText.CenterHorizontal(800, 80);
            #endregion

            Vector2 m_timerPosition = new Vector2(750, 5);
            m_TimerText = new Text(cdTimer.ToString(), m_Japanese, m_timerPosition, m_questionColor);

            #region Answer Button 1
            answerButton1 = new Button(content.Load<Texture2D>("Menu/Red/red_button03"), m_Japanese)
            {
                Position = new Vector2(305, 230),
                Text = optionOne,
            };

            answerButton1.Click += AnswerButton1_Click;
            #endregion
            #region Answer Button 2
            answerButton2 = new Button(content.Load<Texture2D>("Menu/Blue/blue_button03"), m_Japanese)
            {
                Position = new Vector2(205, 280),
                Text = optionTwo,
            };

            answerButton2.Click += AnswerButton2_Click;
            #endregion
            #region Answer Button 3
            answerButton3 = new Button(content.Load<Texture2D>("Menu/Blue/Blue_button03"), m_Japanese)
            {
                Position = new Vector2(405, 280),
                Text = optionThree,
            };

            answerButton3.Click += AnswerButton3_Click;
            #endregion
            #region Answer Button 4
            answerButton4 = new Button(content.Load<Texture2D>("Menu/Red/red_button03"), m_Japanese)
            {
                Position = new Vector2(305, 330),
                Text = optionFour,
            };

            answerButton4.Click += AnswerButton4_Click;
            #endregion

            m_components = new List<Component>()
            {

                screenBackground,
                questionBackground,
                 answerButton1,
                answerButton2,
                answerButton3,
                answerButton4,
                ground,
                Player,
                Companion,
            };
        }

        private void SetNewQuestion()
        {
            //CREATE A NEW QUESITON
            Question question = new Question(stageData.CurrentSet);
            //IF THE CURRENT SELECTED QUESTION MATCHES THE LAST... GENERATE A NEW ONE
            while (question.Quest == lastQuest.Quest) { question = new Question(stageData.CurrentSet); }

            //SET THE FIGHTSCREEN VARIABLES TO THE QUESTION VARIABLES
            questionWord = question.Quest;
            optionOne = question.Ans1;
            optionTwo = question.Ans2;
            optionThree = question.Ans3;
            optionFour = question.Ans4;
            currentWord = question.CorrectAns;

            //MAKE THIS QUESTION THE LAST QUESTION
            lastQuest = question;

        }

        #region Click Methods

        private void Answer01_Pressed()
        {
            //click.Play();
            CheckAns(optionOne);
        }

        private void Answer02_Pressed()
        {
            //click.Play();
            CheckAns(optionTwo);
        }

        private void Answer03_Pressed()
        {
            //click.Play();
            CheckAns(optionThree);
        }

        private void Answer04_Pressed()
        {
            //click.Play();
            CheckAns(optionFour);
        }

        private void AnswerButton1_Click(object sender, EventArgs e)
        {
            //click.Play();
            CheckAns(optionOne);         
        }

        private void AnswerButton2_Click(object sender, EventArgs e)
        {
            //click.Play();
            CheckAns(optionTwo);
        }

        private void AnswerButton3_Click(object sender, EventArgs e)
        {
            //click.Play();
            CheckAns(optionThree);
        }

        private void AnswerButton4_Click(object sender, EventArgs e)
        {
            //click.Play();
            CheckAns(optionFour);
        }

        #endregion
        private void CheckAns(string ans) {
            if (ans == currentWord)
            {
                enemyHealth -= 5;
            }
            else
            {
                playerHealth -= 5;
                cdTimer -= 3;
            }
            SetNewQuestion();
        }

        public void Pause()
        {
            IsPaused = true;
        }

        public void Resume()
        {
            IsPaused = false;
        }

        private void Gameover()
        {
            if (Game1.m_audioState == Game1.AudioState.PLAYING)
                Game1.currentInstance.Stop();

            m_ScreenManager.PopScreen();
            m_ScreenManager.ChangeScreen(new GameOverScreen(m_ScreenManager));
        }

        public void Update(GameTime gameTime)
        {

            foreach (var component in m_components)
                component.Update(gameTime);

            m_questionText.Message = questionWord;
            answerButton1.Text = optionOne;
            answerButton2.Text = optionTwo;
            answerButton3.Text = optionThree;
            answerButton4.Text = optionFour;
            m_questionText.CenterHorizontal(800, 100);   

            if (canAnswer == false)
            {
                canAnswerTimer.Elapsed += CanAnswerTimer_Elapsed;
            }

            //UPDATE TIMER
            cdTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            m_TimerText.Message = cdTimer.ToString("0");
            //IF TIMER REACHES 0, PUSH GAMEOVER SCREEN
            if (cdTimer <= 0) { Gameover(); }
            //UPDATE HEALTH BARS
            playerHPBar = new Rectangle(pHPBarXPos, hpBarYPos, (playerHealth * hpBarLength) / playerMaxHealth, hpBarWidth);
            enemyHPBar = new Rectangle(eHPBarXPos, hpBarYPos, (enemyHealth * hpBarLength) / enemyMaxHealth, hpBarWidth);
            //IF PLAYER HEALTH REACHES 0, PUSH GAMEOVER SCREEN
            if (playerHealth <= 0) { Gameover(); }
            //IF ENEMY HEALTH REACHES 0, POP THE WORLD MAP SCREEN & UNLOCK NEW LEVEL
            if (enemyHealth <= 0) {
                if (Game1.m_audioState == Game1.AudioState.PLAYING)
                    Game1.currentInstance.Stop();
                    m_ScreenManager.PopScreen();
            }

        }

        private void CanAnswerTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            canAnswer = true;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            /*
            m_eHealthText.Draw(spriteBatch);
            m_pHealthText.Draw(spriteBatch);
            */

            foreach (var component in m_components)
                component.Draw(gameTime, spriteBatch);

            m_questionText.Draw(spriteBatch);
            m_TimerText.Draw(spriteBatch);

            spriteBatch.Draw(HPTexture, pHPBarBG, Color.Black);
            spriteBatch.Draw(HPTexture, eHPBarBG, Color.Black);
            spriteBatch.Draw(HPTexture, playerHPBar, Color.White);
            spriteBatch.Draw(HPTexture, enemyHPBar, Color.White);

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
                m_ScreenManager.PushScreen(new OptionsScreen(m_ScreenManager));
            }

            #region Answer on Button Press
            if (canAnswer)
            {
                if ((oldState.IsKeyUp(Keys.W) && keyboard.IsKeyDown(Keys.W)) || (oldState.IsKeyUp(Keys.Up) && keyboard.IsKeyDown(Keys.Up)))
                {
                    Answer01_Pressed();
                    canAnswer = false;
                    canAnswerTimer.Start();
                }
                if ((oldState.IsKeyUp(Keys.A) && keyboard.IsKeyDown(Keys.A)) || (oldState.IsKeyUp(Keys.Left) && keyboard.IsKeyDown(Keys.Left)))
                {
                    Answer02_Pressed();
                    canAnswer = false;
                    canAnswerTimer.Start();
                }
                if ((oldState.IsKeyUp(Keys.D) && keyboard.IsKeyDown(Keys.D)) || (oldState.IsKeyUp(Keys.Right) && keyboard.IsKeyDown(Keys.Right)))
                {
                    Answer03_Pressed();
                    canAnswer = false;
                    canAnswerTimer.Start();
                }
                if ((oldState.IsKeyUp(Keys.S) && keyboard.IsKeyDown(Keys.S)) || (oldState.IsKeyUp(Keys.Down) && keyboard.IsKeyDown(Keys.Down)))
                {
                    Answer04_Pressed();
                    canAnswer = false;
                    canAnswerTimer.Start();
                }
            }
            
            
            #endregion

            oldState = keyboard;
        }

        public void Dispose()
        {
            
        }
    }
}
