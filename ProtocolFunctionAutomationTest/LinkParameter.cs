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
    public partial class LinkParameter : Form
    {
        public LinkParameter()
        {
            InitializeComponent();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ButtionOK_Click(object sender, EventArgs e)
        {
            GlobeData.LinkPara.IP = textIP.Text;
            GlobeData.LinkPara.Port = textPort.Text;
            GlobeData.LinkPara.LenCOT = textCOTLen.Text;
            GlobeData.LinkPara.LenLinA = textLALen.Text;
            GlobeData.LinkPara.LenPubA = textPALen.Text;
            GlobeData.LinkPara.DevAddr = Int32.Parse(textDevAddr.Text);
        }

     
    }
}
