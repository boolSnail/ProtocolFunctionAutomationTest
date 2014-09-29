using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ProtocolFunctionAutomationTest
{
    public partial class InformationTable : Form
    {
        int flag = 0;

        public InformationTable()
        {
            InitializeComponent();
        }

        private void InformationTable_Load(object sender, EventArgs e)
        {
            ListViewItem lv;
            for (int i = 0; i < 4096; i++)   //初始化遥信列表
            {
                lv = new ListViewItem();
                lv.SubItems.Add(listView1.Items.Count.ToString());
                lv.SubItems.Add((i+0x0001).ToString("X4"));
                lv.SubItems.Add(GlobeData.InformationData.YxValue[i]);
                lv.SubItems.Add(GlobeData.InformationData.YxBL[i]);
                lv.SubItems.Add(GlobeData.InformationData.YxSB[i]);
                lv.SubItems.Add(GlobeData.InformationData.YxNT[i]);
                lv.SubItems.Add(GlobeData.InformationData.YxIV[i]);
                listView1.Items.Add(lv);
            }

            for (int i = 0; i < 4096; i++)   //初始化遥测列表
            {
                lv = new ListViewItem();
                lv.SubItems.Add(listView2.Items.Count.ToString());
                lv.SubItems.Add((i + 0x4001).ToString("X4"));
                lv.SubItems.Add(GlobeData.InformationData.YcValue[i]);
                lv.SubItems.Add(GlobeData.InformationData.YcOV[i]);
                lv.SubItems.Add(GlobeData.InformationData.YcBL[i]);
                lv.SubItems.Add(GlobeData.InformationData.YcSB[i]);
                lv.SubItems.Add(GlobeData.InformationData.YcNT[i]);
                lv.SubItems.Add(GlobeData.InformationData.YcIV[i]);
                listView2.Items.Add(lv);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (flag)
            {
                case 0:
                    for (int i = 0; i < 2048; i++)   //刷新遥信列表
                    {
                        listView1.Items[i].SubItems[3].Text = GlobeData.InformationData.YxValue[i];
                        listView1.Items[i].SubItems[4].Text = GlobeData.InformationData.YxBL[i];
                        listView1.Items[i].SubItems[5].Text = GlobeData.InformationData.YxSB[i];
                        listView1.Items[i].SubItems[6].Text = GlobeData.InformationData.YxNT[i];
                        listView1.Items[i].SubItems[7].Text =GlobeData.InformationData.YxIV[i];
                        
                    }
                    flag++;               
                    break;
                case 1:
                    for (int i = 0; i < 2048; i++)   //刷新遥测列表
                    {
                        listView2.Items[i].SubItems[3].Text = GlobeData.InformationData.YcValue[i];
                        listView2.Items[i].SubItems[4].Text = GlobeData.InformationData.YcOV[i];
                        listView2.Items[i].SubItems[5].Text = GlobeData.InformationData.YcBL[i];
                        listView2.Items[i].SubItems[6].Text = GlobeData.InformationData.YcSB[i];
                        listView2.Items[i].SubItems[7].Text = GlobeData.InformationData.YcNT[i];
                        listView2.Items[i].SubItems[8].Text = GlobeData.InformationData.YcIV[i];
                        
                    }
                    flag++;
                    break;
                case 2:
                    for (int i = 2048; i < 4096; i++)   //刷新遥信列表
                    {
                        listView1.Items[i].SubItems[2].Text = GlobeData.InformationData.YxValue[i];
                        listView1.Items[i].SubItems[3].Text = GlobeData.InformationData.YxBL[i];
                        listView1.Items[i].SubItems[4].Text = GlobeData.InformationData.YxSB[i];
                        listView1.Items[i].SubItems[5].Text = GlobeData.InformationData.YxNT[i];
                        listView1.Items[i].SubItems[6].Text = GlobeData.InformationData.YxIV[i];
                        
                    }
                    flag++;
                    break;
                case 3:
                    for (int i = 2048; i < 4096; i++)   //刷新遥测列表
                    {
                        listView2.Items[i].SubItems[2].Text = GlobeData.InformationData.YcValue[i];
                        listView2.Items[i].SubItems[3].Text = GlobeData.InformationData.YcOV[i];
                        listView2.Items[i].SubItems[4].Text = GlobeData.InformationData.YcBL[i];
                        listView2.Items[i].SubItems[5].Text = GlobeData.InformationData.YcSB[i];
                        listView2.Items[i].SubItems[6].Text = GlobeData.InformationData.YcNT[i];
                        listView2.Items[i].SubItems[7].Text = GlobeData.InformationData.YcIV[i];
                        
                    }
                    flag = 0;
                    break;
                default:
                    break;
            }











        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            labelRefresh.Text = "Refreshing...Please wait...";
            labelRefresh.Refresh();

                for (int i = 0; i < 4096; i++)   //刷新遥信列表
                {
                    listView1.Items[i].SubItems[3].Text = GlobeData.InformationData.YxValue[i];
                    listView1.Items[i].SubItems[4].Text = GlobeData.InformationData.YxBL[i];
                    listView1.Items[i].SubItems[5].Text = GlobeData.InformationData.YxSB[i];
                    listView1.Items[i].SubItems[6].Text = GlobeData.InformationData.YxNT[i];
                    listView1.Items[i].SubItems[7].Text = GlobeData.InformationData.YxIV[i];

                }



            for (int i = 0; i < 4096; i++)   //刷新遥测列表
                    {
                        listView2.Items[i].SubItems[3].Text = GlobeData.InformationData.YcValue[i];
                        listView2.Items[i].SubItems[4].Text = GlobeData.InformationData.YcOV[i];
                        listView2.Items[i].SubItems[5].Text = GlobeData.InformationData.YcBL[i];
                        listView2.Items[i].SubItems[6].Text = GlobeData.InformationData.YcSB[i];
                        listView2.Items[i].SubItems[7].Text = GlobeData.InformationData.YcNT[i];
                        listView2.Items[i].SubItems[8].Text = GlobeData.InformationData.YcIV[i];
                        
                    }
            labelRefresh.Text = "";
        }
    }
}
