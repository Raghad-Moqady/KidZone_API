using RMSHOP.DAL.Models.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSHOP.DAL.Models.category
{
    public class Category: BaseModel
    {
        public List<CategoryTranslation> Translations { get; set; }

        public List<Product> Products { get; set; }
    }
}
