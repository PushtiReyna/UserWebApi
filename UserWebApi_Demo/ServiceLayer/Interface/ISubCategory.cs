using DTO.SubCateogory;
using Helper.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface ISubCategory
    {
      public  CommonResponse GetSubCategory();
        public CommonResponse AddSubCategory(AddSubCategoryReqDTO addSubCategoryReqDTO);

        public CommonResponse UpdateSubCategory(UpdateSubCategoryReqDTO updateSubCategoryReqDTO);

        public CommonResponse DeleteSubCategory(DeleteSubCategoryReqDTO deleteSubCategoryReqDTO);
    }
}
