using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BounceNew
{
    public class HorizontalWall : Shape
    {
        public HorizontalWall(int x, int y, int width) : base(x, y, width, 1, Color.Green) { }

        public override void ModifySpeed(Ball ball)
        {
            ball.Speed = new PointF(ball.Speed.X, -ball.Speed.Y);
        }
    }

}
