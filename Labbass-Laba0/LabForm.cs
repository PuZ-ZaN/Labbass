using Labbass_Laba0.Properties;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
                        if(!checkBounds(MeasuringObject.Bounds, MovableFrame.Bounds))
                            if (MovableFrame.Location.X >= 195)
                                MovableFrame.Location = new Point(MovableFrame.Location.X - 1, MovableFrame.Location.Y);
                        break;
                    };
                case (char)Keys.D:
                    {
                        if (!checkBounds(MovableFrame.Bounds, MeasuringObject.Bounds))
                            if (MovableFrame.Location.X < 447)
                                MovableFrame.Location = new Point(MovableFrame.Location.X + 1, MovableFrame.Location.Y);
                        break;
                    };
                default:
                    break;
            }
        }

        private bool checkBounds(Rectangle rect1, Rectangle rect2)
        {
            Rectangle rect3 = Rectangle.Intersect(rect1, rect2);
            if (!rect3.IsEmpty)
                return ((rect1.Width * rect1.Height) / 4) >= rect3.Width * rect3.Height;
            else return false;
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.pdfViewer1.LoadFromStream(new MemoryStream(Resources.shtang));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.pdfViewer1.LoadFromStream(new MemoryStream(Resources.micr));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.pdfViewer1.LoadFromStream(new MemoryStream(Resources.metod));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.pdfViewer1.LoadFromStream(new MemoryStream(Resources.otchet_form));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF файлы(*.pdf) | *.pdf | Все файлы(*.*) | *.* ";
            saveFileDialog.DefaultExt = "pdf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(saveFileDialog.FileName, Resources.otchet_form);
                Process.Start(Path.GetDirectoryName(saveFileDialog.FileName));
            }
        }

        private void MeasuringObject_LocationChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("dawwadaw");
            label2.Text = MeasuringObject.Location.X.ToString() + " " + MeasuringObject.Location.Y.ToString();
        }
    }
}
