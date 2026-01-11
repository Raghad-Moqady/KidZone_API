using RMSHOP.DAL.Models;
using RMSHOP.DAL.Models.category;
using RMSHOP.DAL.Models.product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSHOP.DAL.DTO.Response.Cart
{
    public class CartProductResponse
    {
        //adapt : Cart => CartProductResponse
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string MainImage { get; set; }
        public int ProductCount { get; set; }
        public string CategoryName { get; set; }

        public decimal TotalPrice => Price * ProductCount;
     }
}
