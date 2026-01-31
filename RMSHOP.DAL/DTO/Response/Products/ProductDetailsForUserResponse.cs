using RMSHOP.DAL.DTO.Response.Review;
using RMSHOP.DAL.Models;
using RMSHOP.DAL.Models.review;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSHOP.DAL.DTO.Response.Products
{
    public class ProductDetailsForUserResponse
    {
        public int Id { get; set; }

        //mapster from Include Translations(lang)
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public double Rate { get; set; }
        //mapster from Include category.translations(lang)
        public string CategoryName { get; set; }

        //mapster edit to link
        public string MainImage { get; set; }
        //mapster edit 
        public List<string> SubImages {  get; set; }
        public List<ReviewResponse> Reviews { get; set; }
    }
}
