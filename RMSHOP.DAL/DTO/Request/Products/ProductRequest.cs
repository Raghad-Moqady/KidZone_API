using Microsoft.AspNetCore.Http;
using RMSHOP.DAL.Models;
using RMSHOP.DAL.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSHOP.DAL.DTO.Request.Products
{
    public class ProductRequest
    {
        public decimal Price { get; set; }
        [MinValue(2)]
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public IFormFile MainImage { get; set; }
        public List<IFormFile> SubImages { get; set; }
        //public List<ProductSubImageRequest> SubImages { get; set; }
        public int CategoryId { get; set; }
        public List<ProductTranslationRequest> Translations { get; set; }
    }
}
