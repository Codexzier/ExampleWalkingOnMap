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

        public ComponentMap ComponentContent => this._componentMap;

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
            this.FpsResult = this.GetFramesPerSecound(gameTime);

            this.GraphicsDevice.Clear(Color.DarkBlue);

            this._spriteBatch.Begin();

            this._componentMap.DrawMapTiles(this._spriteBatch);

            this._spriteBatch.End();
        }

        #region Debug information

        private int _framecount;
        private float _secounds;
        private float _lastFps = 0;

        public float FpsResult { get; private set; }

        private float GetFramesPerSecound(GameTime gameTime)
        {
            this._framecount++;
            this._secounds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (this._framecount >= 10)
            {
                this._lastFps = this._secounds / this._framecount;
                this._framecount = 0;
                this._secounds = 0;
            }

            float frames = 1 / this._lastFps;

            if (float.IsInfinity(frames))
            {
                frames = 1;
            }

            return frames;
        }

        #endregion
    }
}
