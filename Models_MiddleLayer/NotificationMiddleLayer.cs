using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using HPIMS_MVC_SignalR_Integrated.Models;

namespace HPIMS_MVC_SignalR_Integrated.Models_MiddleLayer
{
    public class NotificationMiddleLayer
    {
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public List<NotificationModel> GetDataList()
        {
            List<NotificationModel> list_index = new List<NotificationModel>();
            string query = "SELECT [Id],[Type],[Subject],[MessageBody],[IsActive] FROM [InfrastructureManager].[dbo].[Notification]";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable datatable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(datatable);
            foreach (DataRow datarow in datatable.Rows)
            {
                list_index.Add(new NotificationModel
                {
                    Id = Convert.ToInt32(datarow[0]),
                    Type = datarow[1] != DBNull.Value ? Convert.ToString(datarow[1]) : "",
                    Subject = datarow[2] != DBNull.Value ? Convert.ToString(datarow[2]) : "",
                    MessageBody = datarow[3] != DBNull.Value ? Convert.ToString(datarow[3]) : "",
                    IsActive = datarow[4] != DBNull.Value ? Convert.ToBoolean(datarow[4]) : false
                });
            }
            return list_index;
        }
        public bool InsertData(NotificationModel NM)
        {
            int i;
            SqlCommand command = new SqlCommand("notification_insert", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Type", NM.Type);
            command.Parameters.AddWithValue("@Subject", NM.Subject);
            command.Parameters.AddWithValue("@MessageBody", NM.MessageBody);
            command.Parameters.AddWithValue("@IsActive", NM.IsActive);
            connection.Open();
            i = command.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool UpdateData(NotificationModel NM)
        {
            int i;
            SqlCommand command = new SqlCommand("notification_update", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", NM.Id);
            command.Parameters.AddWithValue("@Type", NM.Type);
            command.Parameters.AddWithValue("@Subject", NM.Subject);
            command.Parameters.AddWithValue("@MessageBody", NM.MessageBody);
            command.Parameters.AddWithValue("@IsActive", NM.IsActive);
            connection.Open();
            i = command.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool DeleteData(NotificationModel NM)
        {
            int i;
            SqlCommand command = new SqlCommand("notification_delete", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", NM.Id);
            connection.Open();
            i = command.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}