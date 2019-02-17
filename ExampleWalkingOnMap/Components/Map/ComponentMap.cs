using ExampleWalkingOnMap.Components.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace ExampleWalkingOnMap.Components.Map
{
    public class ComponentMap : GameComponent
    {
        private readonly ComponentInputs _inputs;
        private GroundTile[,] _mapTiles;
        private Texture2D _textureMapTiles;
        private int _mapTileWidth, _mapTileHeight;

        /// <summary>
        ///     This screen offset need to center the middle postion of the window.
        /// </summary>
        private Vector2 _screenOffset;

        /// <summary>
        ///     actual own position.
        /// </summary>
        private Vector2 _movePosition;

        /// <summary>
        ///     Get actual Position with screen offset.
        /// </summary>
        public Vector2 Position => new Vector2(this._movePosition.X + this._screenOffset.X,
                                               this._movePosition.Y + this._screenOffset.Y);

        /// <summary>
        ///     Count of map pixel width.
        /// </summary>
        private int _mapWidth;

        /// <summary>
        ///     Count of map pixel height.
        /// </summary>
        private int _mapHeight;

        public ComponentMap(Game game, ComponentInputs inputs) : base(game) => this._inputs = inputs;

        #region For test content

        private GroundTile[,] _mapTiles2;
        private int _mapWidth2;
        private int _mapHeight2;

        private GroundTile[,] _mapTiles3;
        private int _mapWidth3;
        private int _mapHeight3;

        private Stopwatch _stopwatch = new Stopwatch();
        private int _resetStopWatchSec = 1;

        private int _step = 0;
        private int _mode = 2;

        private float _moveX = 1f;
        private float _moveY = 1f;

        private float _rotateX = .1f;
        private float _rotateY = .1f;
        private float _rotate = 0f;

        public int ShowObjects { get; set; }

        public int Mode => this._mode;
        public float _scale = .5f;

        #endregion

        /// <summary>
        ///     Set the actual windows size to set the actual position in the middle.
        /// </summary>
        /// <param name="screenWidth">Set the width screen.</param>
        /// <param name="screenHeight">Set the height screen.</param>
        internal void SetScreenOffset(float screenWidth, float screenHeight)
        {
            var centerScreenWidth = screenWidth / 2;
            var centerScreenHeight = screenHeight / 2;
            this._screenOffset = new Vector2(centerScreenWidth, centerScreenHeight);
            this._movePosition = new Vector2(0, 0);
        }

        public override void Initialize()
        {
            using (var stream = TitleContainer.OpenStream("Content/MapTiles.png"))
            {
                this._textureMapTiles = Texture2D.FromStream(this.Game.GraphicsDevice, stream);
            }

            // Create map or you can load a map.
            this._mapTiles = MapHelper.CreateMap(3);
            this._mapTiles2 = MapHelper.CreateMap(10);
            this._mapTiles3 = MapHelper.CreateMap(20);

            // size of the bitmap and count of contains tiles.
            // tile pixel width and height
            this._mapTileWidth = this._textureMapTiles.Width / 2;
            this._mapTileHeight = this._textureMapTiles.Height / 2;

            // pixel width and height of the map
            this._mapWidth = this._mapTileWidth * this._mapTiles.GetLength(0);
            this._mapHeight = this._mapTileHeight * this._mapTiles.GetLength(1);

            this._mapWidth2 = this._mapTileWidth * this._mapTiles2.GetLength(0);
            this._mapHeight2 = this._mapTileHeight * this._mapTiles2.GetLength(1);

            this._mapWidth3 = this._mapTileWidth * this._mapTiles3.GetLength(0);
            this._mapHeight3 = this._mapTileHeight * this._mapTiles3.GetLength(1);

            this._stopwatch.Start();
        }

        /// <summary>
        ///     Update the actual position by using the inputs.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (this._stopwatch.Elapsed.Seconds >= this._resetStopWatchSec)
            {
                if (this._step >= 9)
                {
                    this._step = 0;

                    if (this._mode >= 2)
                    {
                        this._mode = 0;
                    }
                    else
                    {
                        this._mode++;
                    }

                    this._movePosition = new Vector2();
                    this._rotate = 0f;
                }
                else
                {
                    this._step++;
                }

                this._stopwatch.Restart();
            }

            var tiles = this.GetTiles();

            this.ShowObjects = tiles.Length;

            float moveX = 0f;
            float moveY = 0f;
            float rotateX = 0f;
            float rotateY = 0f;
            float rotateZ = 0f;

            switch (this._step)
            {
                case (0):
                    {
                        moveX += this._moveX;
                        break;
                    }
                case (1):
                    {
                        moveY += this._moveY;
                        break;
                    }
                case (2):
                    {
                        moveX -= this._moveX;
                        break;
                    }
                case (3):
                    {
                        moveY -= this._moveY;
                        break;
                    }
                case (4):
                    {
                        rotateX += this._rotateX;
                        break;
                    }
                case (5):
                    {
                        rotateY += this._rotateY;
                        break;
                    }
                case (6):
                    {
                        rotateX -= this._rotateX;
                        break;
                    }
                case (7):
                    {
                        rotateY -= this._rotateY;
                        break;
                    }
                case (8):
                    {
                        moveX -= this._moveX;
                        moveY -= this._moveY;
                        rotateX -= this._rotateX;
                        rotateY -= this._rotateY;
                        rotateZ -= 2;
                        break;
                    }
                case (9):
                    {
                        moveX += this._moveX;
                        moveY += this._moveY;
                        rotateX += this._rotateX;
                        rotateY += this._rotateY;
                        rotateZ += 2;
                        break;
                    }
                default:
                    break;
            }


            this._movePosition += new Vector2(moveX, moveY);
            this._rotate +=  rotateX + rotateY;
        }

        private GroundTile[,] GetTiles() 
        {
            GroundTile[,] tilesTmp;
            switch (this._mode)
            {
                case 0:
                    tilesTmp = this._mapTiles;
                    break;
                case 1:
                    tilesTmp = this._mapTiles2;
                    break;
                case 2:
                    tilesTmp = this._mapTiles3;
                    break;
                default:
                    tilesTmp = new  GroundTile[0,0];
                    break;
            }

            return tilesTmp;
        }

        /// <summary>
        ///     Draw all tiles to screen.
        /// </summary>
        /// <param name="spriteBatch">Set a open spriteBatch for draw.</param>
        public void DrawMapTiles(SpriteBatch spriteBatch)
        {
            var mapTiles = this.GetTiles();

            for (int iY = 0; iY < mapTiles.GetLength(0); iY++)
            {
                for (int iX = 0; iX < mapTiles.GetLength(1); iX++)
                {
                    Vector2 textureOffset = new Vector2(iX * (this._mapTileWidth + 3), iY * (this._mapTileHeight + 3)) * this._scale;
                    Vector2 offset = this.Position + textureOffset;

                    mapTiles[iY, iX].Draw(this._textureMapTiles, spriteBatch, offset, this._rotate, this._scale);
                }
            }
        }
    }
}
