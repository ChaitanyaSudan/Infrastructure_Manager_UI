using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using HPIMS_MVC_SignalR_Integrated.Models;

namespace HPIMS_MVC_SignalR_Integrated.Models_MiddleLayer
{
    public class NotificationMappingMiddleLayer
    {
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public List<NotificationMappingModel> GetDataList()
        {
            List<NotificationMappingModel> list_index = new List<NotificationMappingModel>();
            string query = "SELECT [Id],[ServerId],[ProjectId],[NotificationId],[ToAddress],[CCAddress],[BCCAddress],[IsActive] FROM [InfrastructureManager].[dbo].[NotificationMapping]";
            SqlCommand command = new SqlCommand(query,connection);
            DataTable datatable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(datatable);
            foreach (DataRow datarow in datatable.Rows)
            {
                list_index.Add(new NotificationMappingModel
                {
                    Id = Convert.ToInt32(datarow[0]),
                    ServerId = datarow[1] != DBNull.Value ? Convert.ToInt32(datarow[1]) : Convert.ToInt32(null),
                    ProjectId = datarow[2] != DBNull.Value ? Convert.ToInt32(datarow[2]) : Convert.ToInt32(null),
                    NotificationId = datarow[3] != DBNull.Value ? Convert.ToInt32(datarow[3]) : Convert.ToInt32(null),
                    ToAddress = datarow[4] != DBNull.Value ? Convert.ToString(datarow[4]) : "",
                    CCAddress = datarow[5] != DBNull.Value ? Convert.ToString(datarow[5]) : "",
                    BCCAddress = datarow[6] != DBNull.Value ? Convert.ToString(datarow[6]) : "",
                    IsActive = datarow[7] != DBNull.Value ? Convert.ToBoolean(datarow[7]) : false
                });
            }
            return list_index;
        }
        public bool InsertData(NotificationMappingModel NMM)
        {
            int i;
            SqlCommand command = new SqlCommand("notificationMapping_insert", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ServerId", NMM.ServerId);
            command.Parameters.AddWithValue("@ProjectId", NMM.ProjectId);
            command.Parameters.AddWithValue("@NotificationId", NMM.NotificationId);
            command.Parameters.AddWithValue("@ToAddress", NMM.ToAddress);
            command.Parameters.AddWithValue("@CCAddress", NMM.CCAddress);
            command.Parameters.AddWithValue("@BCCAddress", NMM.BCCAddress);
            command.Parameters.AddWithValue("@IsActive", NMM.IsActive);
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

        public bool UpdateData(NotificationMappingModel NMM)
        {
            int i;
            SqlCommand command = new SqlCommand("notificationMapping_update", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", NMM.Id);
            command.Parameters.AddWithValue("@ServerId", NMM.ServerId);
            command.Parameters.AddWithValue("@ProjectId", NMM.ProjectId);
            command.Parameters.AddWithValue("@NotificationId", NMM.NotificationId);
            command.Parameters.AddWithValue("@ToAddress", NMM.ToAddress);
            command.Parameters.AddWithValue("@CCAddress", NMM.CCAddress);
            command.Parameters.AddWithValue("@BCCAddress", NMM.BCCAddress);
            command.Parameters.AddWithValue("@IsActive", NMM.IsActive);
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
        public bool DeleteData(NotificationMappingModel NMM)
        {
            int i;
            SqlCommand command = new SqlCommand("notificationMapping_delete", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", NMM.Id);
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