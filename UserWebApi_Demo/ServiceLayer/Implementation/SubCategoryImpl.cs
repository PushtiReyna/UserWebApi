using BusinessLayer;
using DTO.SubCateogory;
using Helper.CommonModel;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementation
{
    public class SubCategoryImpl :ISubCategory
    {
        public readonly SubCategoryBLL _subCategoryBLL;
        public SubCategoryImpl(SubCategoryBLL subCategoryBLL)
        {
           _subCategoryBLL = subCategoryBLL;
        }

        public CommonResponse GetSubCategory()
        {
            return _subCategoryBLL.GetSubCategory();
        }
        public CommonResponse AddSubCategory(AddSubCategoryReqDTO addSubCategoryReqDTO)
        {
            return _subCategoryBLL.AddSubCategory(addSubCategoryReqDTO);
        }
        public CommonResponse UpdateSubCategory(UpdateSubCategoryReqDTO updateSubCategoryReqDTO)
        {
            return _subCategoryBLL.UpdateSubCategory(updateSubCategoryReqDTO);
        }
        public CommonResponse DeleteSubCategory(DeleteSubCategoryReqDTO deleteSubCategoryReqDTO)
        {
            return _subCategoryBLL.DeleteSubCategory(deleteSubCategoryReqDTO);
        }
    }
}
