using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiAgency.Context;
using AcunMedyaAkademiAgency.Entities;

namespace AcunMedyaAkademiAgency.Controllers
{
    public class AboutController : Controller
    {
        AgencyContext Context = new AgencyContext();

        public ActionResult AboutList(string searchText)
        {
            // arama listesi
            List<About> values ;
            if (!string.IsNullOrEmpty(searchText))
            {
                values = Context.Abouts.Where(x => x.Title.Contains(searchText)).ToList();
                return View(values);
            }
            values = Context.Abouts.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAbout(About about)
        {
            Context.Abouts.Add(about);
            Context.SaveChanges();
            return RedirectToAction("AboutList");
        }

        public ActionResult DeleteAbout(int id)
        {
            var value = Context.Abouts.Find(id);
            Context.Abouts.Remove(value);
            Context.SaveChanges();
            return RedirectToAction("AboutList");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = Context.Abouts.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var value = Context.Abouts.Find(about.AboutID);
            value.Title = about.Title;
            value.Description = about.Description;
            value.ImageUrl = about.ImageUrl;

            Context.SaveChanges();
            return RedirectToAction("AboutList");
        }
    }
}