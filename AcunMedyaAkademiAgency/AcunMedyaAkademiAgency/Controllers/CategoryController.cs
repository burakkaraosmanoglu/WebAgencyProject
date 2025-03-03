using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaAkademiAgency.Context;
using AcunMedyaAkademiAgency.Entities;

namespace AcunMedyaAkademiAgency.Controllers
{
    public class CategoryController : Controller
    {
        
            AgencyContext Context = new AgencyContext();
            public ActionResult CategoryList()
            {
                var values = Context.Categories.ToList();
                return View(values);
            }

            public ActionResult DeleteCategory(int id)
            {
                var value = Context.Categories.Find(id);
                Context.Categories.Remove(value);
                Context.SaveChanges();

                return RedirectToAction("CategoryList");

            }

            [HttpGet]
            public ActionResult CreateCategory()
            {
                return View();
            }
            [HttpPost]
            public ActionResult CreateCategory(Category category)
            {
                Context.Categories.Add(category);
                Context.SaveChanges();

                return RedirectToAction("CategoryList");
            }

            [HttpGet]
            public ActionResult UpdateCategory(int id)
            {
                var value = Context.Categories.Find(id);
                return View(value);
            }
            [HttpPost]
            public ActionResult UpdateCategory(Category category)
            {
                var value = Context.Categories.Find(category.CategoryID);

                value.CategoryName = category.CategoryName;
                Context.SaveChanges();
                return RedirectToAction("CategoryList");
            }
        }
}