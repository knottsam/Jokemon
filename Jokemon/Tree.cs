using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jokemon
{
    class Tree : Sprite
    {
        public Tree() : base()
        {
        }

        public Tree(Texture2D inTexture, Vector2 inPosition, Vector2 inSize, Color inColour)
            : base(inTexture, inPosition, inSize, inColour)
        {
        }
    }
}
