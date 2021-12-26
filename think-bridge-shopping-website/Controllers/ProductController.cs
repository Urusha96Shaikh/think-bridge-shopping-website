using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using think_bridge_shopping_website.Data;
using think_bridge_shopping_website.Models;

namespace think_bridge_shopping_website.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
             think_bridge_dbEntities _DbEntities = new think_bridge_dbEntities();
            List<Product> productList = _DbEntities.Products.OrderByDescending(item => item.product_added_on).ToList();
            List<ProductViewModel> productVMList = ProductViewModel.ModelsToViewModels(productList);
            return View(productVMList);
        }

        // GET: Product/Details/5
        public ActionResult Details(int Id)
        {
            think_bridge_dbEntities _DbEntities = new think_bridge_dbEntities();
            ProductViewModel productDetails = new ProductViewModel(Id);
            if (Id != null)
            {
                ViewBag.ProductCatagories = new SelectList(_DbEntities.ProductCategorys.ToList(), "Id", "category_name", productDetails.product_fk_category_id);
            }
            return View(productDetails);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            think_bridge_dbEntities _DbEntities = new think_bridge_dbEntities();
            List<ProductCategory> ProductCatagories = _DbEntities.ProductCategorys.ToList();
            ViewBag.ProductCatagories = new SelectList(ProductCatagories, "Id", "category_name");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductViewModel productVM, HttpPostedFileBase product_image)
        {
            try
            {
                think_bridge_dbEntities _DbEntities = new think_bridge_dbEntities();
                if (_DbEntities.Products.Any(item => (item.product_name.Equals(productVM.product_name))))
                {
                    ViewBag.Message = "Product with same name already exists.";

                }
                else
                {
                    Product product = new Product();

                    product.product_name = productVM.product_name;
                    product.product_quantity = productVM.product_quantity;
                    product.product_rate = productVM.product_rate;

                    int categoryId = Convert.ToInt32(productVM.product_fk_category_id);
                    List<ProductCategory> catagories = _DbEntities.ProductCategorys.Where(item => item.Id == categoryId).ToList();
                    foreach (ProductCategory item in catagories)
                    {
                        product.product_fk_category_id = categoryId;
                    }
                    product.product_is_active = true;
                    product.product_added_on = DateTime.Now;

                    if (product_image != null && product_image.ContentLength > 0)
                    {
                        string fileNameTimeStamp = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss");
                        string documentName = Path.GetFileName(fileNameTimeStamp + "_" + product_image.FileName);
                        string documentExt = Path.GetExtension(documentName);

                        documentExt = documentExt.ToLower();

                        string[] allowedDocExtenstion = { ".jpg", ".jpeg", ".png" };

                        if (allowedDocExtenstion.Contains(documentExt))
                        {
                            string filePath = "~/UploadedImages/" + documentName;

                            product.product_image = documentName;
                            product.product_img_file_path = filePath;

                            string saveAtPath = HostingEnvironment.ApplicationPhysicalPath + filePath.Replace("~/", "");
                            product_image.SaveAs(saveAtPath);
                        }
                    }
                    _DbEntities.Products.Add(product);
                    _DbEntities.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int Id)
        {
            think_bridge_dbEntities _DbEntities = new think_bridge_dbEntities();
            ProductViewModel productVM = new ProductViewModel(Id);
            if (productVM != null)
            {               
                ViewBag.ProductCatagories = new SelectList(_DbEntities.ProductCategorys.ToList(), "Id", "category_name", productVM.product_fk_category_id);
            }
            return View(productVM);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int Id, ProductViewModel productVM, HttpPostedFileBase product_image)
        {
            think_bridge_dbEntities _DbEntities = new think_bridge_dbEntities();
            try
            {
                if (_DbEntities.Products.Any(item => (item.Id != productVM.Id) && (item.product_name.Equals(productVM.product_name))))
                {
                    ViewBag.Message = "Product with same name already exists.";
                }
                else
                {
                    Product updateProduct = _DbEntities.Products.SingleOrDefault(item => item.Id == Id);
                    updateProduct.Id = productVM.Id;
                    updateProduct.product_name = productVM.product_name;
                    updateProduct.product_quantity = productVM.product_quantity;
                    updateProduct.product_rate = productVM.product_rate;
                    if(productVM.product_is_active != null)
                    {
                        updateProduct.product_is_active = productVM.product_is_active;
                    }
                    else
                    {
                        updateProduct.product_is_active = true;
                    }

                    int categoryId = Convert.ToInt32(productVM.product_fk_category_id);
                    List<ProductCategory> catagories = _DbEntities.ProductCategorys.Where(item => item.Id == categoryId).ToList();
                    foreach (ProductCategory item in catagories)
                    {
                        updateProduct.product_fk_category_id = categoryId;
                    }

                    if (product_image != null && product_image.ContentLength > 0)
                    {
                        string fileNameTimeStamp = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss");
                        string documentName = Path.GetFileName(fileNameTimeStamp + "_" + product_image.FileName);
                        string documentExt = Path.GetExtension(documentName);

                        documentExt = documentExt.ToLower();

                        string[] allowedDocExtenstion = { ".jpg", ".jpeg", ".png" };

                        if (allowedDocExtenstion.Contains(documentExt))
                        {
                            string filePath = "~/UploadedImages/" + documentName;

                            updateProduct.product_image = documentName;
                            updateProduct.product_img_file_path = filePath;

                            string saveAtPath = HostingEnvironment.ApplicationPhysicalPath + filePath.Replace("~/", ""); ;
                            product_image.SaveAs(saveAtPath);

                        }
                    }
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

        // GET: Product/Delete/5
        public ActionResult Delete(int Id)
        {
            think_bridge_dbEntities _DbEntities = new think_bridge_dbEntities();
            ProductViewModel removeProduct = new ProductViewModel(Id);
            if (Id != null)
            {
                ViewBag.ProductCatagories = new SelectList(_DbEntities.ProductCategorys.ToList(), "Id", "category_name", removeProduct.product_fk_category_id);
            }
            return View(removeProduct);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int Id, ProductViewModel productVM)
        {
            try
            {
                think_bridge_dbEntities _DbEntities = new think_bridge_dbEntities();
                Product product = _DbEntities.Products.Find(Id);
                _DbEntities.Products.Remove(product);
                _DbEntities.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
