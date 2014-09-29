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
    public partial class FreeTelegraph : Form
    {
        //输入报文不合法标志
        private bool illegalTele=false;
        private bool illegalTele1=false;
        private bool illegalTele2=false;
        private bool illegalTele3=false;

        public FreeTelegraph()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }



        //发送对应textbox里的报文。先进行位数验证，如果报文数位为奇则报错
        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (illegalTele)                                            //报文不合法，不予发送
                return;
            if ((textBoxTele.Text.Length % 2 != 0) || (textBoxTele.Text.Length == 0))                      //检查报文位数
            {
                MessageBox.Show("You entered a telegraph with wrong number of digits!");
                return;
            }
            for (int i = 0; i < textBoxTele.Text.Length; i = i + 2)                                 //发送报文
            {
                GlobeData.StremData.data[i / 2] = Byte.Parse(textBoxTele.Text.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
            }
            GlobeData.TxSeq += 2;
            if (GlobeData.TxSeq >= 0x7fff)
                GlobeData.TxSeq = 0;
            GlobeData.StremData.len = textBoxTele.Text.Length / 2;
            GlobeData.StremData.task = true;
        }

        private void buttonSend1_Click(object sender, EventArgs e)
        {
            if (illegalTele1)                //报文不合法，不予发送
                return;
            if ((textBoxTele.Text.Length % 2 != 0) || (textBoxTele.Text.Length == 0))               //检查报文位数
            {
                MessageBox.Show("You entered a telegraph with wrong number of digits!");
                return;
            }
            for (int i = 0; i < textBoxTele1.Text.Length; i = i + 2)                   //发送报文
            {
                GlobeData.StremData.data[i / 2] = Byte.Parse(textBoxTele1.Text.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
            }
            GlobeData.TxSeq += 2;
            if (GlobeData.TxSeq >= 0x7fff)
                GlobeData.TxSeq = 0;
            GlobeData.StremData.len = textBoxTele1.Text.Length / 2;
            GlobeData.StremData.task = true;
        }

        private void buttonSend2_Click(object sender, EventArgs e)
        {
            if (illegalTele2)                 //报文不合法，不予发送
                return;
            if ((textBoxTele.Text.Length % 2 != 0) || (textBoxTele.Text.Length == 0))                //检查报文位数
            {
                MessageBox.Show("You entered a telegraph with wrong number of digits!");
                return;
            }

            GlobeData.StremData.data[0] = 0x68;
            GlobeData.StremData.data[2] = (byte)(GlobeData.TxSeq & 0x00ff);
            GlobeData.StremData.data[3] = (byte)((GlobeData.TxSeq & 0xff00) >> 8);
            GlobeData.StremData.data[4] = (byte)(GlobeData.RxSeq & 0x00ff);
            GlobeData.StremData.data[5] = (byte)((GlobeData.RxSeq & 0xff00) >> 8);
            for (int i = 0; i < textBoxTele2.Text.Length; i = i + 2)                //发送报文
            {
                GlobeData.StremData.data[6+(i/2)] = Byte.Parse(textBoxTele2.Text.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
            }
            GlobeData.TxSeq += 2;
            if (GlobeData.TxSeq >= 0x7fff)
                GlobeData.TxSeq = 0;
            GlobeData.StremData.len = textBoxTele2.Text.Length / 2+6;
            GlobeData.StremData.data[1] = (byte)(GlobeData.StremData.len - 2); 
            GlobeData.StremData.task = true;
        }

        private void buttonSend3_Click(object sender, EventArgs e)
        {
            if (illegalTele3)                //报文不合法，不予发送
                return;
            if ((textBoxTele.Text.Length % 2 != 0) || (textBoxTele.Text.Length == 0))              //检查报文位数
            {
                MessageBox.Show("You entered a telegraph with wrong number of digits!");
                return;
            }

            GlobeData.StremData.data[0] = 0x68;
            GlobeData.StremData.data[2] = (byte)(GlobeData.TxSeq & 0x00ff);
            GlobeData.StremData.data[3] = (byte)((GlobeData.TxSeq & 0xff00) >> 8);
            GlobeData.StremData.data[4] = (byte)(GlobeData.RxSeq & 0x00ff);
            GlobeData.StremData.data[5] = (byte)((GlobeData.RxSeq & 0xff00) >> 8);
            for (int i = 0; i < textBoxTele3.Text.Length; i = i + 2)             //发送报文
            {
                GlobeData.StremData.data[6+(i/2)] = Byte.Parse(textBoxTele3.Text.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
            }
            GlobeData.TxSeq += 2;
            if (GlobeData.TxSeq >= 0x7fff)
                GlobeData.TxSeq = 0;
            GlobeData.StremData.len = textBoxTele3.Text.Length / 2+6;
            GlobeData.StremData.data[1] = (byte)(GlobeData.StremData.len - 2); 
            GlobeData.StremData.task = true;
        }

        //限制只允许键盘输入合法字符
        private void textBoxTele_KeyDown(object sender, KeyEventArgs e)
        {
            #region Debug
            System.Diagnostics.Debug.WriteLine("e.KeyCode: " + e.KeyCode);
            System.Diagnostics.Debug.WriteLine("e.KeyCode: " + e.KeyData);
            System.Diagnostics.Debug.WriteLine("e.KeyValue: " + e.KeyValue);
            #endregion

            //只能输入数字、退格、带ctrl的组合功能键以及小键盘上的数字、向左向右两个箭头、abcdef6个字母。
            if ((e.KeyValue < 48 || e.KeyValue > 57) && (e.KeyValue != 8) && (!e.Control) && (e.KeyValue < 96 || e.KeyValue > 105)&&(e.KeyValue!=37)
                &&(e.KeyValue!=39)&&(e.KeyValue!=65)&&(e.KeyValue!=66)&&(e.KeyValue!=67)&&(e.KeyValue!=68)&&(e.KeyValue!=69)&&(e.KeyValue!=70))
            { e.SuppressKeyPress = true; }
        }

        //验证输入文本框的内容是否是合法报文（主要为了应对非法的粘贴输入内容）
        private void textBoxTele_Validating(object sender, CancelEventArgs e)
        {
            illegalTele = false;
            textBoxTele.Text = textBoxTele.Text.Replace(" ", "");
            for (int i = 0; i < textBoxTele.Text.Length; i++)
            {
                if (Char.IsDigit(textBoxTele.Text[i]))      //检查字符是否位数字
                    continue;                                     //跳过此次循环
                else
                {
                    //检查报文是否为a~f或者A~F
                    if (((textBoxTele.Text[i] > 64) && (textBoxTele.Text[i] < 71)) || ((textBoxTele.Text[i] > 96) && (textBoxTele.Text[i] < 103)))
                        continue;                                 //跳过此次循环
                }
                illegalTele = true;                      //检测出非法字符，报文不合法
                break;

            }
            if (illegalTele)
            {
                //若检测出非法字符，则采取处理
                textBoxTele.ForeColor = Color.Red;
            }
            else
            {
                textBoxTele.ForeColor = Color.Black;
            }
        }

        private void textBoxTele1_Validating(object sender, CancelEventArgs e)
        {
            illegalTele1 = false;
            textBoxTele1.Text = textBoxTele1.Text.Replace(" ", "");
            for (int i = 0; i < textBoxTele1.Text.Length; i++)
            {
                if (Char.IsDigit(textBoxTele1.Text[i]))      //检查字符是否位数字
                    continue;                                     //跳过此次循环
                else
                {
                    //检查报文是否为a~f或者A~F
                    if (((textBoxTele1.Text[i] > 64) && (textBoxTele1.Text[i] < 71)) || ((textBoxTele1.Text[i] > 96) && (textBoxTele1.Text[i] < 103)))
                        continue;                                 //跳过此次循环
                }
                illegalTele1 = true;                      //检测出非法字符，报文不合法
                break;

            }
            if (illegalTele1)
            {
                //若检测出非法字符，则采取处理
                textBoxTele1.ForeColor = Color.Red;
            }
            else
            {
                textBoxTele1.ForeColor = Color.Black;
            }
        }

        private void textBoxTele2_Validating(object sender, CancelEventArgs e)
        {
            illegalTele2 = false;
            textBoxTele2.Text = textBoxTele2.Text.Replace(" ", "");
            for (int i = 0; i < textBoxTele2.Text.Length; i++)
            {
                if (Char.IsDigit(textBoxTele2.Text[i]))      //检查字符是否位数字
                    continue;                                     //跳过此次循环
                else
                {
                    //检查报文是否为a~f或者A~F
                    if (((textBoxTele2.Text[i] > 64) && (textBoxTele2.Text[i] < 71)) || ((textBoxTele2.Text[i] > 96) && (textBoxTele2.Text[i] < 103)))
                        continue;                                 //跳过此次循环
                }
                illegalTele2 = true;                      //检测出非法字符，报文不合法
                break;

            }
            if (illegalTele2)
            {
                //若检测出非法字符，则采取处理
                textBoxTele2.ForeColor = Color.Red;
            }
            else
            {
                textBoxTele2.ForeColor = Color.Black;
            }
        }

        private void textBoxTele3_Validating(object sender, CancelEventArgs e)
        {
            illegalTele3 = false;
            textBoxTele3.Text = textBoxTele3.Text.Replace(" ", "");
            for (int i = 0; i < textBoxTele3.Text.Length; i++)
            {
                if (Char.IsDigit(textBoxTele3.Text[i]))      //检查字符是否位数字
                    continue;                                     //跳过此次循环
                else
                {
                    //检查报文是否为a~f或者A~F
                    if (((textBoxTele3.Text[i] > 64) && (textBoxTele3.Text[i] < 71)) || ((textBoxTele3.Text[i] > 96) && (textBoxTele3.Text[i] < 103)))
                        continue;                                 //跳过此次循环
                }
                illegalTele3 = true;                      //检测出非法字符，报文不合法
                break;

            }
            if (illegalTele3)
            {
                //若检测出非法字符，则采取处理
                textBoxTele3.ForeColor = Color.Red;
            }
            else
            {
                textBoxTele3.ForeColor = Color.Black;
            }
        }


    }
}
