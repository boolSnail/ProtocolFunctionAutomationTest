using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProtocolFunctionAutomationTest.PROTOCOL104;

namespace ProtocolFunctionAutomationTest
{ 
    public partial class GeneralTelegraph : Form
    {
        _46C_DC_NA_1 _46c_dc_na_1;
        _48C_SE_NA_1 _48c_se_na_1;

        public GeneralTelegraph()
        {
            InitializeComponent();
        }

        private void buttonStartDT_Click(object sender, EventArgs e)
        {
            GlobeData.TaskFlag.STARTDT = true;
        }

        private void buttonStopDT_Click(object sender, EventArgs e)
        {
            GlobeData.TaskFlag.STOPDT = true;
        }

        private void buttonTestFR_Click(object sender, EventArgs e)
        {
            GlobeData.TaskFlag.TestFR = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonCall_Click(object sender, EventArgs e)
        {
            GlobeData.TaskFlag.Call = true;
        }

        private void buttonSConfirm_Click(object sender, EventArgs e)
        {
            GlobeData.TaskFlag.Do_OKTACT = true;
        }

        private void button46_Click(object sender, EventArgs e)
        {
            //若未创建则创建窗口，若已创建则释放旧窗口重新创建一个新窗口
            if (_46c_dc_na_1 == null)
            {
                _46c_dc_na_1 = new _46C_DC_NA_1();
            }
            else
            {
                _46c_dc_na_1.Dispose();
                _46c_dc_na_1 = new _46C_DC_NA_1();
            }
            _46c_dc_na_1.Show();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            //若未创建则创建窗口，若已创建则释放旧窗口重新创建一个新窗口
            if (_48c_se_na_1 == null)
            {
                _48c_se_na_1 = new _48C_SE_NA_1();
            }
            else
            {
                _48c_se_na_1.Dispose();
                _48c_se_na_1 = new _48C_SE_NA_1();
            }
            _48c_se_na_1.Show();
        }


    }
}
