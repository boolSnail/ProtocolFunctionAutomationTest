namespace ProtocolFunctionAutomationTest
{
    partial class Setting
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
            this.components = new System.ComponentModel.Container();
            this.buttonTurnt1 = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonTurnt3 = new System.Windows.Forms.Button();
            this.textBoxT1 = new System.Windows.Forms.TextBox();
            this.textBoxT3 = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.buttonTurnt2 = new System.Windows.Forms.Button();
            this.textBoxT2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPA = new System.Windows.Forms.TextBox();
            this.buttonSet = new System.Windows.Forms.Button();
            this.numericUpDownT1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownT2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownT3 = new System.Windows.Forms.NumericUpDown();
            this.buttonSetT3 = new System.Windows.Forms.Button();
            this.buttonSetT1 = new System.Windows.Forms.Button();
            this.buttonSetT2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownT1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownT2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownT3)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonTurnt1
            // 
            this.buttonTurnt1.Location = new System.Drawing.Point(33, 23);
            this.buttonTurnt1.Name = "buttonTurnt1";
            this.buttonTurnt1.Size = new System.Drawing.Size(81, 23);
            this.buttonTurnt1.TabIndex = 0;
            this.buttonTurnt1.Text = "Turn Off t1";
            this.buttonTurnt1.UseVisualStyleBackColor = true;
            this.buttonTurnt1.Click += new System.EventHandler(this.buttonTurnt1_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(401, 313);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonTurnt3
            // 
            this.buttonTurnt3.Location = new System.Drawing.Point(33, 143);
            this.buttonTurnt3.Name = "buttonTurnt3";
            this.buttonTurnt3.Size = new System.Drawing.Size(81, 23);
            this.buttonTurnt3.TabIndex = 2;
            this.buttonTurnt3.Text = "Turn Off t3";
            this.buttonTurnt3.UseVisualStyleBackColor = true;
            this.buttonTurnt3.Click += new System.EventHandler(this.buttonTurnt3_Click);
            // 
            // textBoxT1
            // 
            this.textBoxT1.Location = new System.Drawing.Point(120, 25);
            this.textBoxT1.Name = "textBoxT1";
            this.textBoxT1.ReadOnly = true;
            this.textBoxT1.Size = new System.Drawing.Size(35, 21);
            this.textBoxT1.TabIndex = 3;
            // 
            // textBoxT3
            // 
            this.textBoxT3.Location = new System.Drawing.Point(120, 145);
            this.textBoxT3.Name = "textBoxT3";
            this.textBoxT3.ReadOnly = true;
            this.textBoxT3.Size = new System.Drawing.Size(35, 21);
            this.textBoxT3.TabIndex = 4;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // buttonTurnt2
            // 
            this.buttonTurnt2.Enabled = false;
            this.buttonTurnt2.Location = new System.Drawing.Point(33, 85);
            this.buttonTurnt2.Name = "buttonTurnt2";
            this.buttonTurnt2.Size = new System.Drawing.Size(81, 21);
            this.buttonTurnt2.TabIndex = 5;
            this.buttonTurnt2.Text = "Turn Off t2";
            this.buttonTurnt2.UseVisualStyleBackColor = true;
            this.buttonTurnt2.Click += new System.EventHandler(this.buttonTurnt2_Click);
            // 
            // textBoxT2
            // 
            this.textBoxT2.Location = new System.Drawing.Point(120, 86);
            this.textBoxT2.Name = "textBoxT2";
            this.textBoxT2.ReadOnly = true;
            this.textBoxT2.Size = new System.Drawing.Size(35, 21);
            this.textBoxT2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "Public Address:";
            // 
            // textBoxPA
            // 
            this.textBoxPA.Location = new System.Drawing.Point(132, 230);
            this.textBoxPA.Name = "textBoxPA";
            this.textBoxPA.Size = new System.Drawing.Size(100, 21);
            this.textBoxPA.TabIndex = 8;
            // 
            // buttonSet
            // 
            this.buttonSet.Location = new System.Drawing.Point(260, 229);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(46, 20);
            this.buttonSet.TabIndex = 9;
            this.buttonSet.Text = "Set";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // numericUpDownT1
            // 
            this.numericUpDownT1.Location = new System.Drawing.Point(211, 25);
            this.numericUpDownT1.Name = "numericUpDownT1";
            this.numericUpDownT1.Size = new System.Drawing.Size(61, 21);
            this.numericUpDownT1.TabIndex = 10;
            this.numericUpDownT1.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // numericUpDownT2
            // 
            this.numericUpDownT2.Location = new System.Drawing.Point(211, 87);
            this.numericUpDownT2.Name = "numericUpDownT2";
            this.numericUpDownT2.Size = new System.Drawing.Size(61, 21);
            this.numericUpDownT2.TabIndex = 11;
            this.numericUpDownT2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDownT3
            // 
            this.numericUpDownT3.Location = new System.Drawing.Point(211, 146);
            this.numericUpDownT3.Name = "numericUpDownT3";
            this.numericUpDownT3.Size = new System.Drawing.Size(61, 21);
            this.numericUpDownT3.TabIndex = 12;
            this.numericUpDownT3.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // buttonSetT3
            // 
            this.buttonSetT3.Location = new System.Drawing.Point(305, 146);
            this.buttonSetT3.Name = "buttonSetT3";
            this.buttonSetT3.Size = new System.Drawing.Size(46, 22);
            this.buttonSetT3.TabIndex = 13;
            this.buttonSetT3.Text = "Set";
            this.buttonSetT3.UseVisualStyleBackColor = true;
            this.buttonSetT3.Click += new System.EventHandler(this.buttonSetT3_Click);
            // 
            // buttonSetT1
            // 
            this.buttonSetT1.Location = new System.Drawing.Point(305, 25);
            this.buttonSetT1.Name = "buttonSetT1";
            this.buttonSetT1.Size = new System.Drawing.Size(46, 22);
            this.buttonSetT1.TabIndex = 14;
            this.buttonSetT1.Text = "Set";
            this.buttonSetT1.UseVisualStyleBackColor = true;
            this.buttonSetT1.Click += new System.EventHandler(this.buttonSetT1_Click);
            // 
            // buttonSetT2
            // 
            this.buttonSetT2.Location = new System.Drawing.Point(305, 87);
            this.buttonSetT2.Name = "buttonSetT2";
            this.buttonSetT2.Size = new System.Drawing.Size(46, 22);
            this.buttonSetT2.TabIndex = 15;
            this.buttonSetT2.Text = "Set";
            this.buttonSetT2.UseVisualStyleBackColor = true;
            this.buttonSetT2.Click += new System.EventHandler(this.buttonSetT2_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 357);
            this.Controls.Add(this.buttonSetT2);
            this.Controls.Add(this.buttonSetT1);
            this.Controls.Add(this.buttonSetT3);
            this.Controls.Add(this.numericUpDownT3);
            this.Controls.Add(this.numericUpDownT2);
            this.Controls.Add(this.numericUpDownT1);
            this.Controls.Add(this.buttonSet);
            this.Controls.Add(this.textBoxPA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxT2);
            this.Controls.Add(this.buttonTurnt2);
            this.Controls.Add(this.textBoxT3);
            this.Controls.Add(this.textBoxT1);
            this.Controls.Add(this.buttonTurnt3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonTurnt1);
            this.Name = "Setting";
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.Setting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownT1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownT2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownT3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTurnt1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonTurnt3;
        private System.Windows.Forms.TextBox textBoxT1;
        private System.Windows.Forms.TextBox textBoxT3;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button buttonTurnt2;
        private System.Windows.Forms.TextBox textBoxT2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPA;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.NumericUpDown numericUpDownT1;
        private System.Windows.Forms.NumericUpDown numericUpDownT2;
        private System.Windows.Forms.NumericUpDown numericUpDownT3;
        private System.Windows.Forms.Button buttonSetT3;
        private System.Windows.Forms.Button buttonSetT1;
        private System.Windows.Forms.Button buttonSetT2;
    }
}