using RMSHOP.DAL.DTO.Request.Products;
using RMSHOP.DAL.DTO.Response.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSHOP.BLL.Service.Products
{
    public interface IProductService
    {
        Task<ProductResponse> CreateProductAsync(ProductRequest request);
    }
}
