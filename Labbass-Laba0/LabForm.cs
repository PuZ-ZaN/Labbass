using Labbass_Laba0.Properties;
using Labbass_Laba0.Service;
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
        #region Micrometer

        private PrecisionLevel micrometerPrecisionLevel;
        private double micrometerValue;
        private MovementBuffer movementBuffer = new MovementBuffer()
        {
            ResetCondition = (value) => value > 1 || value < -1,
            ResetRule = (value) => 0
        };

        #endregion

        public LabForm()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            micrometerPrecisionLevel = PrecisionLevel.Create(trackBar1.Value);
            precisionValueLabel.Text = micrometerPrecisionLevel.ToString();
            SetTooltip();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void LabForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                MoveCaliperFrameByKey(e.KeyCode);
            }

            if (tabControl1.SelectedTab == tabPage2)
            {
                MoveMicrometerStamByKey(e.KeyCode);
            }
        }

        private void MoveMicrometerStamByKey(Keys key)
        {
            switch (key)
            {
                case Keys.A:
                {
                    if (!CheckBounds(MeasuringObject.Bounds, MicrometerStamPic.Bounds) && !CheckBounds(MicrometerStamPic.Bounds, invisibleBorder1.Bounds))
                    {
                        if (micrometerPrecisionLevel.PixelOffset < 1)
                            MoveStamUsingBuffer(-micrometerPrecisionLevel.PixelOffset);
                        else
                            MoveStamDirectly(-(int)micrometerPrecisionLevel.PixelOffset);
                        //MicrometerStamPic.Location = new Point(MicrometerStamPic.Location.X - movementBuffer.RoundedValue, MicrometerStamPic.Location.Y);
                        micrometerValue -= micrometerPrecisionLevel.VirtualValue;
                        micrometerValueLabel.Text = Math.Round(micrometerValue, 2).ToString();
                    }
                    break;
                }

                case Keys.D:
                {
                    if (!CheckBounds(MeasuringObject.Bounds, MicrometerStamPic.Bounds) && !CheckBounds(MicrometerStamPic.Bounds, invisibleBorder2.Bounds))
                    {
                        if (micrometerPrecisionLevel.PixelOffset < 1)
                            MoveStamUsingBuffer(micrometerPrecisionLevel.PixelOffset);
                        else
                            MoveStamDirectly((int)micrometerPrecisionLevel.PixelOffset);
                            //MicrometerStamPic.Location = new Point(MicrometerStamPic.Location.X + movementBuffer.RoundedValue, MicrometerStamPic.Location.Y);
                            micrometerValue += micrometerPrecisionLevel.VirtualValue;
                        micrometerValueLabel.Text = Math.Round(micrometerValue, 2).ToString();
                    }
                    break;
                }
            }
        }

        private void MoveStamDirectly(int dx)
        {
            MicrometerStamPic.Location = new Point(MicrometerStamPic.Location.X + dx, MicrometerStamPic.Location.Y);
        }

        private void MoveStamUsingBuffer(double dx)
        {
            movementBuffer.Increase(dx);
            var actualDx = movementBuffer.Use();
            MicrometerStamPic.Location = new Point(MicrometerStamPic.Location.X + actualDx, MicrometerStamPic.Location.Y);
        }

        private void MoveCaliperFrameByKey(Keys key)
        {
            switch (key)
            {
                case Keys.A:
                {
                    if (!CheckBounds(MeasuringObject.Bounds, MovableFrame.Bounds) && MovableFrame.Location.X >= 195)
                        MovableFrame.Location = new Point(MovableFrame.Location.X - 1, MovableFrame.Location.Y);
                    break;
                };
                case Keys.D:
                {
                    if (!CheckBounds(MovableFrame.Bounds, MeasuringObject.Bounds) && MovableFrame.Location.X < 447)
                        MovableFrame.Location = new Point(MovableFrame.Location.X + 1, MovableFrame.Location.Y);
                    break;
                };
            }
        }

        private bool CheckBounds(Rectangle rect1, Rectangle rect2)
        {
            Rectangle rect3 = Rectangle.Intersect(rect1, rect2);
            if (!rect3.IsEmpty)
                return ((rect1.Width * rect1.Height) / 4) >= rect3.Width * rect3.Height;
            return false;
        }

        private void LabForm_Load(object sender, EventArgs e)
        {
            ControlExtension.Draggable(MeasuringObject, true);
            ControlExtension.Draggable(MeasuringObject2, true);
            StaticFrame.Controls.Add(MovableFrame);
            StaticFrame.Controls.Add(MeasuringObject);
            MicrometerStatic.Controls.Add(invisibleBorder1);
            MicrometerStatic.Controls.Add(invisibleBorder2);
            MicrometerStatic.Controls.Add(MeasuringObject2);
            MovableFrame.BackColor = Color.Transparent;
            var shtang = Resources.штангенциркуль21;
            var microStam = Resources.micro_axis;
            var cylinder = Resources.груз2;
            var emptyImage = Resources.magicImage;
            var cylinderFront = Resources.CylinderFront;
            emptyImage.MakeTransparent(Color.White);
            cylinder.MakeTransparent(Color.White);
            microStam.MakeTransparent(Color.White);
            shtang.MakeTransparent(Color.White);
            cylinderFront.MakeTransparent(Color.White);
            MeasuringObject.Image = cylinderFront;
            invisibleBorder1.Image = emptyImage;
            MeasuringObject2.Image = cylinder;
            MovableFrame.Image = shtang;
            MovableFrame.SizeMode = PictureBoxSizeMode.Zoom;
            MicrometerStatic.Controls.Add(MicrometerStamPic);
            MicrometerStatic.BringToFront();
            MicrometerStamPic.BackColor = Color.Transparent;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //this.pdfViewer1.LoadFromStream(new MemoryStream(Resources.shtang));
            OpenDocumentationRoute(new MemoryStream(Resources.shtang));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.pdfViewer1.LoadFromStream(new MemoryStream(Resources.micr));
            OpenDocumentationRoute(new MemoryStream(Resources.micr));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //this.pdfViewer1.LoadFromStream(new MemoryStream(Resources.metod));
            OpenDocumentationRoute(new MemoryStream(Resources.metod));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //this.pdfViewer1.LoadFromStream(new MemoryStream(Resources.otchet_form));
            OpenDocumentationRoute(new MemoryStream(Resources.otchet_form));
        }

        private Task LoadPDF(MemoryStream dataSource)
        {
            return Task.Run(() =>
            { 
                Invoke(new Action(() => pdfViewer1.LoadFromStream(dataSource)));
                dataSource.Close();
            });
        }

        private async void OpenDocumentationRoute(MemoryStream dataSource)
        {
            if (isOpenInNewWIndowCheckbox.Checked)
                new DocForm(dataSource).Show();
            else
                await LoadPDF(dataSource);
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF файлы(*.pdf) | *.pdf | Все файлы(*.*) | *.* ";
            saveFileDialog.DefaultExt = "pdf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                await Task.Run(() =>
                {
                    File.WriteAllBytes(saveFileDialog.FileName, Resources.otchet_form);
                    Process.Start(Path.GetDirectoryName(saveFileDialog.FileName));
                });
            }
        }

        private void MeasuringObject_LocationChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("dawwadaw");
            label2.Text = MeasuringObject.Location.X.ToString() + " " + MeasuringObject.Location.Y.ToString();
        }

        private void ParseTrackbarValueToPrecisionLevel(object sender, EventArgs e)
        {
            micrometerPrecisionLevel = PrecisionLevel.Create(trackBar1.Value);
            precisionValueLabel.Text = micrometerPrecisionLevel.ToString();
        }

        private void SetTooltip()
        {
            toolTip1.SetToolTip(setZeroButton,
                @"
Для установки нулевого значения микрометра, уприте измерительный шток до конца влево, после чего нажмите кнопку '0'. 
Все дальнейшие показания микрометра будут рассчитываться исходя из значения этого нуля.
Если шкала микрометра показала отрицательное значение, выполните повторную калибровку прибора.
                ");
        }

        private void SetMicrometerZeroValue(object sender, EventArgs e)
        {
            micrometerValue = 0;
            micrometerValueLabel.Text = micrometerValue.ToString();
        }

        private class MovementBuffer
        {
            private enum Sign
            {
                Positive,
                Negative
            }

            private double accumulated;
            private Sign lastInceasedSign;

            public Func<double, bool> ResetCondition;
            public Func<double, double> ResetRule;

            public int RoundedValue
            { 
                get
                {
                    if (accumulated > 0)
                        return accumulated > 0.9 ? 1 : 0;
                    return accumulated < -0.9 ? -1 : 0;
                }
            }

            public void Increase(double value, bool autoreset = false)
            {
                var curSign = SignOf(value);
                if (curSign != lastInceasedSign)
                {
                    lastInceasedSign = curSign;
                    accumulated = value;
                }
                else
                    accumulated += value;

                if (ResetCondition(accumulated) && autoreset)
                    accumulated = ResetRule(accumulated);
            }

            public int Use()
            {
                var temp = RoundedValue;
                if (ResetCondition(accumulated))
                    accumulated = ResetRule(accumulated);
                return temp;
            }

            private Sign SignOf(double value)
            {
                return value >= 0 ? Sign.Positive : Sign.Negative;
            }
        }

        private void MeasuringObject2_LocationChanged(object sender, EventArgs e)
        {
            var newPos = MeasuringObject2.Location;
            xPosTextbox.Text = newPos.X.ToString();
            yPosTextbox.Text = newPos.Y.ToString();
        }
    }
}
