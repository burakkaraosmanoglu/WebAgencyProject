using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiAgency.Context;
using AcunMedyaAkademiAgency.Entities;

namespace AcunMedyaAkademiAgency.Controllers
{
    public class TeamController : Controller
    {
        AgencyContext Context = new AgencyContext();
        public ActionResult TeamList()
        {
            var values = Context.Teams.ToList();
            return View(values);
        }

        public ActionResult DeleteTeam(int id)
        {
            var value = Context.Teams.Find(id);
            Context.Teams.Remove(value);
            Context.SaveChanges();

            return RedirectToAction("TeamList");
        }

        [HttpGet]
        public ActionResult CreateTeam()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTeam(Team team)
        {
            Context.Teams.Add(team);
            Context.SaveChanges();
            return RedirectToAction("TeamList");
        }


        [HttpGet]
        public ActionResult UpdateTeam(int id)
        {
            var value = Context.Teams.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTeam(Team team)
        {
            var value = Context.Teams.Find(team.TeamID);

            value.NameSurname = team.NameSurname;
            value.ImageUrl = team.ImageUrl;
            value.Gender = team.Gender;
            value.City = team.City;
            Context.SaveChanges();
            return RedirectToAction("TeamList");
        }
    }
}