using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.SubCateogory
{
    public class DeleteSubCategoryReqDTO
    {
        public int SubcategoryId { get; set; }

        public int? CategoryId { get; set; }

        public string Subcategoryname { get; set; } = null!;
    }
}
