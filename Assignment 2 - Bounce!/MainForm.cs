using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BounceNew
{
    public class MainForm : Form
    {
        public MainForm()
        {
            this.DoubleBuffered = true;
            this.Width = 800;
            this.Height = 600;
        }
    }
}
