using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ExampleWalkingOnMap.Components.Map
{
    /// <summary>
    ///     Ground tile contains the texture position.
    /// </summary>
    public class GroundTile
    {
        /// <summary>
        ///     Contains the information to get a explicit frame from the bitmap.
        /// </summary>
        private Rectangle _texturePosition;

        /// <summary>
        ///     Base contructor
        /// </summary>
        /// <param name="x">Set the begin x position.</param>
        /// <param name="y">Set the begin y position.</param>
        /// <param name="width">Set the width of the tile.</param>
        /// <param name="height">Set the height of the tile.</param>
        public GroundTile(int x, int y, int width, int height)
        {
            this._texturePosition = new Rectangle(x, y, width, height);
        }

        /// <summary>
        ///     Draw the tile on the screen by getting the asset information of this object.
        /// </summary>
        /// <param name="textureMapTiles">the texture with all tiles.</param>
        /// <param name="spriteBatch">for draw on the screen</param>
        /// <param name="offset">the offset is the actual relative position from own moving postion.</param>
        public void Draw(Texture2D textureMapTiles, SpriteBatch spriteBatch, Vector2 offset)
        {
            spriteBatch.Draw(textureMapTiles,
                             offset,
                             this._texturePosition,
                             Color.White,
                             0f,
                             new Vector2(0, 0),
                             new Vector2(1, 1),
                             SpriteEffects.None,
                             0f);
        }
    }
}
