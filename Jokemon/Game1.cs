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
        private Tile[,] tileArray;
        private char[,] tileValuesArray;

        Texture2D treeTexture, logTexture, blankTexture, houseTexture, labTexture, signBig, signSmall, postBox, flower, playerM, playerF;


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

        //This is a test comment

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            tileArray = new Tile[MapReader.MapSize, MapReader.MapSize];
            tileValuesArray = MapReader.ReadFile(@"C:\Users\sknott\source\repos\Jokemon\Jokemon\Content\TileMap");

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
            signBig = Content.Load<Texture2D>("Sign_Big"); //14x20
            signSmall = Content.Load<Texture2D>("Sign_Little"); //14x17
            postBox = Content.Load<Texture2D>("Postbox"); //10x20
            logTexture = Content.Load<Texture2D>("Logs");//20x12
            flower = Content.Load<Texture2D>("Flower_Red");//14x10

            

            leftHouse = new Building(houseTexture, new Vector2(80, 64), new Vector2(80, 64), Color.White);
            lab = new Building(labTexture, new Vector2(212, 192), new Vector2(108, 64), Color.White);
            rightHouse = new Building(houseTexture, new Vector2(240, 64), new Vector2(80, 64), Color.White);

            //Read in the file and create a tile map from it for the background & objects
            CreateMap();
                        
            
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
                        tileArray[i, j] = new Tile(treeTexture, tempPosition, new Vector2(32, 40), Color.White);
                    }
                    else if (tileValuesArray[i, j] == '2')
                    {
                        tileArray[i, j] = new Tile(postBox, new Vector2(tempPosition.X + postBox.Width / 2, tempPosition.Y + postBox.Height / 2), new Vector2(postBox.Width, postBox.Height), Color.White);
                    }
                    else if (tileValuesArray[i, j] == '3')
                    {
                        tileArray[i, j] = new Tile(logTexture, new Vector2(tempPosition.X, tempPosition.Y + logTexture.Height / 2), new Vector2(32, 12), Color.White);
                    }
                    else if (tileValuesArray[i, j] == '4')
                    {
                        tileArray[i, j] = new Tile(signBig, tempPosition, new Vector2(32, 20), Color.White);
                    }
                    else if (tileValuesArray[i, j] == '5')
                    {
                        tileArray[i, j] = new Tile(flower, tempPosition, new Vector2(flower.Width * 1.5f, flower.Height * 1.5f), Color.White);
                    }
                    else if (tileValuesArray[i, j] == '6')
                    {
                        tileArray[i, j] = new Tile(signSmall, tempPosition, new Vector2(signBig.Width, signBig.Height), Color.White);
                    }
                    else
                    {
                        tileArray[i, j] = new Tile(blankTexture, tempPosition, new Vector2(32, 40), Color.White);
                    }
                }
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (leftHouse.CheckCollided(rightHouse))
            { 
                //Do stuff.
            }

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
