using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using think_bridge_shopping_website.Data;

namespace think_bridge_shopping_website.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string product_name { get; set; }

        [Display(Name = "Quantity")]
        public string product_quantity { get; set; }

        [Display(Name = "Rate")]
        public Nullable<double> product_rate { get; set; }

        [Display(Name = "Category")]
        public Nullable<int> product_fk_category_id { get; set; }

        [Display(Name = "Image")]
        public string product_image { get; set; }

        [Display(Name = "Image")]
        public string product_img_file_path { get; set; }

        [Display(Name = "Status")]
        public Nullable<bool> product_is_active { get; set; }
        [Display(Name = "Status")]
        public string product_is_active_status { get; set; }

        [Display(Name = "Added On")]
        public Nullable<System.DateTime> product_added_on { get; set; }
        [Display(Name = "Added On")]
        public string product_added_on_text { get; set; }

        public ProductViewModel() { }

        public ProductViewModel(int productId) 
        {
            think_bridge_dbEntities _DbEntities = new think_bridge_dbEntities();
            Product product = _DbEntities.Products.Where(p => p.Id == productId).FirstOrDefault();
            SetProperties(product);
        }

        public ProductViewModel(Product product)
        {
            SetProperties(product);
        }

        private void SetProperties(Product product)
        {
            this.Id = product.Id;

            this.product_name = product.product_name;
            this.product_quantity = product.product_quantity;

            this.product_rate = product.product_rate;
            this.product_image = product.product_image;
            if (!string.IsNullOrWhiteSpace(product.product_img_file_path))
            {
                this.product_img_file_path = product.product_img_file_path;
            }
            if (this.product_img_file_path == null)
            {
                this.product_img_file_path = "";
            }

            this.product_is_active = product.product_is_active;
            if (this.product_is_active == true)
            {
                this.product_is_active_status = "Available";
            }
            else if (this.product_is_active == false)
            {
                this.product_is_active_status = "Not Available";
            }

            this.product_fk_category_id = product.product_fk_category_id;

            this.product_added_on = product.product_added_on;
            this.product_added_on_text = product.product_added_on.HasValue
                                               ? product.product_added_on.Value.ToString("dd/MM/yyyy hh:mm:ss tt") : "<Not available>";
        }

        public static List<ProductViewModel> ModelsToViewModels(List<Product> products)
        {
            List<ProductViewModel> productVMs = new List<ProductViewModel> { };

            if (products != null)
            {
                foreach (Product item in products)
                {
                    productVMs.Add(new ProductViewModel(item));
                }
            }

            return productVMs;
        }
    }

    public class ProductCategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Product Category")]
        public string category_name { get; set; }

        public ProductCategoryViewModel() { }

        public ProductCategoryViewModel(int categoryId) 
        {
            think_bridge_dbEntities _DbEntities = new think_bridge_dbEntities();
            ProductCategory productCategory = _DbEntities.ProductCategorys.Where(item => item.Id == categoryId).FirstOrDefault();
            SetProperties(productCategory);
        }

        public ProductCategoryViewModel(ProductCategory productCategory)
        {
            SetProperties(productCategory);
        }

        private void SetProperties(ProductCategory productCategory)
        {
            this.Id = productCategory.Id;
            this.category_name = productCategory.category_name;
        }

        public static List<ProductCategoryViewModel> ModelsToViewModels(List<ProductCategory> productCategories)
        {
            List<ProductCategoryViewModel> categoriesVMs = new List<ProductCategoryViewModel>() { };
            if(productCategories != null)
            {
                foreach (ProductCategory item in productCategories)
                {
                    categoriesVMs.Add(new ProductCategoryViewModel(item));
                }
            }
            return categoriesVMs;
        }
    }
}