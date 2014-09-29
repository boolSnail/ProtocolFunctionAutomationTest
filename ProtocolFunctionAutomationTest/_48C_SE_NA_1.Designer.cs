namespace ProtocolFunctionAutomationTest
{
    partial class _48C_SE_NA_1
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPosition = new System.Windows.Forms.TextBox();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonNor = new System.Windows.Forms.RadioButton();
            this.buttonSet = new System.Windows.Forms.Button();
            this.buttonRevoke = new System.Windows.Forms.Button();
            this.radioButtonSFP = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Position:";
            // 
            // textBoxPosition
            // 
            this.textBoxPosition.Location = new System.Drawing.Point(101, 48);
            this.textBoxPosition.Name = "textBoxPosition";
            this.textBoxPosition.Size = new System.Drawing.Size(100, 21);
            this.textBoxPosition.TabIndex = 1;
            this.textBoxPosition.Text = "16385";
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(101, 92);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(100, 21);
            this.textBoxValue.TabIndex = 2;
            this.textBoxValue.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Value:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonSFP);
            this.groupBox1.Controls.Add(this.radioButtonNor);
            this.groupBox1.Location = new System.Drawing.Point(51, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 94);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Type";
            // 
            // radioButtonNor
            // 
            this.radioButtonNor.AutoSize = true;
            this.radioButtonNor.Checked = true;
            this.radioButtonNor.Location = new System.Drawing.Point(37, 20);
            this.radioButtonNor.Name = "radioButtonNor";
            this.radioButtonNor.Size = new System.Drawing.Size(101, 16);
            this.radioButtonNor.TabIndex = 0;
            this.radioButtonNor.TabStop = true;
            this.radioButtonNor.Text = "Normalization";
            this.radioButtonNor.UseVisualStyleBackColor = true;
            // 
            // buttonSet
            // 
            this.buttonSet.Location = new System.Drawing.Point(38, 260);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(75, 23);
            this.buttonSet.TabIndex = 1;
            this.buttonSet.Text = "Set";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // buttonRevoke
            // 
            this.buttonRevoke.Location = new System.Drawing.Point(172, 260);
            this.buttonRevoke.Name = "buttonRevoke";
            this.buttonRevoke.Size = new System.Drawing.Size(75, 23);
            this.buttonRevoke.TabIndex = 2;
            this.buttonRevoke.Text = "Revoke";
            this.buttonRevoke.UseVisualStyleBackColor = true;
            this.buttonRevoke.Click += new System.EventHandler(this.buttonRevoke_Click);
            // 
            // radioButtonSFP
            // 
            this.radioButtonSFP.AutoSize = true;
            this.radioButtonSFP.Location = new System.Drawing.Point(37, 43);
            this.radioButtonSFP.Name = "radioButtonSFP";
            this.radioButtonSFP.Size = new System.Drawing.Size(143, 16);
            this.radioButtonSFP.TabIndex = 1;
            this.radioButtonSFP.TabStop = true;
            this.radioButtonSFP.Text = "Short Floating Point";
            this.radioButtonSFP.UseVisualStyleBackColor = true;
            // 
            // _48C_SE_NA_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 329);
            this.Controls.Add(this.buttonSet);
            this.Controls.Add(this.buttonRevoke);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.textBoxPosition);
            this.Controls.Add(this.label1);
            this.Name = "_48C_SE_NA_1";
            this.Text = "_48C_SE_NA_1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPosition;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonNor;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.Button buttonRevoke;
        private System.Windows.Forms.RadioButton radioButtonSFP;
    }
}