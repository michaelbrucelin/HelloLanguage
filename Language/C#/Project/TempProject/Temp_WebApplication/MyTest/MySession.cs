using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Temp_WebApplication.MyTest
{
    //模拟一个Session类
    public class MySession
    {
        public MySession()
        { }

        private static IDictionary<string, IDictionary<string, object>> data = new Dictionary<string, IDictionary<string, object>>();

        public static IDictionary<string, object> GetSession(string sessionId)
        {
            if (data.ContainsKey(sessionId))
            {
                return data[sessionId];
            }
            else
            {
                IDictionary<string, object> session = new Dictionary<string, object>();
                data.Add(sessionId, session);

                return session;
            }
        }
    }
}