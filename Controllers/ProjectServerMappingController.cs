using HPIMS_MVC_SignalR_Integrated.Models;
using HPIMS_MVC_SignalR_Integrated.Models_MiddleLayer;
using System.Web.Mvc;

namespace HPIMS_MVC_SignalR_Integrated.Controllers
{
    public class ProjectServerMappingController : Controller
    {
        ProjectServerMappingMiddleLayer PSMML = new ProjectServerMappingMiddleLayer();
        public ActionResult ProjectServerMappingList()
        {
            return View(PSMML.GetDataList());
        }
        public ActionResult Details(int Id)
        {
            return View(PSMML.GetDataList().Find(PSMM => PSMM.Id == Id));
        }
        public ActionResult Create()
        {
            ViewBag.ServerData = new SelectList(PSMML.GetPartialServerList(),"Id", "ServerName");
            ViewBag.ProjectName = new SelectList(PSMML.GetPartialProjectList(), "Id", "ProjectName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProjectServerMappingModel PSMM)
        {
            try
            {
                if (PSMML.InsertData(PSMM))
                {
                    ViewBag.Message = "Data Saved";
                }
                return RedirectToAction("ProjectServerMappingList", "ProjectServerMapping");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int Id)
        {
            ViewBag.ServerData = new SelectList(PSMML.GetPartialServerList(), "Id", "ServerName");
            ViewBag.ProjectName = new SelectList(PSMML.GetPartialProjectList(), "Id", "ProjectName");
            return View(PSMML.GetDataList().Find(PSMM => PSMM.Id == Id));
        }
        [HttpPost]
        public ActionResult Edit(int Id, ProjectServerMappingModel PSMM)
        {
            try
            {
                if (PSMML.UpdateData(PSMM))
                {
                    ViewBag.Message = "Data Updated";
                }
                return RedirectToAction("ProjectServerMappingList", "ProjectServerMapping");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int Id)
        {
            return View(PSMML.GetDataList().Find(PSMM => PSMM.Id == Id));
        }
        [HttpPost]
        public ActionResult Delete(int Id, ProjectServerMappingModel PSMM)
        {
            try
            {
                if (PSMML.DeleteData(PSMM))
                {
                    ViewBag.Message = "Data Deleted";
                }
                return RedirectToAction("ProjectServerMappingList", "ProjectServerMapping");
            }
            catch
            {
                return View();
            }
        }
    }
}