using RMSHOP.DAL.Models.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSHOP.DAL.Models.review
{
    public class Review
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.UtcNow;
    }
}
