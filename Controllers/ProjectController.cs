using HPIMS_MVC_SignalR_Integrated.Models;
using HPIMS_MVC_SignalR_Integrated.Models_MiddleLayer;
using System.Web.Mvc;

namespace HPIMS_MVC_SignalR_Integrated.Controllers
{
    public class ProjectController : Controller
    {
        ProjectMiddleLayer PML = new ProjectMiddleLayer();
        public ActionResult ProjectList()
        {
            return View(PML.GetDataList());
        }
        public ActionResult Details(int Id)
        {
            return View(PML.GetDataList().Find(PM => PM.Id == Id));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProjectModel PM)
        {
            try
            {
                if (PML.InsertData(PM))
                {
                    ViewBag.Message = "Data Saved";
                }
                return RedirectToAction("ProjectList", "Project");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int Id)
        {
            return View(PML.GetDataList().Find(PM => PM.Id == Id));
        }
        [HttpPost]
        public ActionResult Edit(int Id, ProjectModel PM)
        {
            try
            {
                if (PML.UpdateData(PM))
                {
                    ViewBag.Message = "Data Updated";
                }
                return RedirectToAction("ProjectList", "Project");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int Id)
        {
            return View(PML.GetDataList().Find(PM => PM.Id == Id));
        }
        [HttpPost]
        public ActionResult Delete(int Id, ProjectModel PM)
        {
            try
            {
                if (PML.DeleteData(PM))
                {
                    ViewBag.Message = "Data Deleted";
                }
                return RedirectToAction("ProjectList", "Project");
            }
            catch
            {
                return View();
            }
        }
    }
}