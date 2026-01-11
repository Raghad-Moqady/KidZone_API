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
    public class CartSummaryResponse
    {
      // يمكن ما يكون في منتجات بالسلة => [] & 0
      public List<CartProductResponse> CartProducts { get; set; }
      public decimal CartTotal => CartProducts.Sum(p=>p.TotalPrice);
    }
}
