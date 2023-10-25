using DTO.SubCateogory;
using DTO.User;
using Helper.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface IUser
    {
        public CommonResponse GetUser();
        public CommonResponse AddUser(AddUserReqDTO addUserReqDTO);

        public CommonResponse UpdateUser(UpdateUserReqDTO updateUserReqDTO);

        public CommonResponse DeleteUser(DeleteUserReqDTO deleteUserReqDTO);
    }
}
