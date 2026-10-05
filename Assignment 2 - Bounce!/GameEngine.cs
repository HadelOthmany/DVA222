using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BounceNew
{
    public class GameEngine
    {
        private MainForm mainForm = new MainForm();
        private Timer timer = new Timer();
        private List<Ball> balls = new List<Ball>();
        private List<IShape> shapes = new List<IShape>();
        private Random random = new Random();

        public void Run()
        {
            shapes.Add(new BlueBox(100, 400, 100, 100));
            shapes.Add(new BlueBox(400, 60, 120, 100));
            shapes.Add(new RedBox(100, 100, 100, 100));
            shapes.Add(new RedBox(500, 340, 150, 80));
            shapes.Add(new HorizontalWall(200, 20, 300));
            shapes.Add(new HorizontalWall(400, 550, 350));
            shapes.Add(new HorizontalWall(200, 100, 330));
            shapes.Add(new VerticalWall(20, 200, 350));
            shapes.Add(new VerticalWall(750, 300, 350));

            mainForm.Paint += Draw;
            timer.Tick += TimerEventHandler;
            timer.Interval = 1000 / 25;
            timer.Start();

            Application.Run(mainForm);
        }

        private void TimerEventHandler(object sender, EventArgs e)
        {
            if (random.Next(100) < 25)
            {
                balls.Add(new Ball(400, 300, 10));
            }

            foreach (var ball in balls)
            {
                ball.Move();
                foreach (var shape in shapes)
                {
                    shape.CheckCollision(ball);
                }
            }

            mainForm.Refresh();
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            foreach (var ball in balls)
            {
                ball.Draw(e.Graphics);
            }
            foreach (var shape in shapes)
            {
                shape.Draw(e.Graphics);
            }
        }
    }

}
