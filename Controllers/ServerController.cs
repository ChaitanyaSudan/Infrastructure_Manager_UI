using HPIMS_MVC_SignalR_Integrated.Models;
using HPIMS_MVC_SignalR_Integrated.Models_MiddleLayer;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace HPIMS_MVC_SignalR_Integrated.Controllers
{
    public class ServerController : Controller
    {
        ServerMiddleLayer SML = new ServerMiddleLayer();
        public ActionResult ServerList(int? page)
        {
            return View(SML.GetDataList().ToPagedList(page?? 1,10));
        }
        public ActionResult Details(int Id)
        {
            return View(SML.GetDataList().Find(SM => SM.Id == Id));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ServerModel SM)
        {
            try
            {
                if (SML.InsertData(SM))
                {
                    ViewBag.Message = "Data Saved";
                }
                return RedirectToAction("ServerList","Server");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int Id)
        {
            return View(SML.GetDataList().Find(SM => SM.Id == Id));
        }
        [HttpPost]
        public ActionResult Edit(int Id, ServerModel SM)
        {
            try
            {
                if (SML.UpdateData(SM))
                {
                    ViewBag.Message = "Data Updated";
                }
                return RedirectToAction("ServerList","Server");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int Id)
        {
            return View(SML.GetDataList().Find(SM => SM.Id == Id));
        }
        [HttpPost]
        public ActionResult Delete(int Id, ServerModel SM)
        {
            try
            {
                if (SML.DeleteData(SM))
                {
                    ViewBag.Message = "Data Deleted";
                }
                return RedirectToAction("ServerList","Server");
            }
            catch
            {
                return View();
            }
        }
    }
}