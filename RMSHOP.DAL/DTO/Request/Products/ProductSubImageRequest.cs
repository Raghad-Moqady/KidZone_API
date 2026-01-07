using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSHOP.DAL.DTO.Request.Products
{
    public class ProductSubImageRequest
    {
        public IFormFile SubImage { get; set; } 
    }
}
