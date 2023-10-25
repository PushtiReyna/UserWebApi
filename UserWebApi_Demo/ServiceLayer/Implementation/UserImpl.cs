using BusinessLayer;
using DTO.SubCateogory;
using DTO.User;
using Helper.CommonModel;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementation
{
    public class UserImpl : IUser
    {
        public readonly UserBLL _userBLL;
        public UserImpl(UserBLL userBLL)
        {
            _userBLL = userBLL;
        }
       
        public CommonResponse GetUser()
        {
            return _userBLL.GetUser();
        }
        public CommonResponse AddUser(AddUserReqDTO addUserReqDTO)
        {
            return _userBLL.AddUser(addUserReqDTO);
        }
        public CommonResponse UpdateUser(UpdateUserReqDTO updateUserReqDTO)
        {
            return _userBLL.UpdateUser(updateUserReqDTO);
        }
        public CommonResponse DeleteUser(DeleteUserReqDTO deleteUserReqDTO)
        {
            return _userBLL.DeleteUser(deleteUserReqDTO);
        }
    }
}
