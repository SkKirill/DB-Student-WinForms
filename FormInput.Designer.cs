
namespace LabNum6Task15
{
    partial class FormInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInput));
            this.сontrolPanel = new System.Windows.Forms.Panel();
            this.labelNameForm = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDownNumberStudent = new System.Windows.Forms.NumericUpDown();
            this.buttonOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.сontrolPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // сontrolPanel
            // 
            this.сontrolPanel.AutoSize = true;
            this.сontrolPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.сontrolPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.сontrolPanel.Controls.Add(this.labelNameForm);
            this.сontrolPanel.Controls.Add(this.pictureBox1);
            this.сontrolPanel.Controls.Add(this.buttonClose);
            this.сontrolPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.сontrolPanel.Location = new System.Drawing.Point(0, 0);
            this.сontrolPanel.Name = "сontrolPanel";
            this.сontrolPanel.Size = new System.Drawing.Size(250, 36);
            this.сontrolPanel.TabIndex = 2;
            this.сontrolPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.сontrolPanel_MouseDown);
            this.сontrolPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.сontrolPanel_MouseMove);
            this.сontrolPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.сontrolPanel_MouseUp);
            // 
            // labelNameForm
            // 
            this.labelNameForm.AutoSize = true;
            this.labelNameForm.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNameForm.ForeColor = System.Drawing.Color.White;
            this.labelNameForm.Location = new System.Drawing.Point(36, 9);
            this.labelNameForm.Name = "labelNameForm";
            this.labelNameForm.Size = new System.Drawing.Size(148, 24);
            this.labelNameForm.TabIndex = 4;
            this.labelNameForm.Text = "Введите номер";
            this.labelNameForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.сontrolPanel_MouseDown);
            this.labelNameForm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.сontrolPanel_MouseMove);
            this.labelNameForm.MouseUp += new System.Windows.Forms.MouseEventHandler(this.сontrolPanel_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(208, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(40, 34);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.numericUpDownNumberStudent);
            this.panel1.Controls.Add(this.buttonOk);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 89);
            this.panel1.TabIndex = 48;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // numericUpDownNumberStudent
            // 
            this.numericUpDownNumberStudent.BackColor = System.Drawing.Color.ForestGreen;
            this.numericUpDownNumberStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownNumberStudent.ForeColor = System.Drawing.Color.White;
            this.numericUpDownNumberStudent.Location = new System.Drawing.Point(128, 19);
            this.numericUpDownNumberStudent.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownNumberStudent.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNumberStudent.Name = "numericUpDownNumberStudent";
            this.numericUpDownNumberStudent.Size = new System.Drawing.Size(97, 22);
            this.numericUpDownNumberStudent.TabIndex = 67;
            this.numericUpDownNumberStudent.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonOk
            // 
            this.buttonOk.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOk.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.buttonOk.FlatAppearance.BorderSize = 0;
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOk.ForeColor = System.Drawing.Color.White;
            this.buttonOk.Location = new System.Drawing.Point(91, 47);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(134, 30);
            this.buttonOk.TabIndex = 57;
            this.buttonOk.Text = "Ввод";
            this.buttonOk.UseVisualStyleBackColor = false;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 48;
            this.label1.Text = "Номер студента:";
            // 
            // FormInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(250, 124);
            this.Controls.Add(this.сontrolPanel);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInput";
            this.Text = "Input";
            this.сontrolPanel.ResumeLayout(false);
            this.сontrolPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberStudent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel сontrolPanel;
        private System.Windows.Forms.Label labelNameForm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberStudent;
    }
}