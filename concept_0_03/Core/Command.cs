using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace concept_0_03
{
    class Command
    {
        GameTime gameTime;
        IGameScreenManager gameScreenManager;



        #region Constructors

        public Command()
        {

        }

        public Command(IGameScreenManager m_screenManager)
        {
            gameScreenManager = m_screenManager;
        }

        public Command(GameTime m_gameTime)
        {
            gameTime = m_gameTime;
        }

        public Command(IGameScreenManager m_screenManager, GameTime m_gameTime)
        {
            gameScreenManager = m_screenManager;
            gameTime = m_gameTime;
        }

        #endregion

        // --
        #region Options

        #region Open/Close Options

        public void OpenOptionsMenu(IGameScreenManager m_screenManager)
        {
            m_screenManager.PushScreen(new OptionsScreen(m_screenManager));
        }

        public void CloseOptionsMenu(IGameScreenManager m_screenManager)
        {
            m_screenManager.PopScreen();
        }

        #endregion

        #region Music On/Off

        public void ToggleAudio()
        {
            switch (Game1.m_audioState)
            {
                case Game1.AudioState.OFF:
                    Game1.currentInstance.Stop();

                    Game1.m_audioState = Game1.AudioState.PLAYING;
                    break;
                case Game1.AudioState.PAUSED:
                    Game1.currentInstance.Stop();

                    Game1.m_audioState = Game1.AudioState.PLAYING;
                    break;
                case Game1.AudioState.PLAYING:
                    Game1.currentInstance.Play();

                    Game1.m_audioState = Game1.AudioState.PAUSED;
                    break;
            }
        }

        #endregion

        #region Save Game -- Unimplemented

        public void SaveGame(IGameScreenManager m_screenManager)
        {
            // Actual save game code not yet coded

            Console.WriteLine("Save Game");
        }

        #endregion

        #endregion

        // --
        #region World Map Screen

        #region Enter Current World

        public int EnterLevel(int currentLevel, IGameScreenManager m_screenManager, int levelsUnlocked)
        {
            switch (currentLevel)
            {
                case 1:
                    if (Game1.m_audioState == Game1.AudioState.PLAYING)
                        Game1.currentInstance.Stop();

                    if (levelsUnlocked > 0)
                    {
                        m_screenManager.PushScreen(new LevelOneScreen(m_screenManager));
                    }

                    if (levelsUnlocked == 1)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
                case 2:
                    if (Game1.m_audioState == Game1.AudioState.PLAYING)
                        Game1.currentInstance.Stop();

                    if (levelsUnlocked > 1)
                    {
                        m_screenManager.PushScreen(new LevelTwoScreen(m_screenManager));
                    }
                    else
                    {
                        // display cannot enter level message???
                    }

                    if (levelsUnlocked == 2)
                    {
                        levelsUnlocked += 1;
                    }

                    return levelsUnlocked;
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

            return levelsUnlocked;
        }

        #endregion

        #endregion

        // --
        #region Menu Screen

        #region New Game

        public void NewGame(IGameScreenManager m_screenManager)
        {
            if (Game1.m_audioState == Game1.AudioState.PLAYING)
                Game1.currentInstance.Stop();

            m_screenManager.ChangeScreen(new CharacterSelectionScreen(m_screenManager));
        }

        #endregion

        #region Gallery Button

        public void LoadGame(IGameScreenManager m_screenManager)
        {
            m_screenManager.PushScreen(new KeyGallery(m_screenManager));
        }

        #endregion

        #endregion

        // --
        #region Character Creation Screen

        #region Player Selection

        #region Player One

        public string ChoosePlayerOne()
        {
            Game1.activePlayerTexture = CharacterSelectionScreen.player01;
            Game1.activePlayer_FightTexture = CharacterSelectionScreen.player01_Fight;

            string whichCharacter = "Player01";
            return whichCharacter;
        }

        #endregion
        #region Player Two

        public string ChoosePlayerTwo()
        {
            Game1.activePlayerTexture = CharacterSelectionScreen.player02;
            Game1.activePlayer_FightTexture = CharacterSelectionScreen.player02_Fight;

            string whichCharacter = "Player02";
            return whichCharacter;
        }

        #endregion
        #region Player Three

        public string ChoosePlayerThree()
        {
            Game1.activePlayerTexture = CharacterSelectionScreen.player03;
            Game1.activePlayer_FightTexture = CharacterSelectionScreen.player03_Fight;

            string whichCharacter = "Player03";
            return whichCharacter;
        }

        #endregion

        #endregion

        #region Game Start

        public void StartGame(IGameScreenManager m_screenManager)
        {
            if (Game1.m_audioState == Game1.AudioState.PLAYING)
                Game1.currentInstance.Stop();

            m_screenManager.ChangeScreen(new WorldMapScreen(m_screenManager));
        }

        #endregion

        #endregion

    }
}
