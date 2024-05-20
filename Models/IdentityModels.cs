﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using WebsiteBH.Models.EF;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace WebsiteBH.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string Fullname { get; set; }
        public string Phone { get; set; }
        public List<string> RoleNames { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Adv> Advs { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<SystemSetting> SystemSettings { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ParentComment> ParentComments { get; set; }
        public DbSet<ChildComment> ChildComments { get; set; }
        public DbSet<LikeProduct> LikeProducts { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<ThongKe> ThongKes { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}