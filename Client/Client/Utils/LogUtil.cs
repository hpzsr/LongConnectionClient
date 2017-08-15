using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class LogUtil
{
    static LogUtil s_logUtil = null;

    bool m_isStartRecordLog = false;
    List<string> m_waitRecoedLogList = new List<string>();

    public static LogUtil getInstance()
    {
        if (s_logUtil == null)
        {
            s_logUtil = new LogUtil();
        }

        return s_logUtil;
    }

    public void startRecordLog()
    {
        m_isStartRecordLog = true;

        Thread t = new Thread(checkLogList);
        t.Start();
    }

    public void stopRecordLog()
    {
        m_isStartRecordLog = false;
    }

    // 添加日志，\r\n为换行
    public void addLog(string data)
    {
        m_waitRecoedLogList.Add(getCurTime() + "----" + data);
    }

    void checkLogList()
    {
        while (m_isStartRecordLog)
        {
            if (m_waitRecoedLogList.Count > 0)
            {
                writeLogToLocal(m_waitRecoedLogList[0]);
                m_waitRecoedLogList.RemoveAt(0);
            }
        }
    }

    void writeLogToLocal(string data)
    {
        StreamWriter sw = null;
        try
        {
            sw = new StreamWriter("log.txt", true);

            //开始写入
            sw.WriteLine(data);

            //清空缓冲区
            sw.Flush();
            
            //关闭流
            sw.Close();
        }
        catch (IOException e)
        {
            Console.Write(e);
        }
        finally
        {
            sw.Close();
        }
    }

    string getCurTime()
    {
        return DateTime.Now.ToString();
    }
}
