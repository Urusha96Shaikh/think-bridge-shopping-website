using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using think_bridge_shopping_website.Data;
using think_bridge_shopping_website.Models;

namespace think_bridge_shopping_website.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: ProductCategory
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllProductCatagories()
        {
            think_bridge_dbEntities _DbEntities = new think_bridge_dbEntities();
            List<ProductCategoryViewModel> productCatagoriesVMs = ProductCategoryViewModel.ModelsToViewModels(_DbEntities.ProductCategorys.ToList());
            return Json(productCatagoriesVMs, JsonRequestBehavior.AllowGet);
        }

        // POST: ProductCatagory/Create
        [HttpPost]
        public ActionResult Create(ProductCategoryViewModel productCatagoriesVMs)
        {
            think_bridge_dbEntities _DbEntities = new think_bridge_dbEntities();
            try
            {
                if (_DbEntities.ProductCategorys.Any(item => item.category_name.Equals(productCatagoriesVMs.category_name)))
                {
                    ViewBag.Message = "Product catagory with same name already exists.";
                }
                else
                {
                    ProductCategory productCatagories = new ProductCategory();
                    productCatagories.category_name = productCatagoriesVMs.category_name;
                    _DbEntities.ProductCategorys.Add(productCatagories);
                    _DbEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return View("Index");
        }
        public JsonResult GetProductCatagoriesDetails(int productCatagoryId)
        {
            think_bridge_dbEntities _DbEntities = new think_bridge_dbEntities();
            ProductCategory productCatagories = _DbEntities.ProductCategorys.Where(item => item.Id == productCatagoryId).ToList().FirstOrDefault();
            ProductCategoryViewModel productCatagoriesVM = new ProductCategoryViewModel(productCatagories);
            return Json(productCatagoriesVM, JsonRequestBehavior.AllowGet);
        }

        // POST: ProductCatagory/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductCategoryViewModel productCatagoriesVM)
        {
            think_bridge_dbEntities _DbEntities = new think_bridge_dbEntities();
            try
            {
                if (_DbEntities.ProductCategorys.Any(item => (item.Id != productCatagoriesVM.Id) && (item.category_name.Equals(productCatagoriesVM.category_name))))
                {
                    ViewBag.Message = "Product catagory with same name already exists.";
                }
                else
                {
                    ProductCategory updateProductcatagory = _DbEntities.ProductCategorys.SingleOrDefault(item => item.Id == productCatagoriesVM.Id);
                    updateProductcatagory.category_name = productCatagoriesVM.category_name;
                    _DbEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }

            return View("Index");
        }
    }
}