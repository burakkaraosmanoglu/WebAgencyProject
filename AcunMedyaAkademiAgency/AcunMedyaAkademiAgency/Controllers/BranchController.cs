using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiAgency.Context;
using AcunMedyaAkademiAgency.Entities;

namespace AcunMedyaAkademiAgency.Controllers
{
    public class BranchController : Controller
    {
        AgencyContext Context = new AgencyContext();
        public ActionResult BranchList()
        {
            var values = Context.Branches.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateBranch()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBranch(Branch branch)
        {
            Context.Branches.Add(branch);
            Context.SaveChanges();

            return RedirectToAction("BranchList");
        }

        public ActionResult DeleteBranch(int id)
        {
            var value = Context.Branches.Find(id);
            Context.Branches.Remove(value);
            Context.SaveChanges();
            return RedirectToAction("BranchList");
        }

        [HttpGet]
        public ActionResult UpdateBranch(int id)
        {
            var value = Context.Branches.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateBranch(Branch branch)
        {
            var value = Context.Branches.Find(branch.BranchID);
            value.BranchName = branch.BranchName;
            Context.SaveChanges();

            return RedirectToAction("BranchList");
        }
    }
}