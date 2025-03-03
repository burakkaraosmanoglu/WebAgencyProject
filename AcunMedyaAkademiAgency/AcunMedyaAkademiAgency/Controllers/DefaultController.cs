using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using AcunMedyaAkademiAgency.Context;
using AcunMedyaAkademiAgency.Entities;
using Message = AcunMedyaAkademiAgency.Entities.Message;

namespace AcunMedyaAkademiAgency.Controllers
{
    public class DefaultController : Controller
    {
        AgencyContext context=new AgencyContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult ProjectPartial() 
        {
            var values = context.Projects.OrderByDescending(x => x.ProjectID).Take(3).ToList();   
            return PartialView(values);
        }
        public PartialViewResult ModalPartial()
        {
            var values=context.ProjectDetails.ToList();
            return PartialView(values);
        }
        public PartialViewResult ServicesPartial()
        {
            var values = context.Services.OrderByDescending(x => x.ServiceID).Take(3).ToList();
            return PartialView(values);
        }
        public PartialViewResult AboutPartial()
        {
            var values = context.Abouts.OrderByDescending(x => x.AboutID).Take(4).ToList();
            return PartialView(values);
        }
        public PartialViewResult TeamPartial()
        {
            var values = context.Teams.OrderByDescending(x => x.TeamID).Take(3).ToList();
            return PartialView(values);
        }
        public PartialViewResult MessagePartial()
        {
            var values = context.Messages.ToList();
            return PartialView(values);
        }
        [HttpPost]
        
        public ActionResult SendMessage(Message message)
        {
            Debug.WriteLine("SendMessage çalıştı!"); 
            if (message.NameSurname != null && message.Title != null && message.Email != null && message.Description != null)
            {
                message.SendDate = DateTime.Now;
                message.IsRead = false;
                context.Messages.Add(message);
                context.SaveChanges();

                TempData["successMessage"] = "Mesajınız Başarı İle Gönderildi";

            }
            else
            {
                TempData["errorMessage"] = "Mesajınız Gönderilemedi";
            }
            return Redirect("/Default/Index#contact");
        }
        public PartialViewResult ClientPartial()
        {
            return PartialView();
        }
    }
}