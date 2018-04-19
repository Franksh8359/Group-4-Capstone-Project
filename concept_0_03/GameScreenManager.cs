using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace concept_0_03
{
    class GameScreenManager : IGameScreenManager
    {
        private Action m_onGameExit;

        private readonly SpriteBatch m_spriteBatch;
        private readonly ContentManager m_contentManager;
        
        private readonly List<IGameScreen> m_gameScreens = new List<IGameScreen>();

        public GameScreenManager(SpriteBatch spriteBatch, ContentManager contentManager)
        {
            m_spriteBatch = spriteBatch;
            m_contentManager = contentManager;
        }

        public void ChangeScreen(IGameScreen screen)
        {
            RemoveAllScreens();

            m_gameScreens.Add(screen);

            screen.Init(m_contentManager);
        }

        public void PushScreen(IGameScreen screen)
        {
            if(!IsScreenListEmpty)
            {
                var curScreen = GetCurrentScreen();
                curScreen.Pause();
            }

            m_gameScreens.Add(screen);
            screen.Init(m_contentManager);
        }

        public void PopScreen()
        {
            if(!IsScreenListEmpty)
            {
                RemoveCurrentScreen();
            }

            if(!IsScreenListEmpty)
            {
                var curScreen = GetCurrentScreen();
                curScreen.Resume();
            }
        }

        #region Screen Helper Functions
        private bool IsScreenListEmpty
        {
            get { return m_gameScreens.Count <= 0; }
        }

        private IGameScreen GetCurrentScreen()
        {
            return m_gameScreens[m_gameScreens.Count - 1];
        }

        private void RemoveAllScreens()
        {
            while (!IsScreenListEmpty)
            {
                RemoveCurrentScreen();
            }
        }

        private void RemoveCurrentScreen()
        {
            var screen = GetCurrentScreen();

            screen.Dispose();

            m_gameScreens.Remove(screen);
        }
        #endregion

        public void HandleInput(GameTime gameTime)
        {
            if (!IsScreenListEmpty)
            {
                var screen = GetCurrentScreen();

                if (!screen.IsPaused)
                {
                    screen.HandleInput(gameTime);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if (!IsScreenListEmpty)
            {
                var screen = GetCurrentScreen();

                if (!screen.IsPaused)
                {
                    screen.Update(gameTime);
                }
            }
        }

        public void Draw(GameTime gameTime)
        {
            if (!IsScreenListEmpty)
            {
                var screen = GetCurrentScreen();

                if (!screen.IsPaused)
                {
                    screen.Draw(gameTime, m_spriteBatch);
                }
            }
        }

        public void ChangeBetweenScreens()
        {
            if (!IsScreenListEmpty)
            {
                var screen = GetCurrentScreen();

                if (!screen.IsPaused)
                {
                    screen.ChangeBetweenScreens();
                }
            }
        }

        public void Exit()
        {
            m_onGameExit?.Invoke();
        }

        public event Action OnGameExit
        {
            add { m_onGameExit += value; }
            remove { m_onGameExit -= value; }
        }

        public void Dispose()
        {
            RemoveAllScreens();
        }
    }
}
