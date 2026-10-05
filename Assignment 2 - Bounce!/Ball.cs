using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BounceNew
{
    public class Ball
    {
        private static Random random = new Random();
        public PointF Position { get; private set; }
        public PointF Speed { get; set; }
        public float Radius { get; }

        private Pen pen = new Pen(Color.Black);

        public Ball(float x, float y, float radius)
        {
            Position = new PointF(x, y);
            Speed = new PointF(random.Next(1, 6) * (random.Next(2) == 0 ? 1 : -1), random.Next(1, 6) * (random.Next(2) == 0 ? 1 : -1));
            Radius = radius;
        }

        public void Draw(Graphics g)
        {
            g.DrawEllipse(pen, Position.X - Radius, Position.Y - Radius, 2 * Radius, 2 * Radius);
        }

        public void Move()
        {
            Position = new PointF(Position.X + Speed.X, Position.Y + Speed.Y);
        }
    }
}
