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
    }
}
