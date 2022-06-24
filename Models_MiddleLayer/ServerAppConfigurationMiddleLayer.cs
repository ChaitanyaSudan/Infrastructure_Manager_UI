using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using HPIMS_MVC_SignalR_Integrated.Models;

namespace HPIMS_MVC_SignalR_Integrated.Models_MiddleLayer
{
    public class ServerAppConfigurationMiddleLayer
    {
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public List<ServerAppConfigurationModel> GetDataList()
        {
            List<ServerAppConfigurationModel> list_index = new List<ServerAppConfigurationModel>();
            string query = "SELECT [Id],[ServerId],[APPInstalled],[IsActive] FROM [InfrastructureManager].[dbo].[ServerAppConfiguration]";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable datatable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(datatable);
            foreach (DataRow datarow in datatable.Rows)
            {
                list_index.Add(new ServerAppConfigurationModel
                {
                    Id = Convert.ToInt32(datarow[0]),
                    ServerId = datarow[1] != DBNull.Value ? Convert.ToInt32(datarow[1]) : Convert.ToInt32(null),
                    APPInstalled = datarow[2] != DBNull.Value ? Convert.ToString(datarow[2]) : "",
                    IsActive = datarow[3] != DBNull.Value ? Convert.ToBoolean(datarow[3]) : false
                });
            }
            return list_index;
        }
        public bool InsertData(ServerAppConfigurationModel SACM)
        {
            int i;
            SqlCommand command = new SqlCommand("serverAppConfiguration_insert", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ServerId", SACM.ServerId);
            command.Parameters.AddWithValue("@APPInstalled", SACM.APPInstalled);
            command.Parameters.AddWithValue("@IsActive", SACM.IsActive);
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

        public bool UpdateData(ServerAppConfigurationModel SACM)
        {
            int i;
            SqlCommand command = new SqlCommand("serverAppConfiguration_update", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", SACM.Id);
            command.Parameters.AddWithValue("@ServerId", SACM.ServerId);
            command.Parameters.AddWithValue("@APPInstalled", SACM.APPInstalled);
            command.Parameters.AddWithValue("@IsActive", SACM.IsActive);
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
        public bool DeleteData(ServerAppConfigurationModel SACM)
        {
            int i;
            SqlCommand command = new SqlCommand("serverAppConfiguration_delete", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", SACM.Id);
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