using DTO.Category;
using DTO.SubCateogory;
using Helper.CommonModel;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interface;
using System.Collections.Generic;
using UserWebApi.ViewModel.Category;
using UserWebApi.ViewModel.SubCategory;

namespace UserWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        public readonly ISubCategory _subCategory;
        public SubCategoryController(ISubCategory subCategory) 
        { 
            _subCategory = subCategory;
        }
        [HttpGet]
        public CommonResponse GetSubCategory()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = _subCategory.GetSubCategory();
                List<GetSubCategoryResDTO> lstGetSubCategoryResDTO = response.Data;
                response.Data = lstGetSubCategoryResDTO.Adapt<List<GetSubCategoryResViewModel>>();
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
