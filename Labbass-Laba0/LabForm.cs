using Labbass_Laba0.Properties;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labbass_Laba0
{
    public partial class LabForm : Form
    {
        public LabForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void LabForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.A:
                    {
                        MovableFrame.Location = new Point(MovableFrame.Location.X - 1, MovableFrame.Location.Y);
                        break;
                    };
                case (char)Keys.D:
                    {
                        MovableFrame.Location = new Point(MovableFrame.Location.X + 1, MovableFrame.Location.Y);
                        break;
                    };
                default:
                    break;
            }
        }
        private void LabForm_Load(object sender, EventArgs e)
        {
            ControlExtension.Draggable(MeasuringObject, true);

            StaticFrame.Controls.Add(MovableFrame);
            MovableFrame.BackColor = Color.Transparent;
            var shtang = Resources.штангенциркуль21;
            shtang.MakeTransparent(Color.White);
            MovableFrame.Image = shtang;
            MovableFrame.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
