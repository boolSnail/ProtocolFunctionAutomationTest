using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using ProtocolFunctionAutomationTest.PROTOCOL104;

namespace ProtocolFunctionAutomationTest
{
    public partial class Form1 : Form
    {
        _46C_DC_NA_1 _46c_dc_na_1;
        _48C_SE_NA_1 _48c_se_na_1;

        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static Thread threadConnect;
        static Thread threadSend;
        static Thread threadReviece;
        static Thread threadInformationTable;

        FreeTelegraph freeTelegraph;
        GeneralTelegraph generalTelegraph;
        Setting setting;
        TelegraphDetail1 telegraphDetail1;
        InformationTable informationTable;

        int DataTy = -1;

        private static object listUpdateLock = new object();                   //list更新并发锁

        public Form1()
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false; 
            InitializeComponent();

            //初始化遥信遥测数据状态记录
            GlobeData.InformationData.YxValue = new string[4096];
            GlobeData.InformationData.YxBL = new string[4096];
            GlobeData.InformationData.YxSB = new string[4096];
            GlobeData.InformationData.YxNT = new string[4096];
            GlobeData.InformationData.YxIV = new string[4096];
            GlobeData.InformationData.YcValue = new string[4096];
            GlobeData.InformationData.YcOV = new string[4096];
            GlobeData.InformationData.YcBL = new string[4096];
            GlobeData.InformationData.YcSB = new string[4096];
            GlobeData.InformationData.YcNT = new string[4096];
            GlobeData.InformationData.YcIV = new string[4096];
            for (int i = 0; i < 4096; i++)
            {
                GlobeData.InformationData.YxValue[i] = GlobeData.InformationData.YxBL[i] = GlobeData.InformationData.YxSB[i] 
                    = GlobeData.InformationData.YxNT[i] = GlobeData.InformationData.YxIV[i]="null";
                GlobeData.InformationData.YcValue[i] = GlobeData.InformationData.YcOV[i] = GlobeData.InformationData.YcBL[i]
                    = GlobeData.InformationData.YcSB[i] = GlobeData.InformationData.YcNT[i] = GlobeData.InformationData.YcIV[i] = "null";

            }
        }

        //确定按下连接后进行连接及创建相关发送与接收线程。并且连接前先进行判断，是否有正在进行中的连接，如果有先断开。
        private void buttonLink_Click(object sender, EventArgs e)
        {
            LinkParameter linkParameter = new LinkParameter();
            linkParameter.ShowDialog();
            if (linkParameter.DialogResult == DialogResult.OK)
            {
                if (threadConnect != null) threadConnect.Abort();
                if (threadSend != null) threadSend.Abort();
                if (threadReviece != null) threadReviece.Abort();
                socket.Close();
                //Try to link
                GlobeData.TaskFlag.STARTDT=true;
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                threadConnect = new Thread(new ThreadStart(ConnThreadSendProc));
                threadConnect.Start();

                threadSend = new Thread(new ThreadStart(NetThreadSendProc));
                threadSend.Start();

                threadReviece = new Thread(new ThreadStart(ReceiveNetMsg));
                threadReviece.Start();
                
            }
        }


        //网络连接socket线程
        private void ConnThreadSendProc()          
        {

            while (true)
            {
                try
                {

                    socket.Connect(IPAddress.Parse(GlobeData.LinkPara.IP), Convert.ToInt16(GlobeData.LinkPara.Port));
                    MessageBox.Show("Link Succeeded!");
                    buttonLink.Enabled = false;
                    labelLinkstate.Text = "已连接";
                    break;
                }
                catch
                {
                    MessageBox.Show("Error! Can not link to the device!");

                }
                Thread.Sleep(20000);   //20s
            }

        }


        //网络发送数据线程
        private void NetThreadSendProc()   
        {
  
            while (true)    //处理事物
            {
                NetSendFrame();
                if (GlobeData.StremData.task == true)
                {
                    if (GlobeData.K == 12)
                    {
                        continue;
                    }
                    try
                    {
                        socket.Send(GlobeData.StremData.data,0,GlobeData.StremData.len,SocketFlags.None);
                        GlobeData.t3 = GlobeData.t3_default;
                        GlobeData.t1 = GlobeData.t1_default;
                        listUpdate(true);
                        GlobeData.StremData.task = false;
                    }
                    catch
                    {
                        MessageBox.Show("Error happens while trying to send telegraph!");
                    }

                }
                else
                {
                }
                Thread.Sleep(1);
            }
        }



        //网络接收数据线程
        private void ReceiveNetMsg()   
        {
            while (true)
            {
                    try
                    {
                        GlobeData.StremData.recLen = socket.Receive(GlobeData.StremData.recData);
                        if (GlobeData.StremData.recLen > 0)
                        {
                            DataTy=protocolty104.DecodeFrame();
                            listUpdate(false);
                            GlobeData.t3 = GlobeData.t3_default;
                            GlobeData.t1 = 0;
                            ProcessRevTele(DataTy);
                        }
                        else
                        {

                        }


                    }
                    catch
                    {
                        MessageBox.Show("Error happens while trying to receive telegraph!");
                    }               
                Thread.Sleep(1);
            }

        }

        //断开连接
        private void buttonUnlink_Click(object sender, EventArgs e)
        {
            if (threadConnect != null) threadConnect.Abort();
            if (threadSend != null) threadSend.Abort();
            if (threadReviece != null) threadReviece.Abort();
            socket.Close();
            reset();
            buttonLink.Enabled = true;
            labelLinkstate.Text = "未连接";
            MessageBox.Show("Unlink Completed!");
        }

        //打开自定义报文窗口
        private void buttonFreeTele_Click(object sender, EventArgs e)
        {
            //若未创建则创建窗口，若已创建则释放旧窗口重新创建一个新窗口
            if (freeTelegraph == null)
            {
                freeTelegraph = new FreeTelegraph();
            }
            else
            {
                freeTelegraph.Dispose();
                freeTelegraph = new FreeTelegraph();
            }
            freeTelegraph.Show();
        }

        //构造报文函数
        private void NetSendFrame()
        {
            if (GlobeData.TaskFlag.STARTDT == true)           //初次发送，启动传输命令
            {
                GlobeData.TaskFlag.STARTDT = false;
                GlobeData.StremData.len=protocolty104.EncodeFrame(1);
                GlobeData.StremData.task = true;
                reset();
                return;
            }
            else if (GlobeData.TaskFlag.Do_OKTACT == true)       //S格式确认帧
            {
                GlobeData.TaskFlag.Do_OKTACT = false;
                GlobeData.StremData.len = protocolty104.EncodeFrame(7);
                GlobeData.StremData.task = true;
                return;
            }
            else if (GlobeData.TaskFlag.STOPDT == true)
            {
                GlobeData.TaskFlag.STOPDT = false;
                GlobeData.StremData.len = protocolty104.EncodeFrame(3);
                GlobeData.StremData.task = true;
                return;
            }
            else if (GlobeData.TaskFlag.TestFR == true)
            {
                GlobeData.TaskFlag.TestFR = false;
                GlobeData.StremData.len = protocolty104.EncodeFrame(5);
                GlobeData.StremData.task = true;
                return;
            }
            else if (GlobeData.TaskFlag.Call == true)
            {
                GlobeData.TaskFlag.Call = false;
                GlobeData.InformationObject.Len = 0;
                GlobeData.InformationObject.VSQ = 1;
                GlobeData.StremData.len = protocolty104.EncodeFrame(10);
                GlobeData.StremData.task = true;
                return;
            }
            else if (GlobeData.TaskFlag.Yk_Sel_SP == true)          //单点遥控选择
            {
                GlobeData.TaskFlag.Yk_Sel_SP = false;
                GlobeData.StremData.len = 0;
                GlobeData.InformationObject.VSQ = 1;
                GlobeData.StremData.len = protocolty104.EncodeFrame(15);
                GlobeData.StremData.task = true;
            }
            else if (GlobeData.TaskFlag.Yk_Sel_DP == true)     //双点遥控选择
            {
                GlobeData.TaskFlag.Yk_Sel_DP = false;
                GlobeData.StremData.len = 0;
                GlobeData.InformationObject.VSQ = 1;
                GlobeData.StremData.len = protocolty104.EncodeFrame(17);
                GlobeData.StremData.task = true;

            }
            else if (GlobeData.TaskFlag.Yk_Exe_SP == true)     //单点遥控执行
            {
                GlobeData.TaskFlag.Yk_Exe_SP = false;
                GlobeData.StremData.len = 0;
                GlobeData.InformationObject.VSQ = 1;
                GlobeData.StremData.len = protocolty104.EncodeFrame(15);
                GlobeData.StremData.task = true;
            }
            else if (GlobeData.TaskFlag.Yk_Exe_DP == true)     //双点遥控执行
            {
                GlobeData.TaskFlag.Yk_Exe_DP = false;
                GlobeData.StremData.len = 0;
                GlobeData.InformationObject.VSQ = 1;
                GlobeData.StremData.len = protocolty104.EncodeFrame(17);
                GlobeData.StremData.task = true;
            }
            else if (GlobeData.TaskFlag.Yk_Cal_SP == true)     //单点遥控撤销
            {
                GlobeData.TaskFlag.Yk_Cal_SP = false;
                GlobeData.StremData.len = 0;
                GlobeData.InformationObject.VSQ = 1;
                GlobeData.StremData.len = protocolty104.EncodeFrame(16);
                //if (PublicDataClass.YkState == 1)
                //    PublicDataClass.SedNetFrameMsg = "撤销<分>";
                //else if (PublicDataClass.YkState == 2)
                //    PublicDataClass.SedNetFrameMsg = "撤销<合>";
                GlobeData.StremData.task = true;
                //PublicDataClass._ThreadIndex.NetThreadID = 23;
                //DelayTime = PublicDataClass._Time.NetDelayTime;
            }
            else if (GlobeData.TaskFlag.Yk_Cal_DP == true)     //双点遥控撤销
            {
                GlobeData.TaskFlag.Yk_Cal_DP = false;
                GlobeData.StremData.len = 0;
                GlobeData.InformationObject.VSQ = 1;
                GlobeData.StremData.len = protocolty104.EncodeFrame(18);
                GlobeData.StremData.task = true;
            }
            else if (GlobeData.TaskFlag.SET_YC_1 == true) //归一化设定值命令
            {
                GlobeData.TaskFlag.SET_YC_1 = false;
                GlobeData.StremData.len = 0;
                GlobeData.StremData.len = protocolty104.EncodeFrame(20);
                GlobeData.StremData.task = true;
            }
            else if (GlobeData.TaskFlag.CEL_YC_1 == true)//归一化设定值命令撤销
            {
                GlobeData.TaskFlag.CEL_YC_1 = false;
                GlobeData.StremData.len = 0;
                GlobeData.StremData.len = protocolty104.EncodeFrame(51);
                GlobeData.StremData.task = true;
            }
            else if (GlobeData.TaskFlag.SET_YC_3 == true)  //短浮点数设定值命令
            {
                GlobeData.TaskFlag.SET_YC_3 = false;
                GlobeData.StremData.len = 0;
                GlobeData.StremData.len = protocolty104.EncodeFrame(22);

                GlobeData.StremData.task = true;

            }
            else if (GlobeData.TaskFlag.CEL_YC_3 == true)  //短浮点数设定值命令撤销
            {
                GlobeData.TaskFlag.CEL_YC_3 = false;
                GlobeData.StremData.len = 0;
                GlobeData.StremData.len = protocolty104.EncodeFrame(53);

                GlobeData.StremData.task = true;
            }
                

            
        }

        //更新发送或接受的报文到列表框
        private void listUpdate(bool isSend)
        {
            lock (listUpdateLock)
            {
                if (isSend)//发送的报文
                {
                    StringBuilder sb = new StringBuilder();

                    ListViewItem lv = new ListViewItem((listView1.Items.Count + 1).ToString());
                    lv.SubItems.Add(teleJudge(true)); 
                    lv.SubItems.Add(System.DateTime.Now.ToString());
                    lv.SubItems.Add("Send");
                    for (int i = 0; i < GlobeData.StremData.len; i++)
                    {
                        sb.Append(GlobeData.StremData.data[i].ToString("X2"));
                        sb.Append(" ");
                    }

                    #region Debug
                    System.Diagnostics.Debug.WriteLine("(fm)Send_sb: " + sb.ToString());
                    //System.Diagnostics.Debug.WriteLine("(fm)Send.len: " + GlobeData.StremData.len);
                    #endregion

                    lv.SubItems.Add(sb.ToString());
                    //GlobeData.history.Add(lv.Text, sb.ToString());                 //以string格式储存完整报文，储存的字符串里包含空格
                    byte[] tele = new byte[GlobeData.StremData.len];                 //以byte[]格式储存完整报文以string格式储存完整报文
                    for(int i = 0; i < GlobeData.StremData.len; i++){
                        tele[i]=GlobeData.StremData.data[i];
                    }
                    GlobeData.history.Add(lv.Text, tele);

                    lv.ForeColor = Color.Green;
                    listView1.Items.Add(lv);
                }
                else//接收的报文
                {
                    StringBuilder sb = new StringBuilder();

                    #region Debug
                    if (GlobeData.errorStr != null)
                    {
                        sb.Append(GlobeData.errorStr);
                        GlobeData.errorStr = null;
                    }
                    #endregion

                    ListViewItem lv = new ListViewItem((listView1.Items.Count + 1).ToString());
                    lv.SubItems.Add(teleJudge(false));
                    lv.SubItems.Add(System.DateTime.Now.ToString());
                    lv.SubItems.Add("       Receive");
                    for (int i = 0; i < GlobeData.StremData.recLen; i++)
                    {
                        sb.Append(GlobeData.StremData.recData[i].ToString("X2"));
                        sb.Append(" ");
                    }
                    lv.SubItems.Add(sb.ToString());

                    #region Debug
                    System.Diagnostics.Debug.WriteLine("(fm)Receive_sb: " + sb.ToString());
                    //System.Diagnostics.Debug.WriteLine("(fm)Receive_len: " + GlobeData.StremData.len);
                    //System.Diagnostics.Debug.WriteLine("(fm)Receive_len_data[1]: " + GlobeData.StremData.data[1]);
                    #endregion

                    //GlobeData.history.Add(lv.Text, sb.ToString());                 //以string格式储存完整报文，储存的字符串里包含空格
                    byte[] tele = new byte[GlobeData.StremData.recLen];                 //以byte[]格式储存完整报文以string格式储存完整报文
                    for (int i = 0; i < GlobeData.StremData.recLen; i++)
                    {
                        tele[i] = GlobeData.StremData.recData[i];
                    }
                    GlobeData.history.Add(lv.Text, tele);

                    lv.ForeColor = Color.OrangeRed;
                    listView1.Items.Add(lv);
                }

            }

        }
        



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

 
        //判断报文类型
        private string teleJudge(bool isSend)
        {
            switch (isSend ? GlobeData.StremData.data[2] : GlobeData.StremData.recData[2])
            {
                case 0x07:
                    return "启动命令";
                case 0x0B:
                    return "启动确认";
                case 0x13:
                    return "停止命令";
                case 0x23:
                    return "停止确认";
                case 0x43:
                    return "测试命令";
                case 0x83:
                    return "测试确认";
                case 0x01:
                    return "S格式确认";
                default:
                    return "";
            }
            
            


        }

        
        //t1延迟时钟触发后的处理函数
        private void timer1_Tick(object sender, EventArgs e)
        {
            //t1延迟到达时，说明网络可能有未知问题，断开连接
            if (GlobeData.t1 > 1)
                GlobeData.t1--;
            else if (GlobeData.t1 == 1)
            {
                GlobeData.t1--;
                GlobeData.linkstate = false;
                buttonLink.Enabled = true;              
                if (threadConnect != null) threadConnect.Abort();
                if (threadSend != null) threadSend.Abort();
                if (threadReviece != null) threadReviece.Abort();
                socket.Close();
                labelLinkstate.Text = "已断开";
                MessageBox.Show("The link is disconnected!");
            }


        }

        //t3延迟时钟触发后的处理函数
        private void timer3_Tick(object sender, EventArgs e)
        {
            //t3延迟到达时发送测试报文
            GlobeData.t3--;
            if (GlobeData.t3 == 0)
            {
                GlobeData.StremData.len=protocolty104.EncodeFrame(5);
                GlobeData.StremData.task = true;
                GlobeData.t3 = GlobeData.t3_default;
            }
        }






        //打开常用报文窗口
        private void buttonTele_Click(object sender, EventArgs e)
        {
            //若未创建则创建窗口，若已创建则释放旧窗口重新创建一个新窗口
            if (generalTelegraph == null)
            {
                generalTelegraph = new GeneralTelegraph();
            }
            else
            {
                generalTelegraph.Dispose();
                generalTelegraph = new GeneralTelegraph();
            }
            generalTelegraph.Show();
        }

        //退出主窗口，退出程序
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            System.Environment.Exit(0);
        }

        //启动setting面板
        private void buttonSetting_Click(object sender, EventArgs e)
        {
            //若未创建则创建窗口，若已创建则释放旧窗口重新创建一个新窗口
            if (setting == null)
            {
                setting = new Setting(timer1, timer2,timer3);       //打开setting面板，并且把timer1传递给setting。
            }
            else
            {
                setting.Dispose();
                setting = new Setting(timer1, timer2,timer3);
            }        
            setting.Show();
        }

        //双击报文打开详情窗口。若窗口已开启则会关闭旧窗口，创建并打开新选择报文的详情窗口
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string key = listView1.SelectedItems[0].Text;
            //if (telegraphDetail == null)
            //    telegraphDetail = new TelegraphDetail(key);
            //else
            //{
            //    telegraphDetail.Dispose();
            //    telegraphDetail = new TelegraphDetail(key);
            //}
            //telegraphDetail.Show();



            if (telegraphDetail1 == null)
                telegraphDetail1 = new TelegraphDetail1(key);
            else
            {
                telegraphDetail1.Dispose();
                telegraphDetail1 = new TelegraphDetail1(key);
            }
            telegraphDetail1.Show();

        }


        

        //清屏并清除后台历史记录
        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            GlobeData.history.Clear();
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            if (timerListUpdate.Enabled == true)
            {
                timerListUpdate.Enabled = false;
                buttonLock.Text = "Unlock";
            }
            else if (timerListUpdate.Enabled == false)
            {
                GlobeData.sedBoxUpdate = false;              //防止取消锁定一瞬间会更新一条之前陈旧的报文
                GlobeData.revBoxUpdate = false;              //防止取消锁定一瞬间会更新一条之前陈旧的报文
                timerListUpdate.Enabled = true;
                buttonLock.Text = "lock";
            }
        }

        //重置tx，re等参数
        private void reset()
        {
            GlobeData.RxSeq = 0;
            GlobeData.TxSeq = 0;
            GlobeData.W = 0;
            GlobeData.K = 0;
        }








        #region General Telegraph

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
#endregion

        private void timerGeneral_Tick(object sender, EventArgs e)
        {
            textBoxW.Text = (GlobeData.W).ToString();
            textBoxK.Text = GlobeData.K.ToString();
        }

        private void buttonInfoTable_Click(object sender, EventArgs e)
        {

            if (threadInformationTable != null)
            {
                threadInformationTable.Abort();
            }
            threadInformationTable = new Thread(new ThreadStart(openInfoTable));
            threadInformationTable.Start();


            //if (informationTable == null)
            //{
            //    informationTable = new InformationTable();       //打开setting面板，并且把timer1传递给setting。
            //}
            //else
            //{
            //    informationTable.Dispose();
            //    informationTable = new InformationTable();
            //}
            //informationTable.Show();
            
        }

        private void openInfoTable()
        {
            Application.Run(new InformationTable());
        }



        //处理接解码后的报文
        private void ProcessRevTele(int DataTy)
        {
            byte[] bytes = new byte[4];
            float fdata = 0.0f;
            int data = 0;
            byte yxdata;
            int StartPos = 0;
            int index = 0;     

            switch (DataTy) 
            {

                case 51:     //单点遥信响应站召唤，类型标识1                   
                    StartPos = GlobeData.InformationObject.recBuffer[2];
                    StartPos = StartPos << 16;
                    StartPos += GlobeData.InformationObject.recBuffer[0] + (GlobeData.InformationObject.recBuffer[1] << 8);
                    for (int j = 0; j < GlobeData.InformationObject.recVSQ; j++)
                    {
                        yxdata = GlobeData.InformationObject.recBuffer[j + 3];
                                    if (yxdata == 0)
                                        GlobeData.InformationData.YxValue[StartPos-1] = "分";
                                    else
                                        GlobeData.InformationData.YxValue[StartPos - 1] = "合";
                                    StartPos++;
                    }
                    break;

                case 52:     //突发，单点遥信变位，类型标识1                                             
                    for (int i = 0; i < GlobeData.InformationObject.recVSQ; i++)                 
                    {                  
                        int StartAddr = 0;
                        StartAddr = GlobeData.InformationObject.recBuffer[index + 2];
                        StartAddr = StartAddr << 16;
                        StartAddr += GlobeData.InformationObject.recBuffer[index] + (GlobeData.InformationObject.recBuffer[index + 1] << 8);

                        if (GlobeData.InformationObject.recBuffer[index + 3] == 0)
                            GlobeData.InformationData.YxValue[StartAddr - 1] = "分";
                        else
                            GlobeData.InformationData.YxValue[StartAddr - 1] = "合";
                        index += 4;
                    }
                    break;

                case 40:            //短浮点数遥测响应站召唤，类型标识13    
                    StartPos = (GlobeData.InformationObject.recBuffer[2] << 16) + GlobeData.InformationObject.recBuffer[0] + (GlobeData.InformationObject.recBuffer[1] << 8);
                    for (int j = 0; j < GlobeData.InformationObject.recVSQ; j++)
                    {
                        bytes[0] = GlobeData.InformationObject.recBuffer[index + 3];
                        bytes[1] = GlobeData.InformationObject.recBuffer[index + 4];
                        bytes[2] = GlobeData.InformationObject.recBuffer[index + 5];
                        bytes[3] = GlobeData.InformationObject.recBuffer[index + 6];                            
                        fdata = BitConverter.ToSingle(bytes, 0);
                        index += 5;
                        GlobeData.InformationData.YcValue[StartPos - 0x4001] = String.Format("{0:f4}", fdata);
                        StartPos++;
                    }
                    break;

                case 41:    //突发，短浮点数遥测扰动，类型标识13  
                    for (int i = 0; i < GlobeData.InformationObject.recVSQ; i++)
                    {
                        int StartAddr = 0;
                        StartAddr = GlobeData.InformationObject.recBuffer[index + 2];
                        StartAddr = StartAddr << 16;
                        StartAddr += GlobeData.InformationObject.recBuffer[index] + (GlobeData.InformationObject.recBuffer[index + 1] << 8);

                        bytes[0] = GlobeData.InformationObject.recBuffer[index + 3];
                        bytes[1] = GlobeData.InformationObject.recBuffer[index + 4];
                        bytes[2] = GlobeData.InformationObject.recBuffer[index + 5];
                        bytes[3] = GlobeData.InformationObject.recBuffer[index + 6];                           
                        fdata = BitConverter.ToSingle(bytes, 0);  //转换为浮点                            
                        GlobeData.InformationData.YcValue[StartAddr - 0x4001] = String.Format("{0:f4}", fdata);                          
                        index += 8;                      
                    }
                    break;
                    
                case 36:         //归一化遥测响应站召唤
                    StartPos = (GlobeData.InformationObject.recBuffer[2] << 16) + GlobeData.InformationObject.recBuffer[0] + (GlobeData.InformationObject.recBuffer[1] << 8);    
                    for (int j = 0; j < GlobeData.InformationObject.recVSQ; j++)
                    {
                        data = GlobeData.InformationObject.recBuffer[index + 3] + (GlobeData.InformationObject.recBuffer[index + 4] << 8);    
                        index += 3;   
                        if (data > 0x8000)  
                            data = data - 65536;
                        GlobeData.InformationData.YcValue[StartPos-0x4001] = Convert.ToString(data);
                        StartPos++; 
                    }
                    

                    break;
                case 37:        //突发，归一化遥测扰动
                   
                    for (int j = 0; j < GlobeData.InformationObject.recVSQ; j++)
                    {
                        int StartAddr = 0;
                        StartAddr = GlobeData.InformationObject.recBuffer[index + 2];
                        StartAddr = StartAddr << 16;
                        StartAddr += GlobeData.InformationObject.recBuffer[index] + (GlobeData.InformationObject.recBuffer[index + 1] << 8);

                        data = GlobeData.InformationObject.recBuffer[index + 3] + (GlobeData.InformationObject.recBuffer[index + 4] << 8);    
                        index += 6;   
                        if (data > 0x8000)  
                            data = data - 65536;
                        GlobeData.InformationData.YcValue[StartAddr - 0x4001] = Convert.ToString(data);
               
                    }

                    break;


                default:
                    break;
            }
        }


    }
}
