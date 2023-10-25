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
        [HttpPost]
        public CommonResponse AddSubCategory(AddSubCategoryReqViewModel addSubCategoryReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = _subCategory.AddSubCategory(addSubCategoryReqViewModel.Adapt<AddSubCategoryReqDTO>());
                AddSubCategoryResDTO addSubCategoryResDTO = response.Data;
                response.Data = addSubCategoryResDTO.Adapt<AddSubCategoryResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPut]
        public CommonResponse UpdateSubCategory(UpdateSubCategoryReqViewModel updateSubCategoryReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = _subCategory.UpdateSubCategory(updateSubCategoryReqViewModel.Adapt<UpdateSubCategoryReqDTO>());
                UpdateSubCategoryResDTO updateSubCategoryResDTO = response.Data;
                response.Data = updateSubCategoryResDTO.Adapt<UpdateSubCategoryResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpDelete]
        public CommonResponse DeleteSubCategory(DeleteSubCategoryReqViewModel deleteSubCategoryReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = _subCategory.DeleteSubCategory(deleteSubCategoryReqViewModel.Adapt<DeleteSubCategoryReqDTO>());
                DeleteSubCategoryResDTO deleteSubCategoryResDTO = response.Data;
                response.Data = deleteSubCategoryResDTO.Adapt<DeleteSubCategoryResViewModel>();
            }
            catch { throw; }
            return response;
        }




    }
}
