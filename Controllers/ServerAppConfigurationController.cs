using HPIMS_MVC_SignalR_Integrated.Models;
using HPIMS_MVC_SignalR_Integrated.Models_MiddleLayer;
using System.Web.Mvc;

namespace HPIMS_MVC_SignalR_Integrated.Controllers
{
    public class ServerAppConfigurationController : Controller
    {
        ServerAppConfigurationMiddleLayer SACML = new ServerAppConfigurationMiddleLayer();
        public ActionResult ServerAppConfigurationList()
        {
            return View(SACML.GetDataList());
        }
        public ActionResult Details(int Id)
        {
            return View(SACML.GetDataList().Find(SACM => SACM.Id == Id));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ServerAppConfigurationModel SACM)
        {
            try
            {
                if (SACML.InsertData(SACM))
                {
                    ViewBag.Message = "Data Saved";
                }
                return RedirectToAction("ServerAppConfigurationList", "ServerAppConfiguration");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int Id)
        {
            return View(SACML.GetDataList().Find(SACM => SACM.Id == Id));
        }
        [HttpPost]
        public ActionResult Edit(int Id, ServerAppConfigurationModel SACM)
        {
            try
            {
                if (SACML.UpdateData(SACM))
                {
                    ViewBag.Message = "Data Updated";
                }
                return RedirectToAction("ServerAppConfigurationList", "ServerAppConfiguration");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int Id)
        {
            return View(SACML.GetDataList().Find(SACM => SACM.Id == Id));
        }
        [HttpPost]
        public ActionResult Delete(int Id, ServerAppConfigurationModel SACM)
        {
            try
            {
                if (SACML.DeleteData(SACM))
                {
                    ViewBag.Message = "Data Deleted";
                }
                return RedirectToAction("ServerAppConfigurationList", "ServerAppConfiguration");
            }
            catch
            {
                return View();
            }
        }
    }
}