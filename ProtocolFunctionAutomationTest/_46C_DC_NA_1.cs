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
    public partial class _46C_DC_NA_1 : Form
    {
        public _46C_DC_NA_1()
        {
            InitializeComponent();
        }


        //合操作
        private void buttonClose_Click(object sender, EventArgs e)       
        {
            try
            {
                GlobeData.YkStartPos = Int16.Parse(textBoxYkStartPos.Text);
                GlobeData.InformationObject.Len = 0;
                GlobeData.YkState = 2;
                if (radioButtonDPI.Checked)            //双点遥控
                {
                    if (radioButtonImpulse.Checked)         //电平式
                    {
                        GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = 0x82;
                        GlobeData.InformationObject.Len++;
                    }
                    else        //脉冲式
                    {
                        //Data_H = YkStartPos & 0xff00;
                        //Data_L = YkStartPos & 0x00ff;
                        //PublicDataClass.YkStartPos = Data_H + (Data_L * 2 -1);

                        GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = 0x82;
                        GlobeData.InformationObject.Len++;

                    }
                    GlobeData.TaskFlag.Yk_Sel_DP = true;
                    
                }
                else if (radioButtonSPI.Checked)       //单点
                {
                    if (radioButtonImpulse.Checked)        //电平式
                    {
                        GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = 0x81;
                        GlobeData.InformationObject.Len++;
                    }
                    else        //脉冲式
                    {
                        //Data_H = YkStartPos & 0xff00;
                        //Data_L = YkStartPos & 0x00ff;
                        //PublicDataClass.YkStartPos = Data_H + (Data_L * 2 -1);
                        GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = 0x81;
                        GlobeData.InformationObject.Len++;

                    }
                    GlobeData.TaskFlag.Yk_Sel_SP = true;
                
                }
            }
            catch (ArgumentOutOfRangeException ee)
            {
                MessageBox.Show("指令执行失败", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
            }
        }


        //分操作
        private void buttonOpen_Click(object sender, EventArgs e)            
        {
            try
            {
                GlobeData.YkStartPos = Int16.Parse(textBoxYkStartPos.Text);
                GlobeData.InformationObject.Len = 0;
                GlobeData.YkState = 1;
                if (radioButtonDPI.Checked)  //双点
                {
                    if (radioButtonLevel.Checked)      //电平式
                    {
                        GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = 0x81;
                        GlobeData.InformationObject.Len++;

                    }
                    else          //脉冲式
                    {
                        //Data_H = YkStartPos & 0xff00;
                        //Data_L = YkStartPos & 0x00ff;
                        //PublicDataClass.YkStartPos = Data_H + (Data_L * 2);
                        GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = 0x81;
                        GlobeData.InformationObject.Len++;

                    }
                    GlobeData.TaskFlag.Yk_Sel_DP = true;
                    
                }
                else if (radioButtonSPI.Checked)  //单点
                {

                    if (radioButtonLevel.Checked)
                    {
                        GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = 0x80;
                        GlobeData.InformationObject.Len++;
                    }
                    else
                    {
                        //Data_H = YkStartPos & 0xff00;
                        //Data_L = YkStartPos & 0x00ff;
                        //PublicDataClass.YkStartPos = Data_H + (Data_L * 2);
                        GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = 0x80;
                        GlobeData.InformationObject.Len++;

                    }
                    GlobeData.TaskFlag.Yk_Sel_SP = true;

                }
            }
            catch (ArgumentOutOfRangeException ee)
            {
                MessageBox.Show("指令操作失败", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
            }
        }


        //执行操作
        private void buttonExecute_Click(object sender, EventArgs e)
        {
            try
            {
                GlobeData.YkStartPos = Int16.Parse(textBoxYkStartPos.Text);
                GlobeData.InformationObject.Len = 0;
                if (radioButtonDPI.Checked)             //双点遥控
                {

                    if (radioButtonLevel.Checked)       //电平式
                    {
                        if (GlobeData.YkState == 1)
                            GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = 0x01;
                        else if (GlobeData.YkState == 2)
                            GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = 0x02;
                        GlobeData.InformationObject.Len++;
                    }
                    else                               //脉冲式
                    {
                        if (GlobeData.YkState == 1)
                            GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = 0x01;
                        else if (GlobeData.YkState == 2)
                            GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = 0x02;
                        GlobeData.InformationObject.Len++;

                    }
                    GlobeData.TaskFlag.Yk_Exe_DP = true;
                    
                }
                else if (radioButtonSPI.Checked)
                {
                    if (radioButtonLevel.Checked)              //电平式
                    {
                        if (GlobeData.YkState == 1)
                            GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = 0x00;
                        else if (GlobeData.YkState == 2)
                            GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = 0x01;
                        GlobeData.InformationObject.Len++;
                    }
                    else
                    {
                        if (GlobeData.YkState == 1)
                            GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = 0x00;
                        else if (GlobeData.YkState == 2)
                            GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = 0x01;
                        GlobeData.InformationObject.Len++;

                    }
                    GlobeData.TaskFlag.Yk_Exe_SP = true;
                    
                }
            }
            catch
            { }
        }


        //撤销操作
        private void buttonRevoke_Click(object sender, EventArgs e)
        {
            try
            {
                GlobeData.YkStartPos = Int16.Parse(textBoxYkStartPos.Text);
                GlobeData.InformationObject.Len = 0;
                /*if (TriggeredType == 1)
                {
                    if (PublicDataClass.YkState == 1)
                        PublicDataClass._DataField.Buffer[PublicDataClass._DataField.FieldLen] = 0x81;
                    else if (PublicDataClass.YkState == 2)
                        PublicDataClass._DataField.Buffer[PublicDataClass._DataField.FieldLen] = 0x82;
                }
                else
                {
                    PublicDataClass._DataField.Buffer[PublicDataClass._DataField.FieldLen] = 0x81;
                }*/
                if (radioButtonDPI.Checked)          //双点遥控
                {
                    if (GlobeData.YkState == 1)
                        GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = 0x81;
                    else if (GlobeData.YkState == 2)
                        GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = 0x82;

                    GlobeData.InformationObject.Len++;
                    GlobeData.TaskFlag.Yk_Cal_DP= true;
                }
                else if (radioButtonSPI.Checked)
                {
                    if (GlobeData.YkState == 1)
                        GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = 0x80;
                    else if (GlobeData.YkState == 2)
                        GlobeData.InformationObject.Buffer[GlobeData.InformationObject.Len] = 0x81;

                    GlobeData.InformationObject.Len++;
                    GlobeData.TaskFlag.Yk_Cal_SP = true;
                }
            }
            catch
            { }
        }

    }
}
