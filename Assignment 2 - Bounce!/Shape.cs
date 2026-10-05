using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BounceNew
{
    public abstract class Shape : IShape
    {
        protected Pen pen;
        protected RectangleF bounds;

        public Shape(int x, int y, int width, int height, Color color)
        {
            pen = new Pen(color, 3);
            bounds = new RectangleF(x, y, width, height);
        }

        public abstract void ModifySpeed(Ball ball);

        public void CheckCollision(Ball ball)
        {
            var ballBounds = new RectangleF(ball.Position.X - ball.Radius, ball.Position.Y - ball.Radius, 2 * ball.Radius, 2 * ball.Radius);
            if (bounds.IntersectsWith(ballBounds))
            {
                ModifySpeed(ball);
            }
        }

        public void Draw(Graphics g)
        {
            g.DrawRectangle(pen, bounds.X, bounds.Y, bounds.Width, bounds.Height);
        }
    }
}
