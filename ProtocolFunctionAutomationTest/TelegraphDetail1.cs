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
    public partial class TelegraphDetail1 : Form
    {
        string key;
        byte[] tele;
        string teleStr;
        public TelegraphDetail1(string key)
        {
            InitializeComponent();
            this.key = key;            
            tele = GlobeData.history[key];
        }

        private void TelegraphDetail1_Load(object sender, EventArgs e)
        {
            teleStr = string.Join(" ", tele.Select(t => t.ToString("X2")).ToArray());  //byte[]转换为string，并且添加间隔符空格
            richTextBox1.Text = teleStr;


            if ((tele.Length - tele[1] != 2) || (tele[0] != 0x68) || (tele.Length < 6))//非法帧
            {
                return;
            }
            else if ((tele[0] == 0x68) && (tele.Length == 6))
            {
                ListViewItem lv = new ListViewItem();
                lv.SubItems.Add(tele[0].ToString("X2"));
                lv.SubItems.Add("起始字");
                listView1.Items.Add(lv);
                lv = new ListViewItem();
                lv.SubItems.Add(tele[1].ToString("X2"));
                lv.SubItems.Add("长度： "+tele[1].ToString());//长度
                listView1.Items.Add(lv);
                switch (tele[2])
                {
                    case 0x07:
                        lv = new ListViewItem();
                        lv.SubItems.Add(tele[2].ToString("X2"));
                        lv.SubItems.Add("U格式: 启动命令"); //启动命令
                        listView1.Items.Add(lv);
                        for (int i = 3; i < 6; i++)
                        {
                            lv = new ListViewItem();
                            lv.SubItems.Add(tele[i].ToString("X2"));
                            listView1.Items.Add(lv);
                        }
                            break;
                    case 0x13:
                        lv = new ListViewItem();
                        lv.SubItems.Add(tele[2].ToString("X2"));
                        lv.SubItems.Add("U格式: 停止命令"); //停止命令
                        listView1.Items.Add(lv);
                        for (int i = 3; i < 6; i++)
                        {
                            lv = new ListViewItem();
                            lv.SubItems.Add(tele[i].ToString("X2"));
                            listView1.Items.Add(lv);
                        }
                        break;
                    case 0x43:
                        lv = new ListViewItem();
                        lv.SubItems.Add(tele[2].ToString("X2"));
                        lv.SubItems.Add("U格式: 测试命令");//测试命令
                        listView1.Items.Add(lv);
                        for (int i = 3; i < 6; i++)
                        {
                            lv = new ListViewItem();
                            lv.SubItems.Add(tele[i].ToString("X2"));
                            listView1.Items.Add(lv);
                        }
                        break;
                    case 0x0b:
                        lv = new ListViewItem();
                        lv.SubItems.Add(tele[2].ToString("X2"));
                        lv.SubItems.Add("U格式: 启动确认");//启动确认
                        listView1.Items.Add(lv);
                        for (int i = 3; i < 6; i++)
                        {
                            lv = new ListViewItem();
                            lv.SubItems.Add(tele[i].ToString("X2"));
                            listView1.Items.Add(lv);
                        }
                        break;
                    case 0x83:
                        lv = new ListViewItem();
                        lv.SubItems.Add(tele[2].ToString("X2"));
                        lv.SubItems.Add("U格式: 测试确认");//测试确认
                        listView1.Items.Add(lv);
                        for (int i = 3; i < 6; i++)
                        {
                            lv = new ListViewItem();
                            lv.SubItems.Add(tele[i].ToString("X2"));
                            listView1.Items.Add(lv);
                        }
                        break;
                    case 0x23:
                        lv = new ListViewItem();
                        lv.SubItems.Add(tele[2].ToString("X2"));
                        lv.SubItems.Add("U格式: 停止确认");//停止确认
                        listView1.Items.Add(lv);
                        for (int i = 3; i < 6; i++)
                        {
                            lv = new ListViewItem();
                            lv.SubItems.Add(tele[i].ToString("X2"));
                            listView1.Items.Add(lv);
                        }
                        break;
                    case 0x01:
                        lv = new ListViewItem();
                        lv.SubItems.Add(tele[2].ToString("X2"));
                        lv.SubItems.Add("S格式: 确认帧");//S确认帧
                        listView1.Items.Add(lv);
                        lv = new ListViewItem();
                        lv.SubItems.Add(tele[3].ToString("X2"));
                        listView1.Items.Add(lv);
                        lv = new ListViewItem();
                        lv.SubItems.Add(tele[4].ToString("X2") + " " + tele[4].ToString("X2"));
                        lv.SubItems.Add("接收序列: "+((tele[4] >> 1) + (tele[5] << 8)).ToString());
                        listView1.Items.Add(lv);
                        break;
                }
            }
            else
            {
                ListViewItem lv = new ListViewItem();
                lv.SubItems.Add(tele[0].ToString("X2"));
                lv.SubItems.Add("起始字");
                listView1.Items.Add(lv);
                lv = new ListViewItem();
                lv.SubItems.Add(tele[1].ToString("X2"));
                lv.SubItems.Add("长度: " + tele[1].ToString());//长度
                listView1.Items.Add(lv);

                //发送序列
                lv = new ListViewItem();
                lv.SubItems.Add(tele[2].ToString("X2") + " " + tele[3].ToString("X2"));
                lv.SubItems.Add("发送序列: " + ((tele[2] >> 1) + (tele[3] << 8)).ToString());
                listView1.Items.Add(lv);

                //接收序列
                lv = new ListViewItem();
                lv.SubItems.Add(tele[4].ToString("X2") + " " + tele[5].ToString("X2"));
                lv.SubItems.Add("接收序列: " + ((tele[4] >> 1) + (tele[5] << 8)).ToString());
                listView1.Items.Add(lv);

                //类型标识
                lv = new ListViewItem();
                lv.SubItems.Add(tele[6].ToString("X2"));
                lv.SubItems.Add("类型标识: " + tele[6].ToString());
                listView1.Items.Add(lv);

                //可变结构限定词
                lv = new ListViewItem();
                lv.SubItems.Add(tele[7].ToString("X2"));
                lv.SubItems.Add("可变结构限定词(" + "SQ:" + (tele[7] >= 128 ? "1" : "0")+", " + "VSQ:" + ((tele[7] & 0x7f).ToString())+")");
                listView1.Items.Add(lv);

                //传送原因
                lv = new ListViewItem();
                lv.SubItems.Add(tele[8].ToString("X2"));
                lv.SubItems.Add("传送原因(" + "T:" + (tele[8] >= 128 ? "1" : "0") +", "+ "PN:" +(tele[8] >= 64 ? "1" : "0")+", "+ "COT:" +((tele[8] & 0x3f).ToString())+ ")");
                listView1.Items.Add(lv);

                //传送原因2：原发地址
                lv = new ListViewItem();
                lv.SubItems.Add(tele[9].ToString("X2"));
                lv.SubItems.Add("原发地址: " + tele[9].ToString());
                listView1.Items.Add(lv);

                //应用服务数据单元公共地址
                lv = new ListViewItem();
                lv.SubItems.Add(tele[10].ToString("X2") + " " + tele[11].ToString("X2"));
                lv.SubItems.Add("公共地址: " + (tele[10] + (tele[11]<<8)).ToString());
                listView1.Items.Add(lv);

                //信息体对象地址
                lv = new ListViewItem();
                lv.SubItems.Add(tele[12].ToString("X2") + " " + tele[13].ToString("X2") + " " + tele[14].ToString("X2"));
                lv.SubItems.Add("信息对象地址: " + (tele[12] + (tele[13] << 8)+(tele[14]<<16)).ToString());
                listView1.Items.Add(lv);








                byte TypeID = tele[6];
                ushort COT = Convert.ToUInt16(tele[8] & 0x3f);
                byte COI = tele[15];
                byte dataty = 0;
                byte PN = (byte)(tele[8] & 0x40);//01000000


                int index;
                int Pos = 0;
                int data = 0;
                int thei=0;
                string DataInfo = @"";
                byte[] bytes = new byte[4];
                float fdata = 0.0F;




                switch(TypeID)
                {
                    case 1://单点遥信
                            
                        if(COT==20)
                        {
                            Pos = tele[12] + (tele[13] << 8) + (tele[14] << 16);
                            for (int i = 15; i < tele.Length; i++)
                            {
                                            lv=new ListViewItem();
                                            lv.SubItems.Add(tele[i].ToString("X2"));
                                            if (tele[i] == 0x00)
                                                lv.SubItems.Add("<" + String.Format("{0:d}", Pos) + "：分>" + " ");
                                            else
                                                lv.SubItems.Add("<" + String.Format("{0:d}", Pos) + "：合>" + " ");
                                            listView1.Items.Add(lv);
 
                                    Pos++; 
                            }
                        }else if(COT==3)
                        {
                            for (int i = 12; i < tele.Length; i=i+4)
                            {
                                if (i == 12)  //不带时标遥信和遥信变位
                                {
                                    lv = new ListViewItem();
                                    lv.SubItems.Add(tele[i+3].ToString("X2"));
                                    if (tele[i+3] == 0)
                                        lv.SubItems.Add("<" + String.Format("{0:d}", Pos) + "：分>" + " ");
                                    else
                                        lv.SubItems.Add("<" + String.Format("{0:d}", Pos) + "：合>" + " ");
                                    listView1.Items.Add(lv);
                                }
                                else
                                {
                                    Pos=tele[i] + (tele[i + 1] << 8) + (tele[i + 2] << 16);
                                    lv = new ListViewItem();
                                    lv.SubItems.Add(tele[i].ToString("X2") + " "+tele[i + 1].ToString("X2") + " "+tele[i + 2].ToString("X2"));
                                    lv.SubItems.Add("信息对象地址: " + Pos);
                                    listView1.Items.Add(lv);
                                    lv = new ListViewItem();
                                    lv.SubItems.Add(tele[i + 3].ToString("X2"));
                                    if (tele[i + 3] == 0)
                                        lv.SubItems.Add("<" + String.Format("{0:d}", Pos) + "：分>" + " ");
                                    else
                                        lv.SubItems.Add("<" + String.Format("{0:d}", Pos) + "：合>" + " ");
                                    listView1.Items.Add(lv);


                                }
                            }
                            
                        }                         
                        break;

                    case 9://归一化遥测
                        {
                            if (COT == 20)
                            {
                                Pos = tele[12] + (tele[13] << 8) + (tele[14] << 16);
                                for (int i = 15; i < tele.Length; i=i+3)
                                {
                                    data = tele[i] + (tele[i+1] << 8);
                                    lv = new ListViewItem();
                                    lv.SubItems.Add(tele[i].ToString("X2") + " "+tele[i+1].ToString("X2"));
                                    lv.SubItems.Add("<" + String.Format("{0:d}", Pos+ thei) + "：" + String.Format("{0:d}", data) + ">" + " ");
                                    listView1.Items.Add(lv);

                                    lv = new ListViewItem();
                                    lv.SubItems.Add(tele[i + 2].ToString("X2"));
                                    lv.SubItems.Add("品质描述");
                                    listView1.Items.Add(lv);
                                    thei++;
                                }
                            }
                            else if (COT == 3)
                            {
                                for (int i = 12; i < tele.Length; i=i+6)
                                {
                                    if (i == 12)
                                    {
                                        Pos = tele[i] + (tele[i + 1] << 8) + (tele[i + 2] << 16);


                                        data = tele[i + 3] + (tele[i + 4] << 8);

                                        lv = new ListViewItem();
                                        lv.SubItems.Add(tele[i + 3].ToString("X2") + " " + tele[i + 4].ToString("X2"));
                                        lv.SubItems.Add("<" + String.Format("{0:d}", Pos) + "：" + String.Format("{0:d}", data) + ">" + " ");
                                        listView1.Items.Add(lv);

                                        lv = new ListViewItem();
                                        lv.SubItems.Add(tele[i + 5].ToString("X2"));
                                        lv.SubItems.Add("品质描述");
                                        listView1.Items.Add(lv);
                                    }
                                    else
                                    {
                                        Pos = tele[i] + (tele[i + 1] << 8) + (tele[i + 2] << 16);
                                        lv = new ListViewItem();
                                        lv.SubItems.Add(tele[i].ToString("X2") + " " + tele[i + 1].ToString("X2") + " " + tele[i + 2].ToString("X2"));
                                        lv.SubItems.Add("信息对象地址: " + Pos);
                                        listView1.Items.Add(lv);

                                        data = tele[i + 3] + (tele[i + 4] << 8);

                                        lv = new ListViewItem();
                                        lv.SubItems.Add(tele[i + 3].ToString("X2") + " " + tele[i + 4].ToString("X2"));
                                        lv.SubItems.Add("<" + String.Format("{0:d}", Pos) + "：" + String.Format("{0:d}", data) + ">" + " ");
                                        listView1.Items.Add(lv);

                                        lv = new ListViewItem();
                                        lv.SubItems.Add(tele[i + 5].ToString("X2"));
                                        lv.SubItems.Add("品质描述");
                                        listView1.Items.Add(lv);
                                    }
                                    

                                }
                            }
                    }
                        break;

                    case 30://带时标CP56Time2a的单点信息
                        if (COT == 3)
                        {
                            for (int i = 12; i < tele.Length; i = i + 11)
                            {
                                if (i == 12)
                                {
                                    lv = new ListViewItem();
                                    lv.SubItems.Add(tele[i + 3].ToString("X2"));
                                    if (tele[i + 3] == 0)
                                        lv.SubItems.Add("<" + String.Format("{0:d}", Pos) + "：分>" + " ");
                                    else
                                        lv.SubItems.Add("<" + String.Format("{0:d}", Pos) + "：合>" + " ");
                                    listView1.Items.Add(lv);

                                    DataInfo = "";
                                    DataInfo = String.Format("{0:d}", tele[i + 10]);   //年
                                    DataInfo += "年";
                                    DataInfo += String.Format("{0:d}", tele[i + 9]);  //月
                                    DataInfo += "月";
                                    DataInfo += String.Format("{0:d}", tele[i + 8] & 0x1f);  //日+星期
                                    DataInfo += "日";
                                    DataInfo += String.Format("{0:d}", tele[i + 7]);  //时
                                    DataInfo += "时";
                                    DataInfo += String.Format("{0:d}", tele[i + 6]);  //分
                                    DataInfo += "分";
                                    int ms = (tele[i + 5] << 8) + tele[i + 4];

                                    DataInfo += String.Format("{0:d}", ms);
                                    DataInfo += "毫秒" + ">";
                                    lv = new ListViewItem();
                                    lv.SubItems.Add(tele[i + 4].ToString("X2") + " " + tele[i + 5].ToString("X2") + " " + tele[i + 6].ToString("X2") + " " + tele[i + 7].ToString("X2") + " " + tele[i + 8].ToString("X2") + " " + tele[i + 9].ToString("X2") + " " + tele[i + 10].ToString("X2"));
                                    lv.SubItems.Add(DataInfo);
                                    listView1.Items.Add(lv);
                                }
                                else 
                                {

                                    Pos = tele[i] + (tele[i+1] << 8) + (tele[i+2] << 16);
                                    lv = new ListViewItem();
                                    lv.SubItems.Add(tele[i].ToString("X2") + " " + tele[i + 1].ToString("X2") + " " + tele[i + 2].ToString("X2"));
                                    lv.SubItems.Add("信息对象地址: " + Pos);
                                    listView1.Items.Add(lv);

                                    lv = new ListViewItem();
                                    lv.SubItems.Add(tele[i+3].ToString("X2"));
                                    if (tele[i+3] == 0)
                                        lv.SubItems.Add("<" + String.Format("{0:d}", Pos) + "：分>" + " ");
                                    else
                                        lv.SubItems.Add("<" + String.Format("{0:d}", Pos) + "：合>" + " ");
                                    listView1.Items.Add(lv);

                                    DataInfo = "";
                                    DataInfo = String.Format("{0:d}", tele[i+10]);   //年
                                    DataInfo += "年";
                                    DataInfo += String.Format("{0:d}", tele[i + 9]);  //月
                                    DataInfo += "月";
                                    DataInfo += String.Format("{0:d}", tele[i + 8] & 0x1f);  //日+星期
                                    DataInfo += "日";
                                    DataInfo += String.Format("{0:d}", tele[i + 7]);  //时
                                    DataInfo += "时";
                                    DataInfo += String.Format("{0:d}", tele[i + 6]);  //分
                                    DataInfo += "分";
                                    int ms = (tele[i + 5] << 8) + tele[i + 4];

                                    DataInfo += String.Format("{0:d}", ms);
                                    DataInfo += "毫秒" + ">";
                                    lv = new ListViewItem();
                                    lv.SubItems.Add(tele[i + 4].ToString("X2") + " " + tele[i + 5].ToString("X2") + " " + tele[i + 6].ToString("X2") + " " + tele[i+7].ToString("X2") + " " + tele[i+8].ToString("X2") + " " + tele[i+9].ToString("X2") + " " + tele[i+10].ToString("X2"));
                                    lv.SubItems.Add(DataInfo);
                                    listView1.Items.Add(lv);
                                }

                            }
                        }
                        break;

                    case 13://浮点值遥测
                        if (COT == 20)
                        {
                            Pos = tele[12] + (tele[13] << 8) + (tele[14] << 16);
                            for (int i = 15; i < tele.Length; i = i + 5)
                            {
                                bytes[0] = tele[i];
                                bytes[1] = tele[i + 1];
                                bytes[2] = tele[i + 2];
                                bytes[3] = tele[i + 3];

                                fdata = BitConverter.ToSingle(bytes, 0);

                                lv = new ListViewItem();
                                lv.SubItems.Add(tele[i].ToString("X2") + " " + tele[i+1].ToString("X2") + " " + tele[i+2].ToString("X2") + " " + tele[i+3].ToString("X2"));
                                lv.SubItems.Add("<" + String.Format("{0:d}", Pos + thei) + "：" + String.Format("{0:f4}", fdata) + ">" + " ");
                                listView1.Items.Add(lv);

                                lv = new ListViewItem();
                                lv.SubItems.Add(tele[i + 4].ToString("X2"));
                                lv.SubItems.Add("品质描述");
                                listView1.Items.Add(lv);
                               
                                thei++;
                            }


                                
                        }
                        else if (COT == 3) 
                        {
                            for (int i = 12; i < tele.Length; i = i + 8) 
                            {
                                if (i == 12)
                                {
                                    bytes[0] = tele[i + 3];
                                    bytes[1] = tele[i + 4];
                                    bytes[2] = tele[i + 5];
                                    bytes[3] = tele[i + 6];

                                    fdata = BitConverter.ToSingle(bytes, 0);

                                    lv = new ListViewItem();
                                    lv.SubItems.Add(tele[i + 3].ToString("X2") + " " + tele[i + 4].ToString("X2") + " " + tele[i + 5].ToString("X2") + " " + tele[i + 6].ToString("X2"));
                                    lv.SubItems.Add("<" + String.Format("{0:d}", Pos) + "：" + String.Format("{0:f4}", fdata) + ">" + " ");
                                    listView1.Items.Add(lv);

                                    lv = new ListViewItem();
                                    lv.SubItems.Add(tele[i + 7].ToString("X2"));
                                    lv.SubItems.Add("品质描述");
                                    listView1.Items.Add(lv);
                                }
                                else 
                                {
                                    Pos = tele[i] + (tele[i + 1] << 8) + (tele[i + 2] << 16);

                                    lv = new ListViewItem();
                                    lv.SubItems.Add(tele[i].ToString("X2") + " "+tele[i+1].ToString("X2") + " "+tele[i+2].ToString("X2"));
                                    lv.SubItems.Add("信息对象地址: " + Pos);
                                    listView1.Items.Add(lv);

                                    bytes[0] = tele[i+3];
                                    bytes[1] = tele[i+4];
                                    bytes[2] = tele[i+5];
                                    bytes[3] = tele[i+6];

                                    fdata = BitConverter.ToSingle(bytes, 0);

                                    lv = new ListViewItem();
                                    lv.SubItems.Add(tele[i+3].ToString("X2") + " " + tele[i + 4].ToString("X2") + " " + tele[i + 5].ToString("X2") + " " + tele[i + 6].ToString("X2"));
                                    lv.SubItems.Add("<" + String.Format("{0:d}", Pos) + "：" + String.Format("{0:f4}", fdata) + ">" + " ");
                                    listView1.Items.Add(lv);

                                    lv = new ListViewItem();
                                    lv.SubItems.Add(tele[i + 7].ToString("X2"));
                                    lv.SubItems.Add("品质描述");
                                    listView1.Items.Add(lv);

                                }
                            }
                                
                        }

                        break;

                    default:
                        {
                            break;
                        }
                }








            //    switch (TypeID)
            //    {
            //        case 100:   //总召
            //            if (COT == 7)
            //            {
            //                dataty = 4;
            //                textBoxDescription.Text = "总召唤激活";
            //            }//总召唤激活；

            //            else if (COT == 10)
            //            {
            //                dataty = 5;
            //                textBoxDescription.Text = "总召结束";
            //            }
            //            //总召结束
            //            else if (COT == 6 && COI == 0x14)
            //            {
            //                textBoxDescription.Text = "总召唤";
            //            }
            //            else
            //            {
            //                dataty = 169;
            //                textBoxDescription.Text = "总召传送原因错误";
            //            } //总召传送原因错误
            //            break;
            //        case 45:           //不带时标单点遥控
            //            if (PN == 0x40)
            //            {
            //                dataty = 174;
            //                textBoxDescription.Text = "遥控否认";
            //            }                    //遥控否认
            //            else
            //            {
            //                if (COT == 0x0007)
            //                {
            //                    if ((COI & 0x80) == 0x80)
            //                    {
            //                        dataty = 10;
            //                        textBoxDescription.Text = "选择确认";
            //                    }          //选择确认

            //                    if (COI == 0x00)
            //                    {
            //                        dataty = 11;
            //                        textBoxDescription.Text = "执行分成功";
            //                    }
            //                    //执行分成功
            //                    if (COI == 0x01)
            //                    {
            //                        dataty = 11;
            //                        textBoxDescription.Text = "执行合成功";
            //                    }
            //                    //执行合成功
            //                }
            //                else if (COT == 6)
            //                {
            //                    textBoxDescription.Text = "不带时标的单点命令";
            //                }
            //                else if (COT == 8)
            //                {
            //                    textBoxDescription.Text = "不带时标的单点命令撤销";
            //                }
            //                else if (COT == 0x0009)
            //                {
            //                    dataty = 12;
            //                    textBoxDescription.Text = "遥控撤销确认";
            //                }
            //                //遥控撤销确认
            //                else if (COT == 0x000a)
            //                {
            //                    dataty = 173;
            //                    textBoxDescription.Text = "错误，遥控执行结束";
            //                }
            //                //错误，遥控执行结束
            //                else
            //                {
            //                    dataty = 153;
            //                    textBoxDescription.Text = "不带时标单点遥控传送原因错误";
            //                }   //不带时标单点遥控传送原因错误
            //            }
            //            break;
            //        case 46:           //不带时标双点遥控
            //            if (PN == 0x40)
            //            {
            //                dataty = 174;
            //                textBoxDescription.Text = "遥控否认";
            //            }                        //遥控否认
            //            else
            //            {
            //                if (COT == 0x0007)
            //                {
            //                    if ((COI & 0x80) == 0x80)
            //                    {
            //                        dataty = 13;
            //                        textBoxDescription.Text = "选择确认";
            //                    }//选择确认

            //                    if (COI == 0x01)
            //                    {
            //                        dataty = 14;
            //                        textBoxDescription.Text = "执行分成功";
            //                    }
            //                    //执行分成功
            //                    if (COI == 0x02)
            //                    {
            //                        dataty = 14;
            //                        textBoxDescription.Text = "执行合成功";
            //                    }
            //                    //执行合成功
            //                }
            //                else if (COT == 0x0009)
            //                {
            //                    dataty = 15;
            //                    textBoxDescription.Text = "遥控撤销确认";
            //                }
            //                //遥控撤销确认
            //                else if (COT == 6)
            //                {
            //                    textBoxDescription.Text = "不带时标的双点命令";
            //                }
            //                else if (COT == 8)
            //                {
            //                    textBoxDescription.Text = "不带时标的双点命令撤销";
            //                }
            //                else if (COT == 0x000a)
            //                {
            //                    dataty = 173;
            //                    textBoxDescription.Text = "错误，遥控执行结束";
            //                }

            //                else
            //                {
            //                    dataty = 154;
            //                    textBoxDescription.Text = "不带时标双点遥控传送原因错误";
            //                }   //不带时标双点遥控传送原因错误
            //            }
            //            break;
            //        case 48:
            //            {
            //                if (COT == 6)
            //                    textBoxDescription.Text = "归一化设定值命令";
            //                else if (COT == 8)
            //                    textBoxDescription.Text = "归一化设定值命令撤销";
            //                else if (COT == 0x0007)
            //                {

            //                    dataty = 71;   //设置确认
            //                    textBoxDescription.Text = "归一化设定值命令设置确认";
            //                }
            //                else if (COT == 0x0009)
            //                {
            //                    dataty = 72;
            //                    textBoxDescription.Text = "归一化设定值命令撤销确认";
            //                } //撤销确认

            //                else
            //                {
            //                    dataty = 172;
            //                    textBoxDescription.Text = "归一化设定值命令应答传送原因错误";
            //                }  //归一化遥测置数应答传送原因错误
            //                break;
            //            }
            //        case 50:
            //            {
            //                if (COT == 6)
            //                    textBoxDescription.Text = "短浮点数设定值命令";
            //                else if (COT == 8)
            //                    textBoxDescription.Text = "短浮点数设定值命令撤销";
            //                else if (COT == 0x0007)
            //                {
            //                    dataty = 75;   //设置确认
            //                    textBoxDescription.Text = "短浮点数设定值命令设置确认";
            //                }
            //                else if (COT == 0x0009)
            //                {
            //                    dataty = 76;
            //                    textBoxDescription.Text = "短浮点数设定值命令撤销确认";
            //                }//撤销确认

            //                else
            //                {
            //                    dataty = 171;
            //                    textBoxDescription.Text = "短浮点数设定值命令应答传送原因错误";
            //                }   //归一化遥测置数应答传送原因错误
            //                break;
            //            }
            //        case 1:
            //            {
            //                if (COT == 20)  //正常响应站召唤
            //                {
            //                    dataty = 51;
            //                    textBoxDescription.Text = "单点遥信信息（响应站召唤）";
            //                }
            //                else if (COT == 3)  //突发，遥信变位
            //                {
            //                    dataty = 52;
            //                    textBoxDescription.Text = "单点遥信信息（突发，遥信变位）";
            //                    // PublicDataClass._FrameTime.LoopTime = 15;
            //                }
            //                else
            //                {
            //                    dataty = 164;  //单点遥信传送原因错误
            //                    textBoxDescription.Text = "单点遥信传送原因错误";
            //                }
            //                break;
            //            }
            //        case 13:
            //            {
            //                if (COT == 20)  //正常响应站召唤
            //                {
            //                    dataty = 40;
            //                    textBoxDescription.Text = "短浮点数遥测（响应站召唤）";
            //                }
            //                else if (COT == 3)  //突发，扰动
            //                {
            //                    dataty = 41;
            //                    textBoxDescription.Text = "短浮点数遥测（突发，扰动）";
            //                    //PublicDataClass._FrameTime.LoopTime = 15;
            //                }
            //                else
            //                {
            //                    dataty = 159;  //遥测短浮点值传送原因错误
            //                    textBoxDescription.Text = "";
            //                }
            //                break;
            //            }
            //        case 9:
            //            {
            //                if (COT == 20)  //正常响应站召唤
            //                {
            //                    dataty = 36;
            //                    textBoxDescription.Text = "归一化值遥测（响应站召唤）";
            //                }
            //                else if (COT == 3)  //突发，扰动
            //                {
            //                    textBoxDescription.Text = "归一化值遥测（突发，扰动）";
            //                    dataty = 37;
            //                }
            //                else
            //                {
            //                    textBoxDescription.Text = "归一化值遥测传送原因错误";
            //                    dataty = 157;  //遥测归一化值传送原因错误
            //                }

            //                break;
            //            }





            //        default:
            //            //dataty = 0;
            //            {
            //                dataty = 168;
            //                textBoxDescription.Text = "类型标识符错误";
            //                break;
            //            }
            //        //类型标识符错误

            //    }

            }
        }
    }
}
