using HPIMS_MVC_SignalR_Integrated.Models;
using HPIMS_MVC_SignalR_Integrated.Models_MiddleLayer;
using System.Web.Mvc;

namespace HPIMS_MVC_SignalR_Integrated.Controllers
{
    public class NotificationController : Controller
    {
        NotificationMiddleLayer NML = new NotificationMiddleLayer();
        public ActionResult NotificationList()
        {
            return View(NML.GetDataList());
        }
        public ActionResult Details(int Id)
        {
            return View(NML.GetDataList().Find(NM => NM.Id == Id));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NotificationModel NM)
        {
            try
            {
                if (NML.InsertData(NM))
                {
                    ViewBag.Message = "Data Saved";
                }
                return RedirectToAction("NotificationList", "Notification");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int Id)
        {
            return View(NML.GetDataList().Find(NM => NM.Id == Id));
        }
        [HttpPost]
        public ActionResult Edit(int Id, NotificationModel NM)
        {
            try
            {
                if (NML.UpdateData(NM))
                {
                    ViewBag.Message = "Data Updated";
                }
                return RedirectToAction("NotificationList", "Notification");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int Id)
        {
            return View(NML.GetDataList().Find(NM => NM.Id == Id));
        }
        [HttpPost]
        public ActionResult Delete(int Id, NotificationModel NM)
        {
            try
            {
                if (NML.DeleteData(NM))
                {
                    ViewBag.Message = "Data Deleted";
                }
                return RedirectToAction("NotificationList", "Notification");
            }
            catch
            {
                return View();
            }
        }
    }
}