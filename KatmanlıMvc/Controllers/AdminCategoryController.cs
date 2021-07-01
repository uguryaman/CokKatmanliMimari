using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KatmanlıMvc.Controllers
{
    [Authorize]
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var CategoryValues = cm.GetList();
            return View(CategoryValues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {

            return View();

        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidatior categoryValıdator = new CategoryValidatior();
            ValidationResult results = categoryValıdator.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteCAtegory(int id)
        {
            var categoryValue = cm.GetByID(id);
            cm.CategoryDelete(categoryValue);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var catValue = cm.GetByID(id);
            return View(catValue);
        }
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            cm.CategoryEdit(p);
            return RedirectToAction("Index");
        }
    }
}

  //< customErrors mode = "On" >
 
  //     < error statusCode = "404" redirect = "~/ErrorPage/Page404" />
    
  //      </ customErrors >