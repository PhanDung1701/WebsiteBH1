﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteBH.Models.EF
{
    [Table("tb_Product")]
    public class Product : CommonAbstract
    {
        public Product() {
            this.ProductImage=new HashSet<ProductImage>();
            this.OrderDetail = new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGeneratedAtribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Title { get; set; }
        public string Alias { get; set; }
        [StringLength(50)]
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal Price { get; set; }
        public decimal? PriceSale { get; set; }
        public int Quantity { get; set; }
        public bool IsHome { get; set; }
        public bool IsFeature { get; set; }
        public bool IsHot { get; set; }
        public bool IsSale { get; set; }
        public int ProductCategoryId { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public bool IsActive { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductImage> ProductImage { get; set; }
        public virtual ICollection<ReviewProduct> Reviews { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }
        public int ViewCount { get; internal set; }
    }
}