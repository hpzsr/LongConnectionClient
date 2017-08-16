using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class LongConnectionUtil
{
    static LongConnectionUtil s_instance = null;

    Socket m_socket;
    //IPAddress m_ipAddress = IPAddress.Parse("222.73.65.206");
    //int m_ipPort = 10103;
    IPAddress m_ipAddress = IPAddress.Parse("127.0.0.1");
    int m_ipPort = 10008;

    NetListen m_netListen;
    bool m_isStart = false;

    public static LongConnectionUtil getInstance()
    {
        if (s_instance == null)
        {
            s_instance = new LongConnectionUtil();
        }

        return s_instance;
    }

    public void Connection(NetListen netListen)
    {
        m_netListen = netListen;

        Thread t1 = new Thread(CreateConnectionInThread);
        t1.Start();
    }

    void CreateConnectionInThread()
    {
        try
        {
            m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipEndPort = new IPEndPoint(m_ipAddress, m_ipPort);
            m_socket.Connect(ipEndPort);

            Debug.WriteLine("连接服务器成功");

            m_isStart = true;
            receive();
        }
        catch (SocketException ex)
        {
            Debug.WriteLine("连接服务器失败");
            Debug.WriteLine("错误日志：" + ex.Message);

            m_netListen.onNetListenError("");
        }
    }

    public void stopConncetion()
    {
        m_isStart = false;

        m_socket.Close();
    }

    public void sendmessage(string sendData)
    {
        Debug.WriteLine("发送给服务端消息：" + sendData);

        try
        {
            byte[] bytes = new byte[1024];
            bytes = Encoding.UTF8.GetBytes(sendData);
            m_socket.Send(bytes);
        }
        catch (SocketException ex)
        {
            Debug.WriteLine("与服务端连接断开");
            Debug.WriteLine("错误日志：" + ex.Message);

            m_netListen.onNetListenError("");
        }
    }

    public void receive()
    {
        while (m_isStart)
        {
            try
            {
                byte[] rece = new byte[1024];
                int recelong = m_socket.Receive(rece, rece.Length, 0);
                string reces = Encoding.UTF8.GetString(rece, 0, recelong);

                Debug.WriteLine("收到服务端消息：" + reces);
                m_netListen.onNetListen("", reces);
            }
            catch (SocketException ex)
            {
                Debug.WriteLine("与服务端连接断开");
                Debug.WriteLine("错误日志：" + ex.Message);
                m_netListen.onNetListenError("");

                return;
            }
        }
    }
}
