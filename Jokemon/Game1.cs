using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Jokemon
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private float tileSize;
        private Building leftHouse, rightHouse, lab;
        private List<ReadableObject> readableObjectList;
        private Tile[,] tileArray;
        private char[,] tileValuesArray;

        Texture2D treeTexture, blankTexture, houseTexture, labTexture, signBig, signSmall, postBox, flower, playerM, playerF;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 384;
            _graphics.PreferredBackBufferHeight = 390;
            tileSize = _graphics.PreferredBackBufferWidth / 12;
            MapReader.MapSize = 12;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            tileArray = new Tile[MapReader.MapSize, MapReader.MapSize];
            tileValuesArray = MapReader.ReadFile(@"C:\Users\sknott\source\repos\Jokemon\Jokemon\Content\TileMap");
            readableObjectList = new List<ReadableObject>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            // TODO: use this.Content to load your game content here
            treeTexture = Content.Load<Texture2D>("Tree_Big");
            blankTexture = Content.Load<Texture2D>("Blank");
            houseTexture = Content.Load<Texture2D>("house");
            labTexture = Content.Load<Texture2D>("Lab");
            signBig = Content.Load<Texture2D>("Sign_Big");
            signSmall = Content.Load<Texture2D>("Sign_Little");

            CreateMap();
            leftHouse = new Building(houseTexture, new Vector2(80, 64), new Vector2(80, 64), Color.White);
            lab = new Building(labTexture, new Vector2(212, 192), new Vector2(108, 64), Color.White);
            rightHouse = new Building(houseTexture, new Vector2(224, 64), new Vector2(80, 64), Color.White);
        }

        public void CreateMap()
        {
            Vector2 tempPosition;

            for (int i = 0; i <= tileValuesArray.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= tileValuesArray.GetUpperBound(1); j++)
                {
                    tempPosition = new Vector2(tileSize * i, tileSize * j);

                    if (tileValuesArray[i, j] == '1')
                    {
                        tileArray[i, j] = new Tile();
                        tileArray[i, j].SpriteTexture = treeTexture;
                        tileArray[i, j].SpriteColour = Color.White;
                        tileArray[i, j].SpriteSize = new Vector2(32, 40);
                        tileArray[i, j].SpritePosition = tempPosition;
                    }
                    else
                    {
                        tileArray[i, j] = new Tile();
                        tileArray[i, j].SpriteTexture = blankTexture;
                        tileArray[i, j].SpriteColour = Color.White;
                        tileArray[i, j].SpriteSize = new Vector2(32, 40);
                        tileArray[i, j].SpritePosition = tempPosition;
                    }
                }
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGreen);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            foreach(Tile aTile in tileArray)
            {
                aTile.Draw(_spriteBatch);
            }

            leftHouse.Draw(_spriteBatch);
            rightHouse.Draw(_spriteBatch);
            lab.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
