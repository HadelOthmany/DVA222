using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BounceNew
{
    public class BlueBox : Shape
    {
        public BlueBox(int x, int y, int width, int height) : base(x, y, width, height, Color.Blue) { }

        public override void ModifySpeed(Ball ball)
        {
            if (ball.Speed.X > 0.8f && ball.Speed.Y > 0.8f)
            {
                ball.Speed = new PointF(ball.Speed.X * 0.8f, ball.Speed.Y * 0.8f);
            }
        }
    }
}
