using System.Data.Entity;

namespace HPIMS_MVC_SignalR_Integrated.Excel_Import
{
    public class ExcelContext : DbContext
    {
        public ExcelContext() : base("DefaultConnection")
        { }
    }
}