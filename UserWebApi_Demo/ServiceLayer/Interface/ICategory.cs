using DTO.Category;
using Helper.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface ICategory
    {
        public CommonResponse GetAllCategory();
        public CommonResponse AddCategory(AddCategoryReqDTO addCategoryReqDTO);

        public CommonResponse UpdateCategory(UpdateCategoryReqDTO updateCategoryReqDTO);

        public CommonResponse DeleteCategory(DeleteCategoryReqDTO deleteCategoryReqDTO);
    }
}
