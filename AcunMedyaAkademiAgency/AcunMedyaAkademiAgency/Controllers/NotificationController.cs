using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiAgency.Context;

namespace AcunMedyaAkademiAgency.Controllers
{
    public class NotificationController : Controller
    {
        AgencyContext Context = new AgencyContext();
        public ActionResult NotificationList()
        {
            var values = Context.Notifications.ToList();
            return View(values);
        }

        public ActionResult DeleteNotification(int id)
        {
            var value = Context.Notifications.Find(id);
            Context.Notifications.Remove(value);
            Context.SaveChanges();

            return RedirectToAction("NotificationList");
        }

    }
}