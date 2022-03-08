using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jokemon
{
    class Sprite
    {
        public Vector2 SpriteSize {get; set;}
        public Texture2D SpriteTexture { get; set; }
        public Vector2 SpritePosition { get; set; }
        public Color SpriteColour { get; set; }

        public Sprite()
        { 
        }

        public Sprite(Texture2D inTexture, Vector2 inPosition, Vector2 inSize, Color inColour)
        {
            SpriteTexture = inTexture;
            SpritePosition = inPosition;
            SpriteSize = inSize;
            SpriteColour = inColour;
        }

        public void Draw(SpriteBatch inSpriteBatch)
        {
            inSpriteBatch.Draw(SpriteTexture, 
                new Rectangle((int)SpritePosition.X, (int)SpritePosition.Y, (int)SpriteSize.X, (int)SpriteSize.Y), 
                null, SpriteColour);
        }
    }
}
