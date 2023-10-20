using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.SubCateogory
{
    public class GetSubCategoryReqDTO
    {
        public int SubcategoryId { get; set; }

        public string Subcategoryname { get; set; } = null!;

       
        public string Categoryname { get; set; }
    }
}
