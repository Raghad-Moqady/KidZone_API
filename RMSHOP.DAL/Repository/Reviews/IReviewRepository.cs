using RMSHOP.DAL.Models.review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSHOP.DAL.Repository.Reviews
{
    public interface IReviewRepository
    {
        Task<bool> HasUserReviewedProduct(string userId, int  productId);
        Task AddReviewAsync(Review request);
    }
}
