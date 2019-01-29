using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRDatabaseNotification.Hubs
{
    [HubName("messagesHub")]
    public class MessagesHub : Hub
    {
        private static string consString = ConfigurationManager.ConnectionStrings["MessageDbContext"].ConnectionString;
        [HubMethodName("sendMessages")]
        public void SendMessages()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MessagesHub>();
            context.Clients.All.UpdateMessages();
            //return "SendMessage in Server SignalR";
        }
    }
}