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

        Stage.StageData stageData = new Stage.StageData();
        //Combat combat = new Combat();

        private string optionOne;
        private string optionTwo;
        private string optionThree;
        private string optionFour;
        private string currentWord;
        private string questionBeginning;
        private string questionWord;

        private Text m_questionText;
        private Text m_eHealthText;
        private int enemyHealth;
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

        public FightScreen(IGameScreenManager gameScreenManager, string stageID)
        {
            m_ScreenManager = gameScreenManager;

            stageData.SetStageData(stageID);

            enemyHealth = stageData.EnemyHP;

            //combat.SetCombat(playerHealth, stageData.EnemyHP);

            Question question = new Question(stageData.CurrentSet);

            questionWord = question.Quest;

            optionOne = question.Ans1;
            optionTwo = question.Ans2;
            optionThree = question.Ans3;
            optionFour = question.Ans4;

            currentWord = question.CorrectAns;

            canAnswerTimer.Interval = 400;
            canAnswerTimer.Start();
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
            bgMusic = bgSong.CreateInstance();

            #region Health Bar Textures

            fiveHearts = content.Load<Texture2D>("Health/5");
            fourHearts = content.Load<Texture2D>("Health/4");
            threeHearts = content.Load<Texture2D>("Health/3");
            twoHearts = content.Load<Texture2D>("Health/2");
            oneHeart = content.Load<Texture2D>("Health/1");
            zeroHearts = content.Load<Texture2D>("Health/0");

            #endregion

            bgMusic.IsLooped = true;
            bgMusic.Volume = 0.5f;
            bgMusic.Play();

            var screenBackground = new Sprite(content.Load<Texture2D>("BGs/" + stageData.StageBG));
            screenBackground.Position = new Vector2(-100, -2);

            var questionBackground = new Sprite(content.Load<Texture2D>("textboxes/textbox600x180"));
            questionBackground.Position = new Vector2(100, 2);

            #region Enemy Health Rendering
            fullEnemyHealthText = "Enemy Health: " + enemyHealth;

            Vector2 m_eHealthPosition = new Vector2(575, 560);
            Color m_eHealthColor = Color.Black;

            m_eHealthText = new Text(fullEnemyHealthText, m_font, m_eHealthPosition, m_eHealthColor);
            #endregion
            #region Enemy Health Bar

            e_healthBarMain = new Sprite(fiveHearts);
            e_healthBarMain.Position = m_eHealthPosition;

            #endregion

            #region Player Health Rendering
            fullPlayerHealthText = "Player Health: " + playerHealth;

            Vector2 m_pHealthPosition = new Vector2(25, 560);
            Color m_pHealthColor = Color.Black;

            m_pHealthText = new Text(fullPlayerHealthText, m_font, m_pHealthPosition, m_pHealthColor);
            #endregion
            #region Player Health Bar

            p_healthBarMain = new Sprite(fiveHearts);
            p_healthBarMain.Position = m_pHealthPosition;

            #endregion

            #region Question Rendering
            questionBeginning = "Please translate: " + questionWord;

            Vector2 m_questionPosition = new Vector2(1, 20);
            Color m_questionColor = Color.Black;

            m_questionText = new Text(questionBeginning, m_Japanese, m_questionPosition, m_questionColor);
            m_questionText.CenterHorizontal(800, 30);
            #endregion

            #region Answer Button 1
            var answerButton1 = new Button(content.Load<Texture2D>("Menu/Red/red_button03"), m_Japanese)
            {
                Position = new Vector2(305, 200),
                Text = optionOne,
            };

            answerButton1.Click += AnswerButton1_Click;
            #endregion
            #region Answer Button 2
            var answerButton2 = new Button(content.Load<Texture2D>("Menu/Blue/blue_button03"), m_Japanese)
            {
                Position = new Vector2(205, 250),
                Text = optionTwo,
            };

            answerButton2.Click += AnswerButton2_Click;
            #endregion
            #region Answer Button 3
            var answerButton3 = new Button(content.Load<Texture2D>("Menu/Blue/Blue_button03"), m_Japanese)
            {
                Position = new Vector2(405, 250),
                Text = optionThree,
            };

            answerButton3.Click += AnswerButton3_Click;
            #endregion
            #region Answer Button 4
            var answerButton4 = new Button(content.Load<Texture2D>("Menu/Red/red_button03"), m_Japanese)
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

            Question question = new Question(stageData.CurrentSet);

            m_eHealthText.Message = "Enemy Health: " + enemyHealth;
            m_pHealthText.Message = "Player Health: " + playerHealth;
            m_questionText.Message = "Quick, which character is \"" + questionWord  + "\"! ";
            m_questionText.CenterHorizontal(800, 30);

            switch (enemyHealth)
            {
                case 5:
                    break;
                case 4:
                    e_healthBarMain._texture = fourHearts;
                    break;
                case 3:
                    e_healthBarMain._texture = threeHearts;
                    break;
                case 2:
                    e_healthBarMain._texture = twoHearts;
                    break;
                case 1:
                    e_healthBarMain._texture = oneHeart;
                    break;
                case 0:
                    bgMusic.Stop();
                    m_ScreenManager.PopScreen();
                    break;
            }

            switch (playerHealth)
            {
                case 5:
                    break;
                case 4:
                    p_healthBarMain._texture = fourHearts;
                    break;
                case 3:
                    p_healthBarMain._texture = threeHearts;
                    break;
                case 2:
                    p_healthBarMain._texture = twoHearts;
                    break;
                case 1:
                    p_healthBarMain._texture = oneHeart;
                    break;
                case 0:
                    bgMusic.Stop();
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
                if (oldState.IsKeyUp(Keys.W) && keyboard.IsKeyDown(Keys.W))
                {
                    Answer01_Pressed();
                    canAnswer = false;
                    canAnswerTimer.Start();
                }
                if (oldState.IsKeyUp(Keys.A) && keyboard.IsKeyDown(Keys.A))
                {
                    Answer02_Pressed();
                    canAnswer = false;
                    canAnswerTimer.Start();
                }
                if (oldState.IsKeyUp(Keys.D) && keyboard.IsKeyDown(Keys.D))
                {
                    Answer03_Pressed();
                    canAnswer = false;
                    canAnswerTimer.Start();
                }
                if (oldState.IsKeyUp(Keys.S) && keyboard.IsKeyDown(Keys.S))
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
