//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace think_bridge_shopping_website.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int Id { get; set; }
        public string product_name { get; set; }
        public string product_quantity { get; set; }
        public Nullable<double> product_rate { get; set; }
        public Nullable<int> product_fk_category_id { get; set; }
        public string product_image { get; set; }
        public string product_img_file_path { get; set; }
        public Nullable<bool> product_is_active { get; set; }
        public Nullable<System.DateTime> product_added_on { get; set; }
    
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
