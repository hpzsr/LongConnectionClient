using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Client.Entity
{
    class CodeInfo
    {
        public int m_code;
        public string m_text;

        public CodeInfo(int code, string text)
        {
            m_code = code;
            m_text = text;
        }
    }

    class Entity_code
    {
        static Entity_code s_entity_code = null;

        List<CodeInfo> m_list = new List<CodeInfo>();

        public static Entity_code getInstance()
        {
            if (s_entity_code == null)
            {
                s_entity_code = new Entity_code();
            }

            return s_entity_code;
        }

        public void init()
        {
            string jsonData = "";

            // 读取文件
            {
                StreamReader sr = new StreamReader("code.json", System.Text.Encoding.GetEncoding("utf-8"));
                jsonData = sr.ReadToEnd().ToString();
                sr.Close();
            }

            {
                JArray ja = (JArray)JsonConvert.DeserializeObject(jsonData);
                for (int i = 0; i < ja.Count; i++)
                {
                    int code = Convert.ToInt32(ja[i]["code"]);
                    string text = ja[i]["text"].ToString();

                    m_list.Add(new CodeInfo(code,text));
                }
            }
        }

        public string getCodeInfo(int code)
        {
            for (int i = 0; i < m_list.Count; i++)
            {
                if(code == m_list[i].m_code)
                {
                    return m_list[i].m_text;
                }
            }

            return "";
        }
    }
}
