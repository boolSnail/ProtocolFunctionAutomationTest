namespace ProtocolFunctionAutomationTest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.buttonLock = new System.Windows.Forms.Button();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.listView1 = new ListViewNF();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button46 = new System.Windows.Forms.Button();
            this.button48 = new System.Windows.Forms.Button();
            this.buttonStartDT = new System.Windows.Forms.Button();
            this.buttonStopDT = new System.Windows.Forms.Button();
            this.buttonSConfirm = new System.Windows.Forms.Button();
            this.buttonTestFR = new System.Windows.Forms.Button();
            this.buttonCall = new System.Windows.Forms.Button();
            this.textBoxK = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxW = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSetting = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonTele = new System.Windows.Forms.Button();
            this.labelLinkstate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonFreeTele = new System.Windows.Forms.Button();
            this.buttonUnlink = new System.Windows.Forms.Button();
            this.buttonLink = new System.Windows.Forms.Button();
            this.timerListUpdate = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timerGeneral = new System.Windows.Forms.Timer(this.components);
            this.buttonInfoTable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonInfoTable);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxK);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxW);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSetting);
            this.splitContainer1.Panel2.Controls.Add(this.buttonClose);
            this.splitContainer1.Panel2.Controls.Add(this.buttonTele);
            this.splitContainer1.Panel2.Controls.Add(this.labelLinkstate);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.buttonFreeTele);
            this.splitContainer1.Panel2.Controls.Add(this.buttonUnlink);
            this.splitContainer1.Panel2.Controls.Add(this.buttonLink);
            this.splitContainer1.Size = new System.Drawing.Size(878, 549);
            this.splitContainer1.SplitterDistance = 442;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel1.Controls.Add(this.buttonLock);
            this.splitContainer2.Panel1.Controls.Add(this.buttonClearAll);
            this.splitContainer2.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.button46);
            this.splitContainer2.Panel2.Controls.Add(this.button48);
            this.splitContainer2.Panel2.Controls.Add(this.buttonStartDT);
            this.splitContainer2.Panel2.Controls.Add(this.buttonStopDT);
            this.splitContainer2.Panel2.Controls.Add(this.buttonSConfirm);
            this.splitContainer2.Panel2.Controls.Add(this.buttonTestFR);
            this.splitContainer2.Panel2.Controls.Add(this.buttonCall);
            this.splitContainer2.Size = new System.Drawing.Size(876, 440);
            this.splitContainer2.SplitterDistance = 728;
            this.splitContainer2.TabIndex = 0;
            // 
            // buttonLock
            // 
            this.buttonLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLock.Enabled = false;
            this.buttonLock.Location = new System.Drawing.Point(138, 417);
            this.buttonLock.Name = "buttonLock";
            this.buttonLock.Size = new System.Drawing.Size(75, 20);
            this.buttonLock.TabIndex = 2;
            this.buttonLock.Text = "Lock";
            this.buttonLock.UseVisualStyleBackColor = true;
            this.buttonLock.Click += new System.EventHandler(this.buttonLock_Click);
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClearAll.Location = new System.Drawing.Point(38, 417);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(75, 20);
            this.buttonClearAll.TabIndex = 1;
            this.buttonClearAll.Text = "ClearAll";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(-1, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(726, 413);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Index";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Comment";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Time";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Direction";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Content";
            this.columnHeader5.Width = 950;
            // 
            // button46
            // 
            this.button46.Location = new System.Drawing.Point(18, 156);
            this.button46.Name = "button46";
            this.button46.Size = new System.Drawing.Size(75, 23);
            this.button46.TabIndex = 13;
            this.button46.Text = "遥控";
            this.button46.UseVisualStyleBackColor = true;
            this.button46.Click += new System.EventHandler(this.button46_Click);
            // 
            // button48
            // 
            this.button48.Location = new System.Drawing.Point(18, 185);
            this.button48.Name = "button48";
            this.button48.Size = new System.Drawing.Size(75, 23);
            this.button48.TabIndex = 14;
            this.button48.Text = "置数命令";
            this.button48.UseVisualStyleBackColor = true;
            this.button48.Click += new System.EventHandler(this.button48_Click);
            // 
            // buttonStartDT
            // 
            this.buttonStartDT.Location = new System.Drawing.Point(18, 11);
            this.buttonStartDT.Name = "buttonStartDT";
            this.buttonStartDT.Size = new System.Drawing.Size(75, 23);
            this.buttonStartDT.TabIndex = 8;
            this.buttonStartDT.Text = "STARTDT";
            this.buttonStartDT.UseVisualStyleBackColor = true;
            this.buttonStartDT.Click += new System.EventHandler(this.buttonStartDT_Click);
            // 
            // buttonStopDT
            // 
            this.buttonStopDT.Location = new System.Drawing.Point(18, 40);
            this.buttonStopDT.Name = "buttonStopDT";
            this.buttonStopDT.Size = new System.Drawing.Size(75, 23);
            this.buttonStopDT.TabIndex = 9;
            this.buttonStopDT.Text = "STOPDT";
            this.buttonStopDT.UseVisualStyleBackColor = true;
            this.buttonStopDT.Click += new System.EventHandler(this.buttonStopDT_Click);
            // 
            // buttonSConfirm
            // 
            this.buttonSConfirm.Location = new System.Drawing.Point(18, 127);
            this.buttonSConfirm.Name = "buttonSConfirm";
            this.buttonSConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonSConfirm.TabIndex = 12;
            this.buttonSConfirm.Text = "S确认帧";
            this.buttonSConfirm.UseVisualStyleBackColor = true;
            this.buttonSConfirm.Click += new System.EventHandler(this.buttonSConfirm_Click);
            // 
            // buttonTestFR
            // 
            this.buttonTestFR.Location = new System.Drawing.Point(18, 69);
            this.buttonTestFR.Name = "buttonTestFR";
            this.buttonTestFR.Size = new System.Drawing.Size(75, 23);
            this.buttonTestFR.TabIndex = 10;
            this.buttonTestFR.Text = "TESTFR";
            this.buttonTestFR.UseVisualStyleBackColor = true;
            this.buttonTestFR.Click += new System.EventHandler(this.buttonTestFR_Click);
            // 
            // buttonCall
            // 
            this.buttonCall.Location = new System.Drawing.Point(18, 98);
            this.buttonCall.Name = "buttonCall";
            this.buttonCall.Size = new System.Drawing.Size(75, 23);
            this.buttonCall.TabIndex = 11;
            this.buttonCall.Text = "CALL";
            this.buttonCall.UseVisualStyleBackColor = true;
            this.buttonCall.Click += new System.EventHandler(this.buttonCall_Click);
            // 
            // textBoxK
            // 
            this.textBoxK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxK.Location = new System.Drawing.Point(632, 31);
            this.textBoxK.Name = "textBoxK";
            this.textBoxK.ReadOnly = true;
            this.textBoxK.Size = new System.Drawing.Size(43, 21);
            this.textBoxK.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(609, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "K：";
            // 
            // textBoxW
            // 
            this.textBoxW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxW.Location = new System.Drawing.Point(632, 55);
            this.textBoxW.Name = "textBoxW";
            this.textBoxW.ReadOnly = true;
            this.textBoxW.Size = new System.Drawing.Size(43, 21);
            this.textBoxW.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(609, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "W:";
            // 
            // buttonSetting
            // 
            this.buttonSetting.Location = new System.Drawing.Point(404, 3);
            this.buttonSetting.Name = "buttonSetting";
            this.buttonSetting.Size = new System.Drawing.Size(75, 23);
            this.buttonSetting.TabIndex = 10;
            this.buttonSetting.Text = "Setting";
            this.buttonSetting.UseVisualStyleBackColor = true;
            this.buttonSetting.Click += new System.EventHandler(this.buttonSetting_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(790, 67);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonTele
            // 
            this.buttonTele.Enabled = false;
            this.buttonTele.Location = new System.Drawing.Point(271, 3);
            this.buttonTele.Name = "buttonTele";
            this.buttonTele.Size = new System.Drawing.Size(127, 23);
            this.buttonTele.TabIndex = 8;
            this.buttonTele.Text = "General Telegraph";
            this.buttonTele.UseVisualStyleBackColor = true;
            this.buttonTele.Click += new System.EventHandler(this.buttonTele_Click);
            // 
            // labelLinkstate
            // 
            this.labelLinkstate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelLinkstate.AutoSize = true;
            this.labelLinkstate.Location = new System.Drawing.Point(73, 81);
            this.labelLinkstate.Name = "labelLinkstate";
            this.labelLinkstate.Size = new System.Drawing.Size(41, 12);
            this.labelLinkstate.TabIndex = 7;
            this.labelLinkstate.Text = "已断开";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "连接状态：";
            // 
            // buttonFreeTele
            // 
            this.buttonFreeTele.Location = new System.Drawing.Point(165, 3);
            this.buttonFreeTele.Name = "buttonFreeTele";
            this.buttonFreeTele.Size = new System.Drawing.Size(100, 23);
            this.buttonFreeTele.TabIndex = 5;
            this.buttonFreeTele.Text = "Free Telegraph";
            this.buttonFreeTele.UseVisualStyleBackColor = true;
            this.buttonFreeTele.Click += new System.EventHandler(this.buttonFreeTele_Click);
            // 
            // buttonUnlink
            // 
            this.buttonUnlink.Location = new System.Drawing.Point(84, 3);
            this.buttonUnlink.Name = "buttonUnlink";
            this.buttonUnlink.Size = new System.Drawing.Size(75, 23);
            this.buttonUnlink.TabIndex = 4;
            this.buttonUnlink.Text = "UnLink";
            this.buttonUnlink.UseVisualStyleBackColor = true;
            this.buttonUnlink.Click += new System.EventHandler(this.buttonUnlink_Click);
            // 
            // buttonLink
            // 
            this.buttonLink.Location = new System.Drawing.Point(3, 3);
            this.buttonLink.Name = "buttonLink";
            this.buttonLink.Size = new System.Drawing.Size(75, 23);
            this.buttonLink.TabIndex = 3;
            this.buttonLink.Text = "Link";
            this.buttonLink.UseVisualStyleBackColor = true;
            this.buttonLink.Click += new System.EventHandler(this.buttonLink_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            // 
            // timerGeneral
            // 
            this.timerGeneral.Enabled = true;
            this.timerGeneral.Interval = 300;
            this.timerGeneral.Tick += new System.EventHandler(this.timerGeneral_Tick);
            // 
            // buttonInfoTable
            // 
            this.buttonInfoTable.Location = new System.Drawing.Point(485, 3);
            this.buttonInfoTable.Name = "buttonInfoTable";
            this.buttonInfoTable.Size = new System.Drawing.Size(75, 23);
            this.buttonInfoTable.TabIndex = 15;
            this.buttonInfoTable.Text = "InfoTable";
            this.buttonInfoTable.UseVisualStyleBackColor = true;
            this.buttonInfoTable.Click += new System.EventHandler(this.buttonInfoTable_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 549);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "ProtocolTestTool";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button buttonFreeTele;
        private System.Windows.Forms.Button buttonUnlink;
        private System.Windows.Forms.Button buttonLink;
        private System.Windows.Forms.Label labelLinkstate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonTele;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonSetting;
        private System.Windows.Forms.Timer timerListUpdate;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private ListViewNF listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button buttonLock;
        private System.Windows.Forms.Button buttonClearAll;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button46;
        private System.Windows.Forms.Button button48;
        private System.Windows.Forms.Button buttonStartDT;
        private System.Windows.Forms.Button buttonStopDT;
        private System.Windows.Forms.Button buttonSConfirm;
        private System.Windows.Forms.Button buttonTestFR;
        private System.Windows.Forms.Button buttonCall;
        private System.Windows.Forms.TextBox textBoxW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerGeneral;
        private System.Windows.Forms.TextBox textBoxK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonInfoTable;
        
    }
}

