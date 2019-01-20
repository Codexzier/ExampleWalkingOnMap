using ExampleWalkingOnMap.Components.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ExampleWalkingOnMap.Components.Map
{
    public class ComponentMap : GameComponent
    {
        private readonly ComponentInputs _inputs;
        private GroundTile[,] _mapTiles;
        private Texture2D _textureMapTiles;
        private int _mapTileWidth, _mapTileHeight;

        private Vector2 _screenOffset, _movePosition;
        public Vector2 Position => new Vector2(this._movePosition.X + this._screenOffset.X,
                                               this._movePosition.Y + this._screenOffset.Y);

        private int _mapWidth,  _mapHeight;

        public ComponentMap(Game game, ComponentInputs inputs) : base(game) => this._inputs = inputs;

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

            this._mapTiles = MapHelper.CreateMap();
            this._mapTileWidth = this._textureMapTiles.Width / 2;
            this._mapTileHeight = this._textureMapTiles.Height / 2;
            this._mapWidth = this._mapTileWidth * this._mapTiles.GetLength(0);
            this._mapHeight = this._mapTileHeight * this._mapTiles.GetLength(1);
        }

        public override void Update(GameTime gameTime)
        {
            this._movePosition += this._inputs.Inputs.Move * 2f;
        }

        public void DrawMapTiles(SpriteBatch spriteBatch)
        {
            for (int iY = 0; iY < this._mapTiles.GetLength(0); iY++)
            {
                for (int iX = 0; iX < this._mapTiles.GetLength(1); iX++)
                {
                    Vector2 textureOffset = new Vector2(iX * this._mapTileWidth, iY * this._mapTileHeight);
                    Vector2 offset = this.Position + textureOffset;

                    this._mapTiles[iY, iX].Draw(this._textureMapTiles, spriteBatch, offset);
                }
            }
        }
    }
}
