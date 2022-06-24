using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using HPIMS_MVC_SignalR_Integrated.Models;

namespace HPIMS_MVC_SignalR_Integrated.Models_MiddleLayer
{
    public class ProjectMiddleLayer
    {
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public List<ProjectModel> GetDataList()
        {
            List<ProjectModel> list_index = new List<ProjectModel>();
            string query = "SELECT [Id],[ProjectName],[Version],[Status],[IsActive] FROM [InfrastructureManager].[dbo].[Project]";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable datatable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(datatable);
            foreach (DataRow datarow in datatable.Rows)
            {
                list_index.Add(new ProjectModel
                {
                    Id = Convert.ToInt32(datarow[0]),
                    ProjectName = datarow[1] != DBNull.Value ? Convert.ToString(datarow[1]) : "",
                    Version = datarow[2] != DBNull.Value ? Convert.ToString(datarow[2]) : "",
                    Status = datarow[3] != DBNull.Value ? Convert.ToString(datarow[3]) : "",
                    IsActive = datarow[4] != DBNull.Value ? Convert.ToBoolean(datarow[4]) : false
                });
            }
            return list_index;
        }
        public bool InsertData(ProjectModel PM)
        {
            int i;
            SqlCommand command = new SqlCommand("project_insert", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ProjectName", PM.ProjectName);
            command.Parameters.AddWithValue("@Version", PM.Version);
            command.Parameters.AddWithValue("@Status", PM.Status);
            command.Parameters.AddWithValue("@IsActive", PM.IsActive);
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

        public bool UpdateData(ProjectModel PM)
        {
            int i;
            SqlCommand command = new SqlCommand("project_update", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", PM.Id);
            command.Parameters.AddWithValue("@ProjectName", PM.ProjectName);
            command.Parameters.AddWithValue("@Version", PM.Version);
            command.Parameters.AddWithValue("@Status", PM.Status);
            command.Parameters.AddWithValue("@IsActive", PM.IsActive);
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
        public bool DeleteData(ProjectModel PM)
        {
            int i;
            SqlCommand command = new SqlCommand("project_delete", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", PM.Id);
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