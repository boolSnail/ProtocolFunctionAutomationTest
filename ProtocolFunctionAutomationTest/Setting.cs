using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProtocolFunctionAutomationTest
{
    public partial class Setting : Form
    {
        Timer timer1;
        Timer timer2;
        Timer timer3;
        public Setting(Timer timer1,Timer timer2,Timer timer3)
        {
            InitializeComponent();
            this.timer1 = timer1;
            this.timer2 = timer2;
            this.timer3 = timer3;
            textBoxPA.Text = GlobeData.LinkPara.DevAddr.ToString();
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //开启与关闭t1延迟
        private void buttonTurnt1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;
                buttonTurnt1.Text = "Turn On t1";
            }
            else if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                buttonTurnt1.Text = "Turn Off t1";
            }
        }

        //开启与关闭t3延迟
        private void buttonTurnt3_Click(object sender, EventArgs e)
        {
            if (timer3.Enabled == true)
            {
                timer3.Enabled = false;
                buttonTurnt3.Text = "Turn On t3";
            }
            else if (timer3.Enabled == false)
            {
                timer3.Enabled = true;
                buttonTurnt3.Text = "Turn Off t3";
            }
        }

        //初始化按钮上的文本
        private void Setting_Load(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                buttonTurnt1.Text = "Turn off t1";
            }
            else if (timer1.Enabled == false)
            {
                buttonTurnt1.Text = "Turn on t1";
            }
            if (timer3.Enabled == true)
            {
                buttonTurnt3.Text = "Turn off t3";
            }
            else if (timer3.Enabled == false)
            {
                buttonTurnt3.Text = "Turn on t2";
            }
            if (timer2.Enabled == true)
            {
                buttonTurnt2.Text = "Turn off t2";
            }
            else if (timer2.Enabled == false)
            {
                buttonTurnt2.Text = "Turn on t2";
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            textBoxT1.Text = GlobeData.t1 + "s";
            textBoxT2.Text = GlobeData.t2 + "s";
            textBoxT3.Text = GlobeData.t3 + "s";
        }

        private void buttonTurnt2_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled == true)
            {
                timer2.Enabled = false;
                buttonTurnt2.Text = "Turn On t2";
            }
            else if (timer2.Enabled == false)
            {
                timer2.Enabled = true;
                buttonTurnt2.Text = "Turn Off t2";
            }
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            GlobeData.LinkPara.DevAddr = int.Parse(textBoxPA.Text);
        }

        private void buttonSetT1_Click(object sender, EventArgs e)
        {
            GlobeData.t1 = GlobeData.t1_default = (int)numericUpDownT1.Value;
            
        }

        private void buttonSetT2_Click(object sender, EventArgs e)
        {
            GlobeData.t2=GlobeData.t2_default = (int)numericUpDownT2.Value;
        }

        private void buttonSetT3_Click(object sender, EventArgs e)
        {
            GlobeData.t3=GlobeData.t3_default = (int)numericUpDownT3.Value;
        }
    }
}
