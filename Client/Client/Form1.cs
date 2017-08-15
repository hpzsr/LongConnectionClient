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
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        //IPAddress ipAddress = IPAddress.Parse("61.147.73.54");
        int ipPort = 10002;
        IPEndPoint iPEndPoint;
        NetListen_Form1 m_netListen = new NetListen_Form1();

        int temp = 0;

        public Form1()
        {
            InitializeComponent();

            Entity_code.getInstance().init();
        }
        
        // 登录
        private void button1_Click(object sender, EventArgs e)
        {
            LongConnectionUtil.getInstance().Connection();


            //JObject jo = new JObject();
            //jo.Add("tag", "Login");
            //jo.Add("account", textBox_name.Text);
            //jo.Add("psw", textBox_psw.Text);

            //NetUtil.getInstance().reqNet(m_netListen, "Login", jo.ToString());

            //// \r\n换行
            //LogUtil.getInstance().addLog("你好\r\n\r\n");

            //Console.WriteLine(DateTime.Now.ToString());
        }

        // 注册
        private void button2_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i <= 20; i++)
            {
                LongConnectionUtil.getInstance().sendmessage((++temp).ToString());
            }
            

            //JObject jo = new JObject();
            //jo.Add("tag", "Register");
            //jo.Add("account", textBox_name.Text);
            //jo.Add("psw", textBox_psw.Text);

            //NetUtil.getInstance().reqNet(m_netListen, "Register", jo.ToString());

            //LogUtil.getInstance().stopRecordLog();
        }
    }

    class NetListen_Form1 : NetListen
    {
        override public void onNetListen(string tag, string data)
        {
            Console.WriteLine(data);
        }

        override public void onNetListenError(string tag)
        {
            Console.WriteLine("网络请求出错：tag = " + tag);
        }
    }
}
