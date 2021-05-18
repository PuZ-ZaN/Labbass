
namespace Labbass_Laba0
{
    partial class LabForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.MeasuringObject = new System.Windows.Forms.PictureBox();
            this.MovableFrame = new System.Windows.Forms.PictureBox();
            this.StaticFrame = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MeasuringObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MovableFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StaticFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(723, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(797, 408);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.MeasuringObject);
            this.tabPage1.Controls.Add(this.MovableFrame);
            this.tabPage1.Controls.Add(this.StaticFrame);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(789, 382);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Штангенциркуль";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(789, 382);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Микрометр";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MeasuringObject
            // 
            this.MeasuringObject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MeasuringObject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MeasuringObject.Image = global::Labbass_Laba0.Properties.Resources.груз2;
            this.MeasuringObject.Location = new System.Drawing.Point(21, 286);
            this.MeasuringObject.Name = "MeasuringObject";
            this.MeasuringObject.Size = new System.Drawing.Size(90, 51);
            this.MeasuringObject.TabIndex = 7;
            this.MeasuringObject.TabStop = false;
            // 
            // MovableFrame
            // 
            this.MovableFrame.BackColor = System.Drawing.Color.Transparent;
            this.MovableFrame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MovableFrame.Cursor = System.Windows.Forms.Cursors.Default;
            this.MovableFrame.Image = global::Labbass_Laba0.Properties.Resources.штангенциркуль21;
            this.MovableFrame.Location = new System.Drawing.Point(388, 59);
            this.MovableFrame.Name = "MovableFrame";
            this.MovableFrame.Size = new System.Drawing.Size(186, 256);
            this.MovableFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MovableFrame.TabIndex = 3;
            this.MovableFrame.TabStop = false;
            // 
            // StaticFrame
            // 
            this.StaticFrame.BackgroundImage = global::Labbass_Laba0.Properties.Resources.штангенциркуль_осн2;
            this.StaticFrame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.StaticFrame.Location = new System.Drawing.Point(0, 19);
            this.StaticFrame.Name = "StaticFrame";
            this.StaticFrame.Size = new System.Drawing.Size(783, 360);
            this.StaticFrame.TabIndex = 2;
            this.StaticFrame.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(625, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "A, D - перемещение рамки";
            // 
            // LabForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.KeyPreview = true;
            this.Name = "LabForm";
            this.Text = "LabForm";
            this.Load += new System.EventHandler(this.LabForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LabForm_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MeasuringObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MovableFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StaticFrame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox MovableFrame;
        private System.Windows.Forms.PictureBox StaticFrame;
        private System.Windows.Forms.PictureBox MeasuringObject;
        private System.Windows.Forms.Label label1;
    }
}