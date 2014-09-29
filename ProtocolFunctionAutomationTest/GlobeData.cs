using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolFunctionAutomationTest
{
    class GlobeData
    {
        //连接参数
        public struct LinkPara
        {
            public static string IP;
            public static string Port;
            public static string LenPubA;
            public static string LenCOT;
            public static string LenLinA;
            public static int DevAddr;                         //公共地址

        }

        //发送与接收数据流
        public struct StremData
        {
            public static int len;
            public static byte[] data = new byte[1024];
            public static int recLen;
            public static byte[] recData = new byte[1024];
            public static bool task = false;
        }

        //信息体结构
        public struct InformationObject
        {
            public static byte[] Buffer = new byte[1024];
            public static int Len;
            public static int VSQ;
            public static byte[] recBuffer = new byte[1024];
            public static int recLen;
            public static int recVSQ;
        }

        public struct TaskFlag
        {
            public static bool Do_OKTACT = false;   //S格式确认帧
            public static bool STARTDT = false;     //启动命令
            public static bool STOPDT=false;  //停止命令
            public static bool TestFR=false;//测试命令
            public static bool Call = false;//总召唤命令
            public static bool Yk_Sel_SP;//单点遥控选择
            public static bool Yk_Sel_DP;//双点遥控选择
            public static bool Yk_Exe_SP;//单点遥控执行
            public static bool Yk_Exe_DP;//双点遥控执行
            public static bool Yk_Cal_SP;//单点遥控撤销
            public static bool Yk_Cal_DP;//双点遥控撤销
            public static bool SET_YC_1;//归一化设定定值命令
            public static bool CEL_YC_1;//归一化设定值命令撤销
            public static bool SET_YC_3;//短浮点数设定值命令
            public static bool CEL_YC_3;//短浮点数设定值命令撤销
        }
        
        public struct InformationData   //遥信遥测数据
        {
            public static string[] YxValue;
            public static string[] YxBL;
            public static string[] YxSB;
            public static string[] YxNT;
            public static string[] YxIV;

            public static string[] YcValue;
            public static string[] YcOV;
            public static string[] YcBL;
            public static string[] YcSB;
            public static string[] YcNT;
            public static string[] YcIV;
        }
        
        public static bool firstlink=false;                  //第一次连接
        public static bool sedBoxUpdate = false;             //发送报文列表需更新
        public static bool revBoxUpdate = false;             //接受报文列表需更新
        public static bool linkstate = false;                //连接状态
        public static int t3 = 20;
        public static int t3_default = 20;
        public static int t1 = -1;
        public static int t1_default = 15;
        public static int t2 = -1;
        public static int t2_default = 10;
        public static ushort TxSeq = 0;                    //发送序列号
        public static ushort RxSeq = 0;                    //接收序列号
        public static int InfoAddr;                        //信息体地址
        public static int W=0;
        public static int K=0;
        //public static Dictionary<string, string> history = new Dictionary<string, string>();        //历史报文记录
        public static Dictionary<string, byte[]> history = new Dictionary<string, byte[]>();        //历史报文记录

        public static int YkStartPos;              //遥控起始地址
        public static int YkState;               //遥控命令分合指示，1为分，2为合



        #region Debug
        public static string errorStr;
        #endregion


    }
}
