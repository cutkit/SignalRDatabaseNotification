using SignalRDatabaseNotification.Hubs;
using SignalRDatabaseNotification.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SignalRDatabaseNotification.Models.BusinessModels
{
    public class MessagesRepository
    {
        readonly string _connString = ConfigurationManager.ConnectionStrings["MessageDbContext"].ConnectionString;

        public IEnumerable<Messages> GetAllMessages()
        {
            var messages = new List<Messages>();
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                using (var command = new SqlCommand(@"SELECT [MessageId], [Message], [EmptyMessage], [MessgeDate] FROM [dbo].[Messages]", connection))
                {
                    command.Notification = null;
                    var dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_Onchange);
                    if (connection.State == System.Data.ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        messages.Add(item: new Messages
                        {
                            MessageId = (int)reader["MessageId"],
                            Message = (string)reader["Message"],
                            EmptyMessage = reader["EmptyMessage"] != DBNull.Value ?
                            (string)reader["EmptyMessage"] : "",
                            MessgeDate = Convert.ToDateTime(reader["MessgeDate"])
                        });
                    }
                }
            }
            return messages;
        }

        private void dependency_Onchange(object sender, SqlNotificationEventArgs e)
        {
            MessagesHub messagesHub = new MessagesHub();
            messagesHub.SendMessages();
        }
    }
}