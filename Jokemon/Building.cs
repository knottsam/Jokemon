using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jokemon
{
    class Building : Sprite
    {
        public Building() : base()
        { 
        }

        public Building(Texture2D inTexture, Vector2 inPosition, Vector2 inSize, Color inColour)
            : base(inTexture, inPosition, inSize, inColour)
        { 
        }
    }
}
