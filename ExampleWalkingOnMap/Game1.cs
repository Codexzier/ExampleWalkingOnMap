using ExampleWalkingOnMap.Components.Inputs;
using ExampleWalkingOnMap.Components.Map;
using ExampleWalkingOnMap.Components.Render;
using Microsoft.Xna.Framework;

namespace ExampleWalkingOnMap
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        private ComponentInputs _componentInputs;
        private ComponentMap _componentMap;
        private ComponentRender _componentRender;

        public Game1()
        {
            this._graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";

            this.Window.Title = "Example Walking on map";
            this.IsMouseVisible = true;


            this._componentInputs = new ComponentInputs(this);
            this._componentInputs.UpdateOrder = 1;
            this.Components.Add(this._componentInputs);

            this._componentMap = new ComponentMap(this, this._componentInputs);
            this._componentMap.UpdateOrder = 2;
            this.Components.Add(this._componentMap);

            this._componentRender = new ComponentRender(this, this._componentMap);
            this._componentRender.UpdateOrder = 3;
            this.Components.Add(this._componentRender);
        }
    }
}
