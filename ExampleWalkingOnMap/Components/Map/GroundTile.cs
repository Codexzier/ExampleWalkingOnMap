using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ExampleWalkingOnMap.Components.Map
{
    public class GroundTile
    {
        private Rectangle _texturePosition;

        public GroundTile(int x, int y, int width, int height)
        {
            this._texturePosition = new Rectangle(x, y, width, height);
        }

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
