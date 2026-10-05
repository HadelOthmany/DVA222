using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BounceNew
{
    public class VerticalWall : Shape
    {
        public VerticalWall(int x, int y, int height) : base(x, y, 1, height, Color.Green) { }

        public override void ModifySpeed(Ball ball)
        {
            ball.Speed = new PointF(-ball.Speed.X, ball.Speed.Y);
        }
    }
}
