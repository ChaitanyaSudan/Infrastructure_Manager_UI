using ExcelDataReader;
using HPIMS_MVC_SignalR_Integrated.Excel_Import;
using HPIMS_MVC_SignalR_Integrated.Models;
using HPIMS_MVC_SignalR_Integrated.Models_MiddleLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HPIMS_MVC_SignalR_Integrated.Controllers
{
    public class ExcelController : Controller
    {
        private readonly ExcelContext _dbContext;
        public ExcelController()
        {
            _dbContext = new ExcelContext();
        }


        // Notification - Excel Data Import

        [HttpPost]
        public async Task<ActionResult> ImportNotificationFile(HttpPostedFileBase importFile)
        {
            if (importFile == null) return Json(new { Status = 0, Message = "No File Selected" });

            try
            {
                var fileData = NotificationCSVFile(importFile.InputStream);

                var notificationData = fileData.ToDataTable();
                var tableParameter = new SqlParameter("ExcelDataObject", SqlDbType.Structured)
                {
                    TypeName = "dbo.NotificationExcelType",
                    Value = notificationData
                };
                await _dbContext.Database.ExecuteSqlCommandAsync("EXEC NotificationExcelProcedure @ExcelDataObject", tableParameter);
                return Json(new { Status = 1, Message = "File Imported Successfully " });
            }
            catch (Exception ex)
            {
                return Json(new { Status = 0, Message = ex.Message });
            }
        }

        private List<NotificationModel> NotificationCSVFile(Stream stream)
        {
            var dataList = new List<NotificationModel>();
            try
            {
                using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
                {
                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true // To set First Row As Column Names    
                        }
                    });

                    if (dataSet.Tables.Count > 0)
                    {
                        var dataTable = dataSet.Tables[0];
                        foreach (DataRow objDataRow in dataTable.Rows)
                        {
                            if (objDataRow.ItemArray.All(x => string.IsNullOrEmpty(x?.ToString()))) continue;
                            dataList.Add(new NotificationModel()
                            {
                                Id = Convert.ToInt32(objDataRow["Id"].ToString()),
                                Type = objDataRow["Type"] != DBNull.Value ? objDataRow["Type"].ToString() : "",
                                Subject = objDataRow["Subject"] != DBNull.Value ? objDataRow["Subject"].ToString() : "",
                                MessageBody = objDataRow["MessageBody"] != DBNull.Value ? objDataRow["MessageBody"].ToString() : "",
                                IsActive = objDataRow["IsActive"].ToString() != "" ? Convert.ToBoolean(objDataRow["IsActive"].ToString()) : false,
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dataList;
        }

        // Notification Mapping - Excel Data Import

        [HttpPost]
        public async Task<ActionResult> ImportNMFile(HttpPostedFileBase importFile)
        {
            if (importFile == null) return Json(new { Status = 0, Message = "No File Selected" });

            try
            {
                var fileData = NMCSVFile(importFile.InputStream);

                var nmData = fileData.ToDataTable();
                var tableParameter = new SqlParameter("ExcelDataObject", SqlDbType.Structured)
                {
                    TypeName = "dbo.NMExcelType",
                    Value = nmData
                };
                await _dbContext.Database.ExecuteSqlCommandAsync("EXEC NMExcelProcedure @ExcelDataObject", tableParameter);
                return Json(new { Status = 1, Message = "File Imported Successfully " });
            }
            catch (Exception ex)
            {
                return Json(new { Status = 0, Message = ex.Message });
            }
        }

        private List<NotificationMappingModel> NMCSVFile(Stream stream)
        {
            var dataList = new List<NotificationMappingModel>();
            try
            {
                using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
                {
                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true // To set First Row As Column Names    
                        }
                    });

                    if (dataSet.Tables.Count > 0)
                    {
                        var dataTable = dataSet.Tables[0];
                        foreach (DataRow objDataRow in dataTable.Rows)
                        {
                            if (objDataRow.ItemArray.All(x => string.IsNullOrEmpty(x?.ToString()))) continue;
                            dataList.Add(new NotificationMappingModel()
                            {
                                Id = Convert.ToInt32(objDataRow["Id"].ToString()),
                                ServerId = objDataRow["ServerId"] != DBNull.Value ? Convert.ToInt32(objDataRow["ServerId"].ToString()) : Convert.ToInt32(null),
                                ProjectId = objDataRow["ProjectId"] != DBNull.Value ? Convert.ToInt32(objDataRow["ProjectId"].ToString()) : Convert.ToInt32(null),
                                NotificationId = objDataRow["NotificationId"] != DBNull.Value ? Convert.ToInt32(objDataRow["NotificationId"].ToString()) : Convert.ToInt32(null),
                                ToAddress = objDataRow["ToAddress"] != DBNull.Value ? objDataRow["ToAddress"].ToString() : "",
                                CCAddress = objDataRow["CCAddress"] != DBNull.Value ? objDataRow["CCAddress"].ToString() : "",
                                BCCAddress = objDataRow["BCCAddress"] != DBNull.Value ? objDataRow["BCCAddress"].ToString() : "",
                                IsActive = objDataRow["IsActive"].ToString() != "" ? Convert.ToBoolean(objDataRow["IsActive"].ToString()) : false,
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dataList;
        }

        // Project - Excel Data Import

        [HttpPost]
        public async Task<ActionResult> ImportProjectFile(HttpPostedFileBase importFile)
        {
            if (importFile == null) return Json(new { Status = 0, Message = "No File Selected" });

            try
            {
                var fileData = ProjectCSVFile(importFile.InputStream);

                var projectData = fileData.ToDataTable();
                var tableParameter = new SqlParameter("ExcelDataObject", SqlDbType.Structured)
                {
                    TypeName = "dbo.ProjectExcelType",
                    Value = projectData
                };
                await _dbContext.Database.ExecuteSqlCommandAsync("EXEC ProjectExcelProcedure @ExcelDataObject", tableParameter);
                return Json(new { Status = 1, Message = "File Imported Successfully " });
            }
            catch (Exception ex)
            {
                return Json(new { Status = 0, Message = ex.Message });
            }
        }

        private List<ProjectModel> ProjectCSVFile(Stream stream)
        {
            var dataList = new List<ProjectModel>();
            try
            {
                using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
                {
                    
                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true // To set First Row As Column Names    
                        }
                    });

                    if (dataSet.Tables.Count > 0)
                    {
                        var dataTable = dataSet.Tables[0];
                        foreach (DataRow objDataRow in dataTable.Rows)
                        {
                            if (objDataRow.ItemArray.All(x => string.IsNullOrEmpty(x?.ToString()))) continue;
                            dataList.Add(new ProjectModel()
                            {
                                Id = Convert.ToInt32(objDataRow["Id"].ToString()),
                                ProjectName = objDataRow["ProjectName"] != DBNull.Value ? objDataRow["ProjectName"].ToString() : "",
                                Version = objDataRow["Version"] != DBNull.Value ? objDataRow["Version"].ToString() : "",
                                Status = objDataRow["Status"] != DBNull.Value ? objDataRow["Status"].ToString() : "",
                                IsActive = objDataRow["IsActive"].ToString() != "" ? Convert.ToBoolean(objDataRow["IsActive"].ToString()) : false,
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dataList;
        }

        // Project Server Mapping - Excel Data Import

        [HttpPost]
        public async Task<ActionResult> ImportPSMFile(HttpPostedFileBase importFile)
        {
            if (importFile == null) return Json(new { Status = 0, Message = "No File Selected" });

            try
            {
                var fileData = PSMCSVFile(importFile.InputStream);

                var psmData = fileData.ToDataTable();
                var tableParameter = new SqlParameter("ExcelDataObject", SqlDbType.Structured)
                {
                    TypeName = "dbo.PSMExcelType",
                    Value = psmData
                };
                await _dbContext.Database.ExecuteSqlCommandAsync("EXEC PSMExcelProcedure @ExcelDataObject", tableParameter);
                return Json(new { Status = 1, Message = "File Imported Successfully " });
            }
            catch (Exception ex)
            {
                return Json(new { Status = 0, Message = ex.Message });
            }
        }

        ProjectServerMappingMiddleLayer PSMML = new ProjectServerMappingMiddleLayer();
        List<ServerModel> list_server = new List<ServerModel>();
        List<ProjectModel> list_project = new List<ProjectModel>();
        private List<ProjectServerMappingModel> PSMCSVFile(Stream stream)
        {
            string ServerName = "";
            string ProjectName = "";
            long SId=0;
            long PId=0;
            var dataList = new List<ProjectServerMappingModel>();
            try
            {
                using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
                {
                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true // To set First Row As Column Names    
                        }
                    });

                    if (dataSet.Tables.Count > 0)
                    {
                        var dataTable = dataSet.Tables[0];
                        foreach (DataRow objDataRow in dataTable.Rows)
                        {
                            if (objDataRow.ItemArray.All(x => string.IsNullOrEmpty(x?.ToString()))) continue;
                            ServerName = objDataRow["ServerName"] != DBNull.Value ? objDataRow["ServerName"].ToString() : "";
                            ProjectName = objDataRow["ProjectName"] != DBNull.Value ? objDataRow["ProjectName"].ToString() : "";
                            list_server = PSMML.GetPartialServerList();
                            list_project = PSMML.GetPartialProjectList();
                            for(int i = 0; i < list_server.Count; i++)
                            {
                                if(list_server[i].ServerName == ServerName)
                                {
                                    SId = list_server[i].Id;
                                }
                            }
                            for (int i = 0; i < list_project.Count; i++)
                            {
                                if (list_project[i].ProjectName == ProjectName)
                                {
                                    PId = list_project[i].Id;
                                }
                            }
                            dataList.Add(new ProjectServerMappingModel()
                            {
                                Id = Convert.ToInt32(objDataRow["Id"].ToString()),
                                ServerId = SId,
                                ProjectId = PId,
                                IsActive = objDataRow["IsActive"].ToString() != "" ? Convert.ToBoolean(objDataRow["IsActive"].ToString()) : false,
                            }) ;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dataList;
        }

        // Server - Excel Data Import

        [HttpPost]
        public async Task<ActionResult> ImportServerFile(HttpPostedFileBase importFile)
        {
            if (importFile == null) return Json(new { Status = 0, Message = "No File Selected" });

            try
            {
                var fileData = ServerCSVFile(importFile.InputStream);

                var serverData = fileData.ToDataTable();
                var tableParameter = new SqlParameter("ExcelDataObject", SqlDbType.Structured)
                {
                    TypeName = "dbo.ServerExcelType",
                    Value = serverData
                };
                await _dbContext.Database.ExecuteSqlCommandAsync("EXEC ServerExcelProcedure @ExcelDataObject", tableParameter);
                return Json(new { Status = 1, Message = "File Imported Successfully " });
            }
            catch (Exception ex)
            {
                return Json(new { Status = 0, Message = ex.Message });
            }
        }

        private List<ServerModel> ServerCSVFile(Stream stream)
        {
            var dataList = new List<ServerModel>();
            try
            {
                using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
                {
                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true // To set First Row As Column Names    
                        }
                    });

                    if (dataSet.Tables.Count > 0)
                    {
                        var dataTable = dataSet.Tables[0];
                        foreach (DataRow objDataRow in dataTable.Rows)
                        {
                            if (objDataRow.ItemArray.All(x => string.IsNullOrEmpty(x?.ToString()))) continue;
                            dataList.Add(new ServerModel()
                            {
                                Id = Convert.ToInt32(objDataRow["Id"].ToString()),
                                ServerName = objDataRow["ServerName"] != DBNull.Value ? objDataRow["ServerName"].ToString() : "",
                                ServerType = objDataRow["ServerType"] != DBNull.Value ? objDataRow["ServerType"].ToString() : "",
                                Location = objDataRow["Location"] != DBNull.Value ? objDataRow["Location"].ToString() : "",
                                IsServerUp = objDataRow["IsServerUp"].ToString() != "" ? Convert.ToBoolean(objDataRow["IsServerUp"].ToString()) : false,
                                IsUserLoggedIn = objDataRow["IsUserLoggedIn"].ToString() != "" ? Convert.ToBoolean(objDataRow["IsUserLoggedIn"].ToString()) : false,
                                DriveCUsage = objDataRow["DriveCUsage"] != DBNull.Value ? objDataRow["DriveCUsage"].ToString() : "",
                                DriveEUsage = objDataRow["DriveEUsage"] != DBNull.Value ? objDataRow["DriveEUsage"].ToString() : "",
                                DriveFUsage = objDataRow["DriveFUsage"] != DBNull.Value ? objDataRow["DriveFUsage"].ToString() : "",
                                ThresholdUsage = objDataRow["ThresholdUsage"] != DBNull.Value ? Convert.ToInt32(objDataRow["ThresholdUsage"].ToString()) : Convert.ToInt32(null),
                                IsActive = objDataRow["IsActive"].ToString() != "" ? Convert.ToBoolean(objDataRow["IsActive"].ToString()) : false,
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dataList;
        }

        // Server App Configuration - Excel Data Import

        [HttpPost]
        public async Task<ActionResult> ImportSACFile(HttpPostedFileBase importFile)
        {
            if (importFile == null) return Json(new { Status = 0, Message = "No File Selected" });

            try
            {
                var fileData = SACCSVFile(importFile.InputStream);

                var sacData = fileData.ToDataTable();
                var tableParameter = new SqlParameter("ExcelDataObject", SqlDbType.Structured)
                {
                    TypeName = "dbo.SACExcelType",
                    Value = sacData
                };
                await _dbContext.Database.ExecuteSqlCommandAsync("EXEC SACExcelProcedure @ExcelDataObject", tableParameter);
                return Json(new { Status = 1, Message = "File Imported Successfully " });
            }
            catch (Exception ex)
            {
                return Json(new { Status = 0, Message = ex.Message });
            }
        }

        private List<ServerAppConfigurationModel> SACCSVFile(Stream stream)
        {
            var dataList = new List<ServerAppConfigurationModel>();
            try
            {
                using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
                {
                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true // To set First Row As Column Names    
                        }
                    });

                    if (dataSet.Tables.Count > 0)
                    {
                        var dataTable = dataSet.Tables[0];
                        foreach (DataRow objDataRow in dataTable.Rows)
                        {
                            if (objDataRow.ItemArray.All(x => string.IsNullOrEmpty(x?.ToString()))) continue;
                            dataList.Add(new ServerAppConfigurationModel()
                            {
                                Id = Convert.ToInt32(objDataRow["Id"].ToString()),
                                ServerId = objDataRow["ServerId"] != DBNull.Value ? Convert.ToInt32(objDataRow["ServerId"].ToString()) : Convert.ToInt32(null),
                                APPInstalled = objDataRow["APPInstalled"] != DBNull.Value ? objDataRow["APPInstalled"].ToString() : "",
                                IsActive = objDataRow["IsActive"].ToString() != "" ? Convert.ToBoolean(objDataRow["IsActive"].ToString()) : false,
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dataList;
        }
    }
}