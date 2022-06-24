using HPIMS_MVC_SignalR_Integrated.Models;
using HPIMS_MVC_SignalR_Integrated.Models_MiddleLayer;
using System.Web.Mvc;

namespace HPIMS_MVC_SignalR_Integrated.Controllers
{
    public class NotificationMappingController : Controller
    {
        NotificationMappingMiddleLayer NMML = new NotificationMappingMiddleLayer();
        public ActionResult NotificationMappingList()
        {
            return View(NMML.GetDataList());
        }
        public ActionResult Details(int Id)
        {
            return View(NMML.GetDataList().Find(NMM => NMM.Id == Id));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NotificationMappingModel NMM)
        {
            try
            {
                if (NMML.InsertData(NMM))
                {
                    ViewBag.Message = "Data Saved";
                }
                return RedirectToAction("NotificationMappingList", "NotificationMapping");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int Id)
        {
            return View(NMML.GetDataList().Find(NMM => NMM.Id == Id));
        }
        [HttpPost]
        public ActionResult Edit(int Id, NotificationMappingModel NMM)
        {
            try
            {
                if (NMML.UpdateData(NMM))
                {
                    ViewBag.Message = "Data Updated";
                }
                return RedirectToAction("NotificationMappingList", "NotificationMapping");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int Id)
        {
            return View(NMML.GetDataList().Find(NMM => NMM.Id == Id));
        }
        [HttpPost]
        public ActionResult Delete(int Id, NotificationMappingModel NMM)
        {
            try
            {
                if (NMML.DeleteData(NMM))
                {
                    ViewBag.Message = "Data Deleted";
                }
                return RedirectToAction("NotificationMappingList", "NotificationMapping");
            }
            catch
            {
                return View();
            }
        }
    }
}