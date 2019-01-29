using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SignalRDatabaseNotification.Models.DataModels
{
    public class Messages
    {
        [Key]
        public int MessageId { get; set; }
        public string Message { get; set; }
        public string EmptyMessage { get; set; }
        public DateTime MessgeDate { get; set; }
    }
}