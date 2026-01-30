using RMSHOP.DAL.Models;
using RMSHOP.DAL.Models.product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSHOP.DAL.DTO.Request.Review
{
    public class ReviewRequest
    {
        [Required]
        public string Comment { get; set; }
        [Required]
        [Range (1, 5)]
        public int Rating { get; set; }
    }
}
