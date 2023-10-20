using BusinessLayer;
using DTO.Category;
using Helper.CommonModel;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementation
{
    public class CategoryImpl : ICategory
    {
        public readonly CategoryBLL _categoryBLL;
        public CategoryImpl(CategoryBLL categoryBLL)
        {
            _categoryBLL = categoryBLL;
        }
        public CommonResponse GetAllCategory()
        {
            return _categoryBLL.GetAllCategory();
        }
        public CommonResponse AddCategory(AddCategoryReqDTO addCategoryReqDTO)
        {
            return _categoryBLL.AddCategory(addCategoryReqDTO);
        }
        public CommonResponse UpdateCategory(UpdateCategoryReqDTO updateCategoryReqDTO)
        {
            return _categoryBLL.UpdateCategory(updateCategoryReqDTO);
        }
        public CommonResponse DeleteCategory(DeleteCategoryReqDTO deleteCategoryReqDTO)
        {
            return _categoryBLL.DeleteCategory(deleteCategoryReqDTO);
        }
    }
}
