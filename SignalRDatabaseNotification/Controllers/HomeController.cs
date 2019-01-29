using SignalRDatabaseNotification.Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRDatabaseNotification.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetMessages()
        {
            MessagesRepository messagesRepository = new MessagesRepository();
            return PartialView("_MessagesList", messagesRepository.GetAllMessages());
        }
    }
}