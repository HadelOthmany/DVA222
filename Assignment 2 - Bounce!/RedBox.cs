using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BounceNew
{
    public class RedBox : Shape
    {
        public RedBox(int x, int y, int width, int height) : base(x, y, width, height, Color.Red) { }

        public override void ModifySpeed(Ball ball)
        {
            if (ball.Speed.X < 8 && ball.Speed.Y < 8)
            {
                ball.Speed = new PointF(ball.Speed.X * 1.1f, ball.Speed.Y * 1.1f);
            }
        }
    }
}
