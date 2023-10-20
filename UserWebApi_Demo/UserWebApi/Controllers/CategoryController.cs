using DTO.Category;
using Helper.CommonModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interface;
using UserWebApi.ViewModel.Category;
using Mapster;

namespace UserWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ICategory _Category;
        public CategoryController(ICategory Category)
        {
            _Category = Category;
        }

        [HttpGet]
        public CommonResponse GetAllCategory()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = _Category.GetAllCategory();
                List<GetCategoryResDTO> lstGetCategoryResDTO = response.Data;
                response.Data = lstGetCategoryResDTO.Adapt<List<GetCategoryResViewModel>>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost]
        public CommonResponse AddCategory(AddCategoryReqViewModel addCategoryReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = _Category.AddCategory(addCategoryReqViewModel.Adapt<AddCategoryReqDTO>());
                AddCategoryResDTO addCategoryResDTO = response.Data;
                response.Data = addCategoryResDTO.Adapt<AddCategoryResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPut]
        public CommonResponse UpdateCategory(UpdateCategoryReqViewModel updateCategoryReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = _Category.UpdateCategory(updateCategoryReqViewModel.Adapt<UpdateCategoryReqDTO>());
                UpdateCategoryResDTO updateCategoryResDTO = response.Data;
                response.Data = updateCategoryResDTO.Adapt<UpdateCategoryResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpDelete]
        public CommonResponse DeleteCategory(DeleteCategoryReqViewModel deleteCategoryReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = _Category.DeleteCategory(deleteCategoryReqViewModel.Adapt<DeleteCategoryReqDTO>());
                DeleteCategoryResDTO deleteCategoryResDTO = response.Data;
                response.Data = deleteCategoryResDTO.Adapt<DeleteCategoryResViewModel>();
            }
            catch { throw; }
            return response;
        }
    }
}
