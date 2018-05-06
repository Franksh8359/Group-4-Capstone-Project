using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace concept_0_03
{
    class KeyGallery : IGameScreen
    {
        #region Script Variables
        private bool m_exitGame;
        private readonly IGameScreenManager m_ScreenManager;
        private Command m_command;

        //Buttons and Variables for them.
        Texture2D buttonTexture;
        SpriteFont buttonFont;
        //Buttons
        Button BackButton;
        public string sbtext = "Golden Keys";
        Button World1Button;
        Button World2Button;
        Button World3Button;
        KeyInventory keyInventory = new KeyInventory();
        List<KeyClass> currentDisplayedKeys;


        public int worldDisplayed = 1;
        int spotCount;
        int line;

        private List<Component> m_components;
        private SoundEffect click;

        public bool IsPaused { get; private set; }
        #endregion

        public KeyGallery(IGameScreenManager gameScreenManager)
        {
            m_ScreenManager = gameScreenManager;
            m_command = new Command(m_ScreenManager);
        }



        Texture2D image_KeyGalleryTitle;
        string path;


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

            path = "KeyGallery/KeyGalleryTitle";

            image_KeyGalleryTitle = content.Load<Texture2D>(path);

            buttonTexture = content.Load<Texture2D>("Menu/Grey/grey_button04");
            buttonFont = content.Load<SpriteFont>("Fonts/Font");

            //Create Buttons
            //switchListButton = CreateButton(new Vector2(300, 68), sbtext);
            World1Button = CreateButton(new Vector2(315, 310), "World 1 Keys");
            World2Button = CreateButton(new Vector2(315, 360), "World 2 Keys");
            World3Button = CreateButton(new Vector2(315, 410), "World 3 Keys");
            BackButton = CreateButton(new Vector2(315, 460), "Back");

            //Set Click Functions to button.
            World1Button.Click += World1Keys_Click;
            World2Button.Click += World2Keys_Click;
            World3Button.Click += World3Keys_Click;
            BackButton.Click += BackButton_Click;



            m_components = new List<Component>()
            {
                World1Button,
                World2Button,
                World3Button,
                BackButton
            };
        }



        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            //Draw Key Gallery Title
            spriteBatch.Draw(image_KeyGalleryTitle, new Vector2(0, 0), Color.White);
            //Draw Buttons

            //Draw all buttons to screen.
            foreach (var i in m_components)
                i.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public void HandleInput(GameTime gameTime)
        {
            //var keyboard = Keyboard.GetState();

            //if (keyboard.IsKeyDown(Keys.Left) == true)
            //    SwitchListsButton_Pressed();
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
        #endregion

        #region Button Press Functions
        #region Switch From Gold Keys To Silver Keys
        private void World1Keys_Click(object sender, EventArgs e)
        {
            //Call Draw to reload pics
            SplashScreen temp = new SplashScreen(m_ScreenManager);
            temp.worldDisplayed = 1;
            //temp.sbtext = switchListButton.Text;

            //Change Screens Based on what screen is 
            m_ScreenManager.PushScreen(temp);
        }

        private void World2Keys_Click(object sender, EventArgs e)
        {
            //Call Draw to reload pics
            SplashScreen temp = new SplashScreen(m_ScreenManager);
            temp.worldDisplayed = 2;
            //temp.sbtext = switchListButton.Text;

            //Change Screens Based on what screen is 
            m_ScreenManager.PushScreen(temp);
        }

        private void World3Keys_Click(object sender, EventArgs e)
        {
            //Call Draw to reload pics
            SplashScreen temp = new SplashScreen(m_ScreenManager);
            temp.worldDisplayed = 3;
            //temp.sbtext = switchListButton.Text;

            //Change Screens Based on what screen is 
            m_ScreenManager.PushScreen(temp);
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            m_ScreenManager.PopScreen();
        }
        #endregion



        

        #endregion
    }
}