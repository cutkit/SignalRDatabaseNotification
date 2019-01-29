using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRDatabaseNotification.Hubs
{
    [HubName("myHub")]
    public class MyHub: Hub
    {
        public void SendMessages()
        {
            Clients.All.sendMessages("Send auto messages - Server");
        }
        [HubMethodName("getTime")]
        public DateTime GetTime()
        {
            return DateTime.Now;
        }
    }

}