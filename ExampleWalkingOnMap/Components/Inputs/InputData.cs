using Microsoft.Xna.Framework;

namespace ExampleWalkingOnMap.Components.Inputs
{
    public class InputData
    {
        public Vector2 Move => new Vector2(this.MoveX, this.MoveY);
        public float MoveX { get; set; }
        public float MoveY { get; set; }
    }
}
