using Microsoft.EntityFrameworkCore;
using RMSHOP.DAL.Data;
using RMSHOP.DAL.Models.review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSHOP.DAL.Repository.Reviews
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository( ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> HasUserReviewedProduct(string userId, int productId)
        {
            return await _context.Reviews.AnyAsync(r=>r.UserId==userId && r.ProductId==productId);
        }

        public async Task AddReviewAsync(Review request)
        {
            await _context.Reviews.AddAsync(request);
            await _context.SaveChangesAsync(); 
        }
    }
}
