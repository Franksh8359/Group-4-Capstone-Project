using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace concept_0_03
{
    class SplashScreen : IGameScreen
    {
        #region Script Variables
        private bool m_exitGame;
        private readonly IGameScreenManager m_ScreenManager;
        private Command m_command;

        //Buttons and Variables for them.
        Texture2D buttonTexture;
        SpriteFont buttonFont;
        //Buttons
        Button switchListButton;
        public string sbtext = "Golden Keys";
        Button BackButton;

        KeyInventory keyInventory = new KeyInventory();
        List<KeyClass> currentDisplayedKeys;


        public int worldDisplayed = 1;
        int spotCount;
        int line;

        private List<Component> m_components;
        private SoundEffect click;

        public bool IsPaused { get; private set; }
        #endregion

        public SplashScreen(IGameScreenManager gameScreenManager)
        {
            m_ScreenManager = gameScreenManager;
            m_command = new Command(m_ScreenManager);
        }


        Texture2D image_KeyGallery;
        Texture2D image_NotUnlocked;
        Texture2D image_SilverKey;
        Texture2D image_GoldenKey;
        string path;
        string path2;
        string path3;
        string path4;

        List<KeyClass> keyList = new List<KeyClass>();

        public void Pause()
        {
            IsPaused = true;
        }

        public void Resume()
        {
            IsPaused = false;
        }

        public void Init(ContentManager content)
        {
            currentDisplayedKeys = keyInventory.GetSilverKeyList();

            path = "KeyGallery/KeyGalleryFrame";
            path2 = "KeyGallery/NotObtainedKey";
            path3 = "KeyGallery/SilverKey";
            path4 = "KeyGallery/GoldKey";

            image_KeyGallery = content.Load<Texture2D>(path);
            image_NotUnlocked = content.Load<Texture2D>(path2);
            image_SilverKey = content.Load<Texture2D>(path3);
            image_GoldenKey = content.Load<Texture2D>(path4);


            buttonTexture = content.Load<Texture2D>("Menu/Grey/grey_button04");
            buttonFont = content.Load<SpriteFont>("Fonts/Font");

            //Create Buttons
            switchListButton = CreateButton(new Vector2(570, 68), sbtext);
            BackButton = CreateButton(new Vector2(590, 5), "Back");

            //Set Click Functions to button.
            switchListButton.Click += SwitchListsButton_Click;
            BackButton.Click += Back_Click;





            m_components = new List<Component>()
            {
                switchListButton,
                BackButton
            };
        }

        

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            //Process
            //1. Get the keys for the current world (1) 
            if (switchListButton.Text == "Golden Keys")
                FillGalleryWithPictures(spriteBatch, keyInventory.GetSilverKeyList());
            else
                FillGalleryWithPictures(spriteBatch, keyInventory.GetGoldKeyList());

            //2. Fill in remaining blank spaces.
            FillRemainingEmptyPictures(spriteBatch);

            //3. Load up other UI objects.
            spriteBatch.Draw(image_KeyGallery, new Rectangle(0, -2, 802, 602), Color.White);

            //Draw all buttons to screen.
            foreach (var i in m_components)
                i.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public void HandleInput(GameTime gameTime)
        {
            var keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Left) == true)
               SwitchListsButton_Pressed();
        }

        public void ChangeBetweenScreens()
        {
            if (m_exitGame)
            {
                m_ScreenManager.Exit();
            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            foreach (var component in m_components)
                component.Update(gameTime);
        }




        #region Script Required Functions

        #endregion

        #region Script Personalized Functions
        private Button CreateButton(Vector2 v2, string text)
        {
            Button tempButton = new Button(buttonTexture, buttonFont)
            {

                Position = v2,
                Text = text,
            };

            return tempButton;
        }

        #region FillGalleryFunctions
        private void FillGalleryWithPictures(SpriteBatch spriteBatch, List<KeyClass> list)
        {
            Texture2D image3 = image_SilverKey;

            line = 0;
            spotCount = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].GetKeyWorld() == worldDisplayed)
                {
                    //Check to see what image to place down.
                    if (list[i].GetObtained() == true)
                    {
                        if (list[i].GetKeyType() == KeyClass.KeyType.Gold)
                            image3 = image_GoldenKey;
                        else if (list[i].GetKeyType() == KeyClass.KeyType.Silver)
                            image3 = image_SilverKey;
                    }
                    else
                        image3 = image_NotUnlocked;

                    //Draw the image to the screen.
                    spriteBatch.Draw(image3, new Rectangle(49 + (spotCount * 176), 120 + (line * 147), 170, 140), Color.White);

                    spotCount++;    //Increment spotcount

                }


                //If spotCount is at the last spot on a row, increment line and set spotCount to zero.
                if (spotCount == 4)
                {
                    line++;
                    spotCount = 0;
                }
            }
        }

        private void FillRemainingEmptyPictures(SpriteBatch spriteBatch)
        {
            Texture2D image3 = image_SilverKey;

            //Variables for blocked out spaces
            int scount = spotCount;
            int lcount = line;
            for (int k = 0; k < (12 - (4 * lcount)) - scount; k++)
            {
                spriteBatch.Draw(image3, new Rectangle(49 + (spotCount * 176), 120 + (line * 147), 170, 140), Color.Black);

                spotCount++;

                if (spotCount == 4)
                {
                    line++;
                    spotCount = 0;
                }
            }
        }
        #endregion
        #endregion

        #region Button Press Functions
        #region Switch From Gold Keys To Silver Keys
        private void SwitchListsButton_Click(object sender, EventArgs e)
        {
            //Change SwitchListButton Text.
            if (switchListButton.Text == "Golden Keys")
                switchListButton.Text = "Silver Keys";

            //Call Draw to reload pics
            SplashScreen temp = new SplashScreen(m_ScreenManager);
            temp.worldDisplayed = this.worldDisplayed;
            temp.sbtext = switchListButton.Text;

            //Change Screens Based on what screen is 
            if (sbtext == "Golden Keys")
                m_ScreenManager.PushScreen(temp);
            else
                m_ScreenManager.PopScreen();

            switchListButton.Text = "Golden Keys";
        }

        private void SwitchListsButton_Pressed()
        {
            //Change SwitchListButton Text.
            if (switchListButton.Text == "Golden Keys")
                switchListButton.Text = "Silver Keys";

            //Call Draw to reload pics
            SplashScreen temp = new SplashScreen(m_ScreenManager);
            temp.worldDisplayed = this.worldDisplayed;
            temp.sbtext = switchListButton.Text;

            //Change Screens Based on what screen is 
            if (sbtext == "Golden Keys")
                m_ScreenManager.PushScreen(temp);
            else
                m_ScreenManager.PopScreen();

            switchListButton.Text = "Golden Keys";
        }
        #endregion

        #region Change World Buttons
        private void Back_Click(object sender, EventArgs e)
        {
            if (this.sbtext == "Golden Keys")
                m_ScreenManager.PopScreen(); //Pop Once
            else
                for (int i = 0; i < 2; i++)
                    m_ScreenManager.PopScreen(); //Pop Twice
        }

        private void Back_Pressed()
        {
            if (this.sbtext == "Golden Keys")
                m_ScreenManager.PopScreen(); //Pop Once
            else
                for (int i = 0; i < 2; i++)
                    m_ScreenManager.PopScreen(); //Pop Twice
        }
        #endregion





        #endregion
    }
}
