using DTO.SubCateogory;
using DTO.User;
using Helper.CommonModel;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interface;
using UserWebApi.ViewModel.SubCategory;
using UserWebApi.ViewModel.User;

namespace UserWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }
        [HttpGet]
        public CommonResponse GetUser()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = _user.GetUser();
                List<GetUserResDTO> lstGetUserResDTO = response.Data;
                response.Data = lstGetUserResDTO.Adapt<List<GetUserResViewModel>>();
            }
            catch { throw; }
            return response;
        }
        [HttpPost]
        public CommonResponse AddUser(AddUserReqViewModel addUserReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = _user.AddUser(addUserReqViewModel.Adapt<AddUserReqDTO>());
                AddUserResDTO addUserResDTO = response.Data;
                response.Data = addUserResDTO.Adapt<AddUserResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPut]
        public CommonResponse UpdateUser(UpdateUserReqViewModel updateUserReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = _user.UpdateUser(updateUserReqViewModel.Adapt<UpdateUserReqDTO>());
                UpdateUserResDTO updateUserResDTO = response.Data;
                response.Data = updateUserResDTO.Adapt<UpdateUserResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpDelete]
        public CommonResponse DeleteUser(DeleteUserReqViewModel deleteUserReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = _user.DeleteUser(deleteUserReqViewModel.Adapt<DeleteUserReqDTO>());
                DeleteUserResDTO deleteUserResDTO = response.Data;
                response.Data = deleteUserResDTO.Adapt<DeleteUserResViewModel>();
            }
            catch { throw; }
            return response;
        }
    }
}
