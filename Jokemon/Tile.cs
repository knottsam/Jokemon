using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jokemon
{
    class Tile : Sprite
    {
        /// <summary>
        /// Empty constructor - just in case! :)
        /// </summary>
        public Tile()
        { 
        }

        public Tile(Texture2D inTexture, Vector2 inPosition, Vector2 inSize, Color inColour)
            : base(inTexture, inPosition, inSize, inColour)
        {
        }

        /// <summary>
        /// Allows us to get the position of the object if necessary
        /// </summary>
        /// <returns></returns>
        public Vector2 GetTilePosition {get; set;}

        public string TileType { get; set; }
    }
}
