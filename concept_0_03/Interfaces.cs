using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;

namespace concept_0_03
{
    interface IGameScreenManager : IDisposable
    {
        void ChangeScreen(IGameScreen screen);
        void PushScreen(IGameScreen screen);
        void PopScreen();

        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
        void HandleInput(GameTime gameTime);

        void ChangeBetweenScreens();

        void Exit();

        event Action OnGameExit;

    }

    interface IGameScreen : IDisposable
    {
        bool IsPaused { get; }

        void Pause();
        void Resume();

        void Init(ContentManager content);

        void Update(GameTime gameTime);
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        void HandleInput(GameTime gameTime);

        void ChangeBetweenScreens();

    }
}
