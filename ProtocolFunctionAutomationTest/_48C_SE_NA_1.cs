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
    public partial class _48C_SE_NA_1 : Form
    {
        public _48C_SE_NA_1()
        {
            InitializeComponent();
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            GlobeData.InformationObject.Len = 0;
            GlobeData.InformationObject.VSQ = 0;
            GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = (byte)(Convert.ToInt32(textBoxPosition.Text) & 0x00ff);
            GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len + 1] = (byte)((Convert.ToInt32(textBoxPosition.Text) & 0xff00) >> 8);
            GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len + 2] = 0x00;
            GlobeData.InformationObject.Len += 3;
            if (radioButtonNor.Checked)//归一化
            {
                GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = (byte)((Convert.ToInt32(textBoxValue.Text)) & 0x00ff);
                GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len + 1] = (byte)(((Convert.ToInt32(textBoxValue.Text)) & 0xff00) >> 8);
                GlobeData.InformationObject.Len += 2;
                GlobeData.InformationObject.VSQ++;
                GlobeData.TaskFlag.SET_YC_1 = true;
            }
            //if (radioButton2.Checked == true)//标度化
            //{
            //    PublicDataClass._DataField.Buffer[PublicDataClass._DataField.FieldLen] = (byte)((Convert.ToInt32(textBox2.Text)) & 0x00ff);
            //    PublicDataClass._DataField.Buffer[PublicDataClass._DataField.FieldLen + 1] = (byte)(((Convert.ToInt32(textBox2.Text)) & 0xff00) >> 8);
            //    PublicDataClass._DataField.FieldLen += 2;
            //    PublicDataClass._DataField.FieldVSQ++;
            //    PublicDataClass._NetTaskFlag.SET_YC_2 = true;

            //}
            if (radioButtonSFP.Checked == true)//短浮点
            {
                byte[] b = BitConverter.GetBytes(float.Parse(textBoxValue.Text));

                GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = b[0];
                GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len + 1] = b[1];
                GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len + 2] = b[2];
                GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len + 3] = b[3];

                GlobeData.InformationObject.Len += 4;
                GlobeData.InformationObject.VSQ++;
                GlobeData.TaskFlag.SET_YC_3 = true;

            }
        }

        private void buttonRevoke_Click(object sender, EventArgs e)
        {
            GlobeData.InformationObject.Len = 0;
            GlobeData.InformationObject.VSQ = 0;
            GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = (byte)(Convert.ToInt32(textBoxPosition.Text) & 0x00ff);
            GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len + 1] = (byte)((Convert.ToInt32(textBoxPosition.Text) & 0xff00) >> 8);
            GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len + 2] = 0x00;
            GlobeData.InformationObject.Len += 3;
            if (radioButtonNor.Checked)//归一化
            {
                GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = (byte)((Convert.ToInt32(textBoxValue.Text)) & 0x00ff);
                GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len + 1] = (byte)(((Convert.ToInt32(textBoxValue.Text)) & 0xff00) >> 8);
                GlobeData.InformationObject.Len += 2;
                GlobeData.InformationObject.VSQ++;
                GlobeData.TaskFlag.CEL_YC_1 = true;
            }
            if (radioButtonSFP.Checked == true)//短浮点
            {
                byte[] b = BitConverter.GetBytes(float.Parse(textBoxValue.Text));

                GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = b[0];
                GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len + 1] = b[1];
                GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len + 2] = b[2];
                GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len + 3] = b[3];

                GlobeData.InformationObject.Len += 4;
                GlobeData.InformationObject.VSQ++;
                GlobeData.TaskFlag.CEL_YC_3 = true;

            }
        }

    }
}
