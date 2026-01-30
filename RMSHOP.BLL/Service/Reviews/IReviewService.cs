using RMSHOP.DAL.DTO.Request.Review;
using RMSHOP.DAL.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSHOP.BLL.Service.Reviews
{
    public interface IReviewService
    {
        Task<BaseResponse> AddReviewAsync(string userId,int productId,ReviewRequest request);

    }
}
