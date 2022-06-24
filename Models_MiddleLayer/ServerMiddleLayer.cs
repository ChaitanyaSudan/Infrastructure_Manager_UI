using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using HPIMS_MVC_SignalR_Integrated.Models;

namespace HPIMS_MVC_SignalR_Integrated.Models_MiddleLayer
{
    public class ServerMiddleLayer
    {
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public List<ServerModel> GetDataList()
        {
            List<ServerModel> list_index = new List<ServerModel>();
            string query = "SELECT [Id],[ServerName],[ServerType],[Location],[IsServerUp],[IsUserLoggedIn],[DriveCUsage],[DriveEUsage],[DriveFUsage],[ThresholdUsage],[IsActive] FROM [InfrastructureManager].[dbo].[Server]";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable datatable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(datatable);
            /*SqlDependency dependency = new SqlDependency(command);
            dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }*/
            foreach (DataRow datarow in datatable.Rows)
            {
                list_index.Add(new ServerModel
                {
                    Id = Convert.ToInt32(datarow[0]),
                    ServerName = datarow[1] != DBNull.Value ? Convert.ToString(datarow[1]) : "",
                    ServerType = datarow[2] != DBNull.Value ? Convert.ToString(datarow[2]) : "",
                    Location = datarow[3] != DBNull.Value ? Convert.ToString(datarow[3]) : "",
                    IsServerUp = datarow[4] != DBNull.Value ? Convert.ToBoolean(datarow[4]) : false,
                    IsUserLoggedIn = datarow[5] != DBNull.Value ? Convert.ToBoolean(datarow[5]) : false,
                    DriveCUsage =  datarow[6] != DBNull.Value ? Convert.ToString(datarow[6]) : "",
                    DriveEUsage =  datarow[7] != DBNull.Value ? Convert.ToString(datarow[7]) : "",
                    DriveFUsage =  datarow[8] != DBNull.Value ? Convert.ToString(datarow[8]) : "",
                    ThresholdUsage = datarow[9] != DBNull.Value ? Convert.ToInt32(datarow[9]) : Convert.ToInt32(null),
                    IsActive =  datarow[10] != DBNull.Value ? Convert.ToBoolean(datarow[10]) : false

                });
            }
            return list_index;
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                System.Diagnostics.Debug.WriteLine("Hi");
            }
        }

        public bool InsertData(ServerModel SM)
        {
            int i;
            SqlCommand command = new SqlCommand("server_insert", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ServerName", SM.ServerName);
            command.Parameters.AddWithValue("@ServerType", SM.ServerType);
            command.Parameters.AddWithValue("@Location", SM.Location);
            command.Parameters.AddWithValue("@IsServerUp", SM.IsServerUp);
            command.Parameters.AddWithValue("@IsUserLoggedIn", SM.IsUserLoggedIn);
            command.Parameters.AddWithValue("@DriveCUsage", SM.DriveCUsage);
            command.Parameters.AddWithValue("@DriveEUsage", SM.DriveEUsage);
            command.Parameters.AddWithValue("@DriveFUsage", SM.DriveFUsage);
            command.Parameters.AddWithValue("@ThresholdUsage", SM.ThresholdUsage);
            command.Parameters.AddWithValue("@IsActive", SM.IsActive);
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

        public bool UpdateData(ServerModel SM)
        {
            int i;
            SqlCommand command = new SqlCommand("server_update", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", SM.Id);
            command.Parameters.AddWithValue("@ServerName", SM.ServerName);
            command.Parameters.AddWithValue("@ServerType", SM.ServerType);
            command.Parameters.AddWithValue("@Location", SM.Location);
            command.Parameters.AddWithValue("@IsServerUp", SM.IsServerUp);
            command.Parameters.AddWithValue("@IsUserLoggedIn", SM.IsUserLoggedIn);
            command.Parameters.AddWithValue("@DriveCUsage", SM.DriveCUsage);
            command.Parameters.AddWithValue("@DriveEUsage", SM.DriveEUsage);
            command.Parameters.AddWithValue("@DriveFUsage", SM.DriveFUsage);
            command.Parameters.AddWithValue("@ThresholdUsage", SM.ThresholdUsage);
            command.Parameters.AddWithValue("@IsActive", SM.IsActive);
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
        public bool DeleteData(ServerModel SM)
        {
            int i;
            SqlCommand command = new SqlCommand("server_delete", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", SM.Id);
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