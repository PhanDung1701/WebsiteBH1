﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteBH.Models.EF
{
    [Table("tb_Order")]
    public class Order : CommonAbstract
    {
        public Order() {
            this.OrderDetails=new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGeneratedAtribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        public decimal TotalAmount { get; set; }
        public int Quantity { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}