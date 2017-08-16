using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using Client.Entity;
using System.Diagnostics;

namespace Client
{
    public partial class Form1 : Form
    {
        NetListen_Form1 m_netListen;

        int temp = 0;

        public Form1()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;

            m_netListen = new NetListen_Form1();
            m_netListen.m_parent = this;

            this.button_duankai.Enabled = false;
            this.button_fasong.Enabled = false;
        }
        
        // 连接
        private void button1_Click(object sender, EventArgs e)
        {
            LongConnectionUtil.getInstance().Connection(m_netListen);
            this.button_lianjie.Enabled = false;
            this.button_duankai.Enabled = true;
            this.button_fasong.Enabled = true;
        }

        // 断开
        private void button3_Click(object sender, EventArgs e)
        {
            this.button_lianjie.Enabled = true;
            this.button_duankai.Enabled = true;
            this.button_fasong.Enabled = false;

            LongConnectionUtil.getInstance().stopConncetion();
        }

        // 发送
        private void button2_Click(object sender, EventArgs e)
        {
            string backData = this.textBox_send.Text;
            this.listBox_chat.Items.Add("        " + backData);
            
            LongConnectionUtil.getInstance().sendmessage(backData);

        }

        public void receiveMsg(string str)
        {
            this.listBox_chat.Items.Add(str);
        }
    }

    class NetListen_Form1 : NetListen
    {
        public Form1 m_parent;

        override public void onNetListen(string tag, string data)
        {
            Console.WriteLine(data);
            m_parent.receiveMsg(data);
        }

        override public void onNetListenError(string tag)
        {
            //Console.WriteLine("网络请求出错：tag = " + tag);

            //m_parent.button_lianjie.Enabled = true;
            //m_parent.button_duankai.Enabled = false;
            //m_parent.button_fasong.Enabled = false;
        }
    }
}
