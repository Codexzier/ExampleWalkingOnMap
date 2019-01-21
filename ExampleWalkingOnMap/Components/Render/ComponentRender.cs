using ExampleWalkingOnMap.Components.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Windows.UI.ViewManagement;

namespace ExampleWalkingOnMap.Components.Render
{
    /// <summary>
    ///     Draw all object to the screen.
    /// </summary>
    public class ComponentRender : DrawableGameComponent
    {
        private readonly ComponentMap _componentMap;
        private SpriteBatch _spriteBatch;

        public ComponentRender(Game game, ComponentMap componentMap) : base(game)
        {
            this._componentMap = componentMap;
        }

        public override void Initialize()
        {
            this._spriteBatch = new SpriteBatch(this.GraphicsDevice);

            // set the position to the middel of the screen
            var screenWidth = (float)ApplicationView.GetForCurrentView().VisibleBounds.Width;
            var screenHeight = (float)ApplicationView.GetForCurrentView().VisibleBounds.Height;
            this._componentMap.SetScreenOffset(screenWidth, screenHeight);
        }

        /// <summary>
        /// Draw all elements to screen.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.DarkBlue);

            this._spriteBatch.Begin();

            this._componentMap.DrawMapTiles(this._spriteBatch);

            this._spriteBatch.End();
        }
    }
}
