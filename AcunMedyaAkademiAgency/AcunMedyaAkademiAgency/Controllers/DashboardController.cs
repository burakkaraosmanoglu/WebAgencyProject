using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiAgency.Context;

namespace AcunMedyaAkademiAgency.Controllers
{
    public class DashboardController : Controller
    {
        AgencyContext context=new AgencyContext();
        public ActionResult Index()
        {
            ViewBag.bildirimsayisi = context.Notifications.ToList().Count();
            ViewBag.projectsayisi=context.Projects.ToList().Count();
            int categoryww = context.Categories.Where(x => x.CategoryName == "Dijital Pazarlama ve Reklam").Select(y => y.CategoryID).FirstOrDefault();
            ViewBag.wwCount=context.Projects.Where(x=>x.CategoryID==categoryww).Count();
            ViewBag.personelsayisi = context.Teams.ToList().Count();
            return View();
        }
        public ActionResult StaffPartial()
        {
            var values = context.Teams.ToList();
            return PartialView(values);
        }
        public ActionResult MessDbPartial() 
        {
            var values = context.Messages.ToList();
            return PartialView(values);
        }

    }
}