using System;
using System.Collections.Generic;
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
    IPAddress m_ipAddress = IPAddress.Parse("127.0.0.1");
    int m_ipPort = 10002;

    public static LongConnectionUtil getInstance()
    {
        if (s_instance == null)
        {
            s_instance = new LongConnectionUtil();
        }

        return s_instance;
    }

    public void Connection()
    {
        Thread t1 = new Thread(CreateConnectionInThread);
        t1.Start();
    }

    void CreateConnectionInThread()
    {
        m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint ipEndPort = new IPEndPoint(m_ipAddress, m_ipPort);
        m_socket.Connect(ipEndPort);

        Console.WriteLine("连接服务器成功");
    }

    public void sendmessage(string sendData)
    {
        Console.WriteLine("发送给服务端消息：" + sendData);

        byte[] bytes = new byte[1024];
        bytes = Encoding.ASCII.GetBytes(sendData);
        m_socket.Send(bytes);

        receive();
    }

    public string receive()
    {
        //while (true)
        {
            byte[] rece = new byte[1024];
            int recelong = m_socket.Receive(rece, rece.Length, 0);
            string reces = Encoding.ASCII.GetString(rece, 0, recelong);

            Console.WriteLine("收到服务端消息：" + reces);

            return reces;
        }
    }
}
