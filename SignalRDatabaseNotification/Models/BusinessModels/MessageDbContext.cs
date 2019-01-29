using SignalRDatabaseNotification.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SignalRDatabaseNotification.Models.BusinessModels
{
    public class MessageDbContext: DbContext
    {
        public MessageDbContext(): base("MessageDbContext")
        {

        }
        public DbSet<Messages> Messages { get; set; }
    }
}