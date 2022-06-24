using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using HPIMS_MVC_SignalR_Integrated.Models;

namespace HPIMS_MVC_SignalR_Integrated.Models_MiddleLayer
{
    public class ProjectServerMappingMiddleLayer
    {
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public List<ProjectServerMappingModel> GetDataList()
        {
            List<ProjectServerMappingModel> list_index = new List<ProjectServerMappingModel>();
            string query = "SELECT [Id],[ServerId],[ProjectId],[IsActive] FROM [InfrastructureManager].[dbo].[ProjectServerMapping]";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable datatable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(datatable);
            foreach (DataRow datarow in datatable.Rows)
            {
                list_index.Add(new ProjectServerMappingModel
                {
                    Id = Convert.ToInt32(datarow[0]),
                    ServerId = datarow[1] != DBNull.Value ? Convert.ToInt32(datarow[1]) : Convert.ToInt32(null),
                    ProjectId = datarow[2] != DBNull.Value ? Convert.ToInt32(datarow[2]) : Convert.ToInt32(null),
                    IsActive = datarow[3] != DBNull.Value ? Convert.ToBoolean(datarow[3]) : false
                });
            }
            return list_index;
        }
        public bool InsertData(ProjectServerMappingModel PSMM)
        {
            int i;
            SqlCommand command = new SqlCommand("projectServerMapping_insert", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ServerId", PSMM.ServerId);
            command.Parameters.AddWithValue("@ProjectId", PSMM.ProjectId);
            command.Parameters.AddWithValue("@IsActive", PSMM.IsActive);
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

        public bool UpdateData(ProjectServerMappingModel PSMM)
        {
            int i;
            SqlCommand command = new SqlCommand("projectServerMapping_update", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", PSMM.Id);
            command.Parameters.AddWithValue("@ServerId", PSMM.ServerId);
            command.Parameters.AddWithValue("@ProjectId", PSMM.ProjectId);
            command.Parameters.AddWithValue("@IsActive", PSMM.IsActive);
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
        public bool DeleteData(ProjectServerMappingModel PSMM)
        {
            int i;
            SqlCommand command = new SqlCommand("projectServerMapping_delete", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", PSMM.Id);
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

        public List<ServerModel> GetPartialServerList()
        {
            List<ServerModel> list_server = new List<ServerModel>();
            string query = "SELECT [Id],[ServerName] FROM [InfrastructureManager].[dbo].[Server]";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable datatable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(datatable);
            foreach (DataRow datarow in datatable.Rows)
            {
                list_server.Add(new ServerModel
                {
                    Id = Convert.ToInt32(datarow[0]),
                    ServerName = datarow[1] != DBNull.Value ? Convert.ToString(datarow[1]) : ""
                });
            }
            return list_server;
        }

        public List<ProjectModel> GetPartialProjectList()
        {
            List<ProjectModel> list_project = new List<ProjectModel>();
            string query = "SELECT [Id],[ProjectName] FROM [InfrastructureManager].[dbo].[Project]";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable datatable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(datatable);
            foreach (DataRow datarow in datatable.Rows)
            {
                list_project.Add(new ProjectModel
                {
                    Id = Convert.ToInt32(datarow[0]),
                    ProjectName = datarow[1] != DBNull.Value ? Convert.ToString(datarow[1]) : ""
                });
            }
            return list_project;
        }
    }
}