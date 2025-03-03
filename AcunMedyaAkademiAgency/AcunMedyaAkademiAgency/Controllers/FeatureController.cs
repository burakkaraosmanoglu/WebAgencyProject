using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiAgency.Context;
using AcunMedyaAkademiAgency.Entities;

namespace AcunMedyaAkademiAgency.Controllers
{
    public class FeatureController : Controller
    {
        AgencyContext Context = new AgencyContext();
        public ActionResult FeatureList()
        {
            var value = Context.Features.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateFeature(Feature feature)
        {
            Context.Features.Add(feature);
            Context.SaveChanges();
            return RedirectToAction("FeatureList");
        }

        public ActionResult DeleteFeature(int id)
        {
            var value = Context.Features.Find(id);
            Context.Features.Remove(value);
            Context.SaveChanges();

            return RedirectToAction("FeatureList");
        }

        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var value = Context.Features.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateFeature(Feature feature)
        {
            var value = Context.Features.Find(feature.FeatureID);
            value.Title = feature.Title;
            value.Description = feature.Description;
            value.ImageUrl = feature.ImageUrl;
            Context.SaveChanges();

            return RedirectToAction("FeatureList");
        }
    }
}