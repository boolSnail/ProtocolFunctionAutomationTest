namespace ProtocolFunctionAutomationTest
{
    partial class GeneralTelegraph
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
            this.buttonStartDT = new System.Windows.Forms.Button();
            this.buttonStopDT = new System.Windows.Forms.Button();
            this.buttonTestFR = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonCall = new System.Windows.Forms.Button();
            this.buttonSConfirm = new System.Windows.Forms.Button();
            this.button46 = new System.Windows.Forms.Button();
            this.button48 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStartDT
            // 
            this.buttonStartDT.Location = new System.Drawing.Point(35, 26);
            this.buttonStartDT.Name = "buttonStartDT";
            this.buttonStartDT.Size = new System.Drawing.Size(75, 23);
            this.buttonStartDT.TabIndex = 0;
            this.buttonStartDT.Text = "STARTDT";
            this.buttonStartDT.UseVisualStyleBackColor = true;
            this.buttonStartDT.Click += new System.EventHandler(this.buttonStartDT_Click);
            // 
            // buttonStopDT
            // 
            this.buttonStopDT.Location = new System.Drawing.Point(35, 55);
            this.buttonStopDT.Name = "buttonStopDT";
            this.buttonStopDT.Size = new System.Drawing.Size(75, 23);
            this.buttonStopDT.TabIndex = 1;
            this.buttonStopDT.Text = "STOPDT";
            this.buttonStopDT.UseVisualStyleBackColor = true;
            this.buttonStopDT.Click += new System.EventHandler(this.buttonStopDT_Click);
            // 
            // buttonTestFR
            // 
            this.buttonTestFR.Location = new System.Drawing.Point(35, 84);
            this.buttonTestFR.Name = "buttonTestFR";
            this.buttonTestFR.Size = new System.Drawing.Size(75, 23);
            this.buttonTestFR.TabIndex = 2;
            this.buttonTestFR.Text = "TESTFR";
            this.buttonTestFR.UseVisualStyleBackColor = true;
            this.buttonTestFR.Click += new System.EventHandler(this.buttonTestFR_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(158, 314);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonCall
            // 
            this.buttonCall.Location = new System.Drawing.Point(35, 113);
            this.buttonCall.Name = "buttonCall";
            this.buttonCall.Size = new System.Drawing.Size(75, 23);
            this.buttonCall.TabIndex = 4;
            this.buttonCall.Text = "CALL";
            this.buttonCall.UseVisualStyleBackColor = true;
            this.buttonCall.Click += new System.EventHandler(this.buttonCall_Click);
            // 
            // buttonSConfirm
            // 
            this.buttonSConfirm.Location = new System.Drawing.Point(35, 142);
            this.buttonSConfirm.Name = "buttonSConfirm";
            this.buttonSConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonSConfirm.TabIndex = 5;
            this.buttonSConfirm.Text = "S Confirm";
            this.buttonSConfirm.UseVisualStyleBackColor = true;
            this.buttonSConfirm.Click += new System.EventHandler(this.buttonSConfirm_Click);
            // 
            // button46
            // 
            this.button46.Location = new System.Drawing.Point(149, 26);
            this.button46.Name = "button46";
            this.button46.Size = new System.Drawing.Size(84, 23);
            this.button46.TabIndex = 6;
            this.button46.Text = "46C_DC_NA_1";
            this.button46.UseVisualStyleBackColor = true;
            this.button46.Click += new System.EventHandler(this.button46_Click);
            // 
            // button48
            // 
            this.button48.Location = new System.Drawing.Point(149, 55);
            this.button48.Name = "button48";
            this.button48.Size = new System.Drawing.Size(84, 23);
            this.button48.TabIndex = 7;
            this.button48.Text = "48C_SE_NA_1";
            this.button48.UseVisualStyleBackColor = true;
            this.button48.Click += new System.EventHandler(this.button48_Click);
            // 
            // GeneralTelegraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 382);
            this.Controls.Add(this.button48);
            this.Controls.Add(this.button46);
            this.Controls.Add(this.buttonSConfirm);
            this.Controls.Add(this.buttonCall);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonTestFR);
            this.Controls.Add(this.buttonStopDT);
            this.Controls.Add(this.buttonStartDT);
            this.Name = "GeneralTelegraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GeneralTelegraph";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStartDT;
        private System.Windows.Forms.Button buttonStopDT;
        private System.Windows.Forms.Button buttonTestFR;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonCall;
        private System.Windows.Forms.Button buttonSConfirm;
        private System.Windows.Forms.Button button46;
        private System.Windows.Forms.Button button48;
    }
}