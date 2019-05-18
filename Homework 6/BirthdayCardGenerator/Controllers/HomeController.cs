using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BirthdayCardGenerator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Models.BirthdayCard birthdayCard)
        {
            if (ModelState.IsValid)
            {
                return View("Sent", birthdayCard);
            }
            else
            {
                return View();
            }
        }
    }
}