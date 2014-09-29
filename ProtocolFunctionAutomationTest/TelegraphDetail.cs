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
    public partial class TelegraphDetail : Form
    {
        string key;
        byte[] tele;
        string teleStr;
        public TelegraphDetail(string key)
        {
            InitializeComponent();
            this.key = key;
            //tele = GlobeData.history[key].Replace(" ", "");      //原报文string里包含间隔符空格，这里删去所有空格，方便之后的操作与处理
            tele = GlobeData.history[key];
        }

        private void TelegraphDetail_Load(object sender, EventArgs e)
        {
            teleStr = string.Join(" ", tele.Select(t => t.ToString("X2")).ToArray());  //byte[]转换为string，并且添加间隔符空格
            richTextBoxTele.Text = teleStr;

            //判断帧类型
            if ((tele.Length - tele[1] != 2) || (tele[0] != 0x68) || (tele.Length < 6))//非法帧
            {
                textBoxFormat.Text = "Wrong Format";
                return;
            }
            else if ((tele[0] == 0x68) && (tele.Length == 6))
            {
                textBoxLen.Text = tele[1].ToString();
                switch (tele[2])
                {
                    case 0x07:
                        textBoxFormat.Text = "U Format";  //启动命令
                        break;
                    case 0x13:
                        textBoxFormat.Text = "U Format";  //停止命令
                        break;
                    case 0x43:
                        textBoxFormat.Text = "U Format";  //测试命令
                        break;
                    case 0x0b:
                        textBoxFormat.Text = "U Format";  //启动确认
                        break ;
                    case 0x83:
                        textBoxFormat.Text = "U Format";  //测试确认
                        break;
                    case 0x23:
                        textBoxFormat.Text = "U Format";  //停止确认
                        break;
                    case 0x01:
                        textBoxFormat.Text = "S Format"; ;  //S确认帧
                        textBoxNR.Text = ((tele[4] >> 1) + (tele[5] << 8)).ToString();
                        break;
                }
            }
            else
            {
                textBoxFormat.Text = "I Format"; ;                                //I格式
                textBoxTypeID.Text = tele[6].ToString();
                textBoxLen.Text = tele[1].ToString();
                textBoxT.Text = tele[8] >= 128 ? "1" : "0";
                textBoxPN.Text = tele[8] >= 64 ? "1" : "0";
                textBoxTypeCOT.Text = (tele[8] & 0x3f).ToString();
                textBoxSQ.Text = tele[7] >= 128 ? "1" : "0";
                textBoxVSQ.Text = (tele[7] & 0x7f).ToString();
                textBoxNS.Text = ((tele[2] >> 1) + (tele[3] << 8)).ToString();
                textBoxNR.Text = ((tele[4] >> 1) + (tele[5] << 8)).ToString();


                byte TypeID = tele[6];
                ushort COT = Convert.ToUInt16(tele[8] & 0x3f);                
                byte COI=tele[15];
                byte dataty=0;
                byte PN = (byte)(tele[8] & 0x40);//01000000
                switch (TypeID)
                {
                    case 100:   //总召
                        if (COT == 7)
                        {
                            dataty = 4;
                            textBoxDescription.Text = "总召唤激活";
                        }//总召唤激活；
                            
                        else if (COT == 10)
                        {
                            dataty = 5;
                            textBoxDescription.Text = "总召结束";
                        }
                              //总召结束
                        else if(COT == 6&&COI == 0x14)
                        {
                            textBoxDescription.Text = "总召唤";
                        }
                        else
                        {
                            dataty = 169;
                            textBoxDescription.Text = "总召传送原因错误";
                        } //总召传送原因错误
                        break;
                    case 45:           //不带时标单点遥控
                        if (PN == 0x40)
                        { dataty = 174;
                          textBoxDescription.Text = "遥控否认";
                        }                    //遥控否认
                        else
                        {
                            if (COT == 0x0007)
                            {
                                if ((COI & 0x80) == 0x80)
                                {
                                    dataty = 10;
                                    textBoxDescription.Text = "选择确认";
                                }          //选择确认

                                if (COI == 0x00) 
                                { 
                                    dataty = 11;
                                    textBoxDescription.Text = "执行分成功";
                                }
                                                              //执行分成功
                                if (COI == 0x01)
                                {
                                    dataty = 11;
                                    textBoxDescription.Text = "执行合成功";
                                }
                                                              //执行合成功
                            }
                            else if(COT == 6){
                                textBoxDescription.Text = "不带时标的单点命令";
                            }
                            else if (COT == 8)
                            {
                                textBoxDescription.Text = "不带时标的单点命令撤销";
                            }
                            else if (COT == 0x0009) 
                            { 
                                dataty = 12;
                                textBoxDescription.Text = "遥控撤销确认";
                            }
                            //遥控撤销确认
                            else if (COT == 0x000a)
                            {
                                dataty = 173;
                                textBoxDescription.Text = "错误，遥控执行结束";
                            }
                            //错误，遥控执行结束
                            else
                            {
                                dataty = 153;
                                textBoxDescription.Text = "不带时标单点遥控传送原因错误";
                            }   //不带时标单点遥控传送原因错误
                        }
                        break;
                    case 46:           //不带时标双点遥控
                        if (PN == 0x40)
                        { 
                            dataty = 174;
                            textBoxDescription.Text = "遥控否认";
                        }                        //遥控否认
                        else
                        {
                            if (COT == 0x0007)
                            {
                                if ((COI & 0x80) == 0x80)
                                {
                                    dataty = 13;
                                    textBoxDescription.Text = "选择确认";
                                }//选择确认

                                if (COI == 0x01) 
                                { 
                                    dataty = 14;
                                    textBoxDescription.Text = "执行分成功";
                                }
                                                             //执行分成功
                                if (COI == 0x02)
                                {
                                    dataty = 14;
                                    textBoxDescription.Text = "执行合成功";
                                }
                                                              //执行合成功
                            }
                            else if (COT == 0x0009)
                            {
                                dataty = 15;
                                textBoxDescription.Text = "遥控撤销确认";
                            }
                                                           //遥控撤销确认
                            else if (COT == 6)
                            {
                                textBoxDescription.Text = "不带时标的双点命令";
                            }
                            else if (COT == 8)
                            {
                                textBoxDescription.Text = "不带时标的双点命令撤销";
                            }
                            else if (COT == 0x000a)
                            {
                                dataty = 173;
                                textBoxDescription.Text = "错误，遥控执行结束";
                            }

                            else
                            {
                                dataty = 154;
                                textBoxDescription.Text = "不带时标双点遥控传送原因错误";
                            }   //不带时标双点遥控传送原因错误
                        }
                        break;
                    case 48:
                        {
                            if(COT == 6)
                                textBoxDescription.Text = "归一化设定值命令";
                            else if(COT==8)
                                textBoxDescription.Text = "归一化设定值命令撤销";
                            else if (COT == 0x0007)
                            {

                                dataty = 71;   //设置确认
                                textBoxDescription.Text = "归一化设定值命令设置确认";
                            }
                            else if (COT == 0x0009)
                            {
                                dataty = 72;
                                textBoxDescription.Text = "归一化设定值命令撤销确认";
                            } //撤销确认

                            else
                            {
                                dataty = 172;
                                textBoxDescription.Text = "归一化设定值命令应答传送原因错误";
                            }  //归一化遥测置数应答传送原因错误
                            break;
                        }
                    case 50: 
                        {
                            if (COT == 6)
                                textBoxDescription.Text = "短浮点数设定值命令";
                            else if (COT == 8)
                                textBoxDescription.Text = "短浮点数设定值命令撤销";
                            else if (COT == 0x0007)
                            {
                                dataty = 75;   //设置确认
                                textBoxDescription.Text = "短浮点数设定值命令设置确认";
                            }
                            else if (COT == 0x0009)
                            {
                                dataty = 76;
                                textBoxDescription.Text = "短浮点数设定值命令撤销确认";
                            }//撤销确认

                            else
                            {
                                dataty = 171;
                                textBoxDescription.Text = "短浮点数设定值命令应答传送原因错误";
                            }   //归一化遥测置数应答传送原因错误
                            break;
                        }
                    case 1: {
                        if (COT == 20)  //正常响应站召唤
                        {
                            dataty = 51;
                            textBoxDescription.Text = "单点遥信信息（响应站召唤）";
                        }
                        else if (COT == 3)  //突发，遥信变位
                        {
                            dataty = 52;
                            textBoxDescription.Text = "单点遥信信息（突发，遥信变位）";
                            // PublicDataClass._FrameTime.LoopTime = 15;
                        }
                        else
                        {
                            dataty = 164;  //单点遥信传送原因错误
                            textBoxDescription.Text = "单点遥信传送原因错误";
                        } 
                        break;
                    }
                    case 13: {
                        if (COT == 20)  //正常响应站召唤
                        {
                            dataty = 40;
                            textBoxDescription.Text = "短浮点数遥测（响应站召唤）";
                        }
                        else if (COT == 3)  //突发，扰动
                        {
                            dataty = 41;
                            textBoxDescription.Text = "短浮点数遥测（突发，扰动）";
                            //PublicDataClass._FrameTime.LoopTime = 15;
                        }
                        else
                        {
                            dataty = 159;  //遥测短浮点值传送原因错误
                            textBoxDescription.Text = ""; } 
                        break;
                    }
                    case 9:
                        {
                            if (COT == 20)  //正常响应站召唤
                            {
                                dataty = 36;
                                textBoxDescription.Text = "归一化值遥测（响应站召唤）";
                            }
                            else if (COT == 3)  //突发，扰动
                            {
                                textBoxDescription.Text = "归一化值遥测（突发，扰动）";
                                dataty = 37;
                            }
                            else
                            {
                                textBoxDescription.Text = "归一化值遥测传送原因错误";                                          
                                dataty = 157;  //遥测归一化值传送原因错误
                            } 

                            break;
                        }



                      

                    default:
                        //dataty = 0;
                        {
                            dataty = 168;
                            textBoxDescription.Text = "类型标识符错误";
                            break;
                        }
                          //类型标识符错误
                        
                }

            }
                 
       
               
        }
    }
}
