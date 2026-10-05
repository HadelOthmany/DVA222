using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BounceNew
{
    public interface IShape
    {
        void CheckCollision(Ball ball);
        void Draw(Graphics g);
    }

}
