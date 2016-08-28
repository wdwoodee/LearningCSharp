using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SessionMgr
/// </summary>
public class SessionMgr
{
    private static IDictionary<string, IDictionary<string,object>>  data = new Dictionary<string, IDictionary<string,object>>();
    public static IDictionary<string, object> GetSession(string sessionId)
    {
        if (data.ContainsKey(sessionId))
        {
            return data[sessionId];
        }
        else
        {
            IDictionary<string, object> session = new Dictionary<string, object>();
            data[sessionId] = session;
            return session;
        }
    }
}