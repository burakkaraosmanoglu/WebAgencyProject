using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiAgency.Context;
using AcunMedyaAkademiAgency.Entities;

namespace AcunMedyaAkademiAgency.Controllers
{
    public class MessageController : Controller
    {
        AgencyContext Context = new AgencyContext();
        public ActionResult MessageList(string searchText)
        {
            // arama listesi
            List<Message> values;
            if (!string.IsNullOrEmpty(searchText))
            {
                values = Context.Messages.Where(x => x.NameSurname.Contains(searchText)).ToList();
                return View(values);
            }

            values = Context.Messages.ToList();
            return View(values);
        }

        public ActionResult DeleteMessage(int id)
        {
            var value = Context.Messages.Find(id);
            Context.Messages.Remove(value);
            Context.SaveChanges();
            return RedirectToAction("MessageList");
        }

        public ActionResult MessageDetail(int id)
        {
            var value = Context.Messages.Find(id);
            return View(value);
        }
    }
}