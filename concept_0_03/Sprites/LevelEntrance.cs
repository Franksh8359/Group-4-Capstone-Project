using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace concept_0_03
{
    class LevelEntrance : Component
    {
        public Texture2D _texture;
        public Vector2 Position;
        public String LevelName = "0-0";

        public Color Colour = Color.White;

        public LevelEntrance(Texture2D texture)
        {
            _texture = texture;
        }

        public LevelEntrance(Texture2D texture, Vector2 position, String levelName)
        {
            _texture = texture;
            Position = position;
            LevelName = levelName;
        }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height); }

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Colour);
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
