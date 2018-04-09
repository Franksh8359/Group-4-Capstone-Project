using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace concept_0_03
{
    public class Player : Sprite
    {
        public bool playerCanMove;

        public Player(Texture2D texture)
            : base(texture)
        {
            playerCanMove = true;
        }

        public override void Update(GameTime gameTime)
        {
            var velocity = new Vector2();

            var speed = 3f;

            if (playerCanMove)
            {
                #region Up & Down Movement -- CURRENTLY ON
                
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                    velocity.Y = -speed;
                else if (Keyboard.GetState().IsKeyDown(Keys.S))
                    velocity.Y = speed;

                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                    velocity.Y = -speed;
                else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                    velocity.Y = speed;

                #endregion

                #region Left & Right Movement -- CURRENTLY ON

                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    velocity.X = -speed;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    velocity.X = speed;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    velocity.X = -speed;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    velocity.X = speed;
                }

                #endregion
            }
            

            Position += velocity;
        }
    }
}
