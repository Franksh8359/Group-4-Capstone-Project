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
        // 250, 30

        private bool m_exitGame;
        private readonly IGameScreenManager m_ScreenManager;

        private bool isMusicOn;
        private bool wasOptionsOpened;

        private Stage.StageData stageData = new Stage.StageData(); //CREATE A NEW STAGEDATA LIST

        private List<Component> m_components;
        private SoundEffect click;

        #region Question Variables

        private string optionOne;
        private string optionTwo;
        private string optionThree;
        private string optionFour;
        private string currentWord;
        private string questionWord;


        #endregion

        private Text m_questionText;
        private Text m_eHealthText;
        private Button answerButton1;
        private Button answerButton2;
        private Button answerButton3;
        private Button answerButton4;
        private int enemyHealth = 5;
        private string fullEnemyHealthText;

        #region Health Bar Variables

        private Sprite e_healthBarBack;
        private Sprite e_healthBarMain;
        private Sprite p_healthBarBack;
        private Sprite p_healthBarMain;

        private Texture2D fiveHearts;
        private Texture2D fourHearts;
        private Texture2D threeHearts;
        private Texture2D twoHearts;
        private Texture2D oneHeart;
        private Texture2D zeroHearts;

        #endregion

        private Text m_pHealthText;
        private int playerHealth = 5;
        private string fullPlayerHealthText;

        public bool IsPaused { get; private set; }

        private SoundEffect bgSong;
        private SoundEffectInstance bgMusic;
        private KeyboardState oldState;

        private Timer canAnswerTimer = new Timer();
        private bool canAnswer = false;

        private string stageID;

        private Sprite Player;

        private void SetNewQuestion()
        {
            Question question = new Question(stageData.CurrentSet);

            questionWord = question.Quest;

            optionOne = question.Ans1;
            optionTwo = question.Ans2;
            optionThree = question.Ans3;
            optionFour = question.Ans4;

            currentWord = question.CorrectAns;

        }

        public FightScreen(IGameScreenManager gameScreenManager, string stage_ID)
        {
            m_ScreenManager = gameScreenManager;

            stageID = stage_ID;
            stageData.SetStageData(stageID);

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
            bgSong = content.Load<SoundEffect>("Music/Final Fantasy VIII - Only A Plank Between One and Perdition [HQ]");

            Sprite ground = new Sprite(content.Load<Texture2D>("standingGround"))
            {
                Position = new Vector2(0, 502)
            };

            Player = new Sprite(Game1.activePlayer_FightTexture)
            {
                Position = new Vector2(120, 325)
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

            #region Health Bar Textures

            fiveHearts = content.Load<Texture2D>("Health/5");
            fourHearts = content.Load<Texture2D>("Health/4");
            threeHearts = content.Load<Texture2D>("Health/3");
            twoHearts = content.Load<Texture2D>("Health/2");
            oneHeart = content.Load<Texture2D>("Health/1");
            zeroHearts = content.Load<Texture2D>("Health/0");

            #endregion

            var screenBackground = new Sprite(content.Load<Texture2D>("BGs/bgCloudsSmaller"))
            {
                Position = new Vector2(-100, -2)
            };

            var questionBackground = new Sprite(content.Load<Texture2D>("textboxes/textbox600x180"))
            {
                Position = new Vector2(100, 2)
            };

            #region Enemy Health Rendering
            fullEnemyHealthText = "Enemy Health: " + enemyHealth;

            Vector2 m_eHealthPosition = new Vector2(575, 560);
            Color m_eHealthColor = Color.Black;

            m_eHealthText = new Text(fullEnemyHealthText, m_font, m_eHealthPosition, m_eHealthColor);
            #endregion
            #region Enemy Health Bar

            e_healthBarMain = new Sprite(fiveHearts)
            {
                Position = m_eHealthPosition
            };

            #endregion

            #region Player Health Rendering
            fullPlayerHealthText = "Player Health: " + playerHealth;

            Vector2 m_pHealthPosition = new Vector2(25, 560);
            Color m_pHealthColor = Color.Black;

            m_pHealthText = new Text(fullPlayerHealthText, m_font, m_pHealthPosition, m_pHealthColor);
            #endregion
            #region Player Health Bar

            p_healthBarMain = new Sprite(fiveHearts)
            {
                Position = m_pHealthPosition
            };

            #endregion

            #region Question Rendering

            Vector2 m_questionPosition = new Vector2(1, 20);
            Color m_questionColor = Color.Black;

            m_questionText = new Text(questionWord, m_Japanese, m_questionPosition, m_questionColor);
            m_questionText.CenterHorizontal(800, 30);
            #endregion

            #region Answer Button 1
            answerButton1 = new Button(content.Load<Texture2D>("Menu/Red/red_button03"), m_Japanese)
            {
                Position = new Vector2(305, 200),
                Text = optionOne,
            };

            answerButton1.Click += AnswerButton1_Click;
            #endregion
            #region Answer Button 2
            answerButton2 = new Button(content.Load<Texture2D>("Menu/Blue/blue_button03"), m_Japanese)
            {
                Position = new Vector2(205, 250),
                Text = optionTwo,
            };

            answerButton2.Click += AnswerButton2_Click;
            #endregion
            #region Answer Button 3
            answerButton3 = new Button(content.Load<Texture2D>("Menu/Blue/Blue_button03"), m_Japanese)
            {
                Position = new Vector2(405, 250),
                Text = optionThree,
            };

            answerButton3.Click += AnswerButton3_Click;
            #endregion
            #region Answer Button 4
            answerButton4 = new Button(content.Load<Texture2D>("Menu/Red/red_button03"), m_Japanese)
            {
                Position = new Vector2(305, 300),
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
            };
        }

        #region Click Methods

        private void Answer01_Pressed()
        {
            //click.Play();

            if (optionOne == currentWord)
            {
                enemyHealth -= 1;
            }
            else
            {
                playerHealth -= 1;
            }
            SetNewQuestion();
        }

        private void Answer02_Pressed()
        {
            //click.Play();

            if (optionTwo == currentWord)
            {
                enemyHealth -= 1;
            }
            else
            {
                playerHealth -= 1;
            }
            SetNewQuestion();
        }

        private void Answer03_Pressed()
        {
            //click.Play();

            if (optionThree == currentWord)
            {
                enemyHealth -= 1;
            }
            else
            {
                playerHealth -= 1;
            }
            SetNewQuestion();
        }

        private void Answer04_Pressed()
        {
            //click.Play();

            if (optionFour == currentWord)
            {
                enemyHealth -= 1;
            }
            else
            {
                playerHealth -= 1;
            }
            SetNewQuestion();
        }

        private void AnswerButton1_Click(object sender, EventArgs e)
        {
            //click.Play();

            if (optionOne == currentWord)
            {
                enemyHealth -= 1;
            }
            else
            {
                playerHealth -= 1;
            }
        }

        private void AnswerButton2_Click(object sender, EventArgs e)
        {
            //click.Play();

            if (optionTwo == currentWord)
            {
                enemyHealth -= 1;
            }
            else
            {
                playerHealth -= 1;
            }
        }

        private void AnswerButton3_Click(object sender, EventArgs e)
        {
            //click.Play();

            if (optionThree == currentWord)
            {
                enemyHealth -= 1;
            }
            else
            {
                playerHealth -= 1;
            }
        }

        private void AnswerButton4_Click(object sender, EventArgs e)
        {
            //click.Play();

            if (optionFour == currentWord)
            {
                enemyHealth -= 1;
            }
            else
            {
                playerHealth -= 1;
            }
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

            m_eHealthText.Message = "Enemy Health: " + enemyHealth;
            m_pHealthText.Message = "Player Health: " + playerHealth;
            m_questionText.Message = questionWord;
            answerButton1.Text = optionOne;
            answerButton2.Text = optionTwo;
            answerButton3.Text = optionThree;
            answerButton4.Text = optionFour;
            m_questionText.CenterHorizontal(800, 30);   

            switch (enemyHealth)
            {
                case 5:
                    break;
                case 4:
                    e_healthBarMain.Texture = fourHearts;
                    break;
                case 3:
                    e_healthBarMain.Texture = threeHearts;
                    break;
                case 2:
                    e_healthBarMain.Texture = twoHearts;
                    break;
                case 1:
                    e_healthBarMain.Texture = oneHeart;
                    break;
                case 0:
                    if (Game1.m_audioState == Game1.AudioState.PLAYING)
                        Game1.currentInstance.Stop();

                    m_ScreenManager.PopScreen();
                    break;
            }

            switch (playerHealth)
            {
                case 5:
                    break;
                case 4:
                    p_healthBarMain.Texture = fourHearts;
                    break;
                case 3:
                    p_healthBarMain.Texture = threeHearts;
                    break;
                case 2:
                    p_healthBarMain.Texture = twoHearts;
                    break;
                case 1:
                    p_healthBarMain.Texture = oneHeart;
                    break;
                case 0:
                    if (Game1.m_audioState == Game1.AudioState.PLAYING)
                        Game1.currentInstance.Stop();

                    m_ScreenManager.ChangeScreen(new GameOverScreen(m_ScreenManager));
                    break;
            }

            if (canAnswer == false)
            {
                canAnswerTimer.Elapsed += CanAnswerTimer_Elapsed;
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

            e_healthBarMain.Draw(gameTime, spriteBatch);
            p_healthBarMain.Draw(gameTime, spriteBatch);

            m_questionText.Draw(spriteBatch);

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
