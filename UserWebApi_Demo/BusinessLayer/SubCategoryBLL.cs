using DataLayer.Entities;
using DTO.SubCateogory;
using Helper.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessLayer
{
    public class SubCategoryBLL
    {
        public readonly UserApidbContext _db;
        public SubCategoryBLL(UserApidbContext db)
        {
            _db = db;
        }
        public CommonResponse GetSubCategory()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                List<GetSubCategoryResDTO> lstGetSubCategoryResDTO = new List<GetSubCategoryResDTO>();
                GetSubCategoryResDTO getSubCategoryResDTO = new GetSubCategoryResDTO();

                foreach (SubcategoryMst subcategoryMst in _db.SubcategoryMsts.ToList())
                {
                    getSubCategoryResDTO = new GetSubCategoryResDTO();
                    var categoryName = _db.CategoryMsts.FirstOrDefault(x => x.CategoryId == subcategoryMst.CategoryId);

                    getSubCategoryResDTO.SubcategoryId = subcategoryMst.SubcategoryId;
                    getSubCategoryResDTO.Subcategoryname = subcategoryMst.Subcategoryname;

                    getSubCategoryResDTO.Categoryname = categoryName.Categoryname;
                    lstGetSubCategoryResDTO.Add(getSubCategoryResDTO);

                }
                if (lstGetSubCategoryResDTO.Count > 0)
                {
                    response.Data = lstGetSubCategoryResDTO;
                    response.Status = true;
                    response.Message = "category list is found.";
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "category list is not found";
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                }

            }
            catch { throw; }
            return response;
        }

        public CommonResponse AddSubCategory(AddSubCategoryReqDTO addSubCategoryReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {

            }

            catch { throw; }
            return response;
        }

    }
}
