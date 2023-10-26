using DataLayer.Entities;
using DTO.SubCateogory;
using DTO.User;
using Helper.CommonModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserBLL
    {
        public readonly UserApidbContext _db;
        public UserBLL(UserApidbContext db)
        {
            _db = db;
        }
        public CommonResponse GetUser()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                List<GetUserResDTO> lstGetUserResDTO = new List<GetUserResDTO>();
                GetUserResDTO getUserResDTO = new GetUserResDTO();

                foreach (UserMst userMst in _db.UserMsts.Where(u => u.IsDelete == false).ToList())
                {
                    getUserResDTO = new GetUserResDTO();
                    var categoryName = _db.CategoryMsts.FirstOrDefault(x => x.CategoryId == userMst.CategoryId);
                    var subCategoryName = _db.SubcategoryMsts.FirstOrDefault(x => x.SubcategoryId == userMst.SubcategoryId);

                    getUserResDTO.Id = userMst.Id;
                    getUserResDTO.Fullname = userMst.Fullname.Trim();
                    getUserResDTO.Address = userMst.Address.Trim();
                    getUserResDTO.Mobilenumber = userMst.Mobilenumber;
                    getUserResDTO.Percentage = userMst.Percentage;
                    getUserResDTO.Dob = userMst.Dob;
                    getUserResDTO.Categoryname = categoryName.Categoryname;
                    getUserResDTO.Subcategoryname = subCategoryName.Subcategoryname;

                    lstGetUserResDTO.Add(getUserResDTO);
                }
                if (lstGetUserResDTO.Count > 0)
                {
                    response.Data = lstGetUserResDTO;
                    response.Status = true;
                    response.Message = "user list is found.";
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "user list is not found";
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                }

            }
            catch { throw; }
            return response;
        }

        public CommonResponse AddUser(AddUserReqDTO addUserReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AddUserResDTO addUserResDTO = new AddUserResDTO();
                UserMst userMst = new UserMst();

                var subCategoryId = _db.SubcategoryMsts.FirstOrDefault(x => x.SubcategoryId == addUserReqDTO.SubcategoryId && x.CategoryId == addUserReqDTO.CategoryId && x.IsDelete == false);

                if (subCategoryId != null)
                {
                    userMst.Fullname = addUserReqDTO.Fullname.Trim();
                    userMst.Address = addUserReqDTO.Address.Trim();
                    userMst.Mobilenumber = addUserReqDTO.Mobilenumber;
                    userMst.Percentage = addUserReqDTO.Percentage;
                    userMst.Dob = addUserReqDTO.Dob;
                    userMst.CategoryId = addUserReqDTO.CategoryId;
                    userMst.SubcategoryId = addUserReqDTO.SubcategoryId;
                    userMst.IsActive = true;
                    userMst.CreatedBy = true;
                    userMst.CreatedOn = DateTime.Now;

                    if (userMst.Fullname.Length > 0)
                    {
                        if (_db.UserMsts.Where(u => u.Fullname.Trim() == userMst.Fullname && u.Id != userMst.Id).Any())
                        {
                            response.Message = "user name already exist";
                            response.StatusCode = System.Net.HttpStatusCode.NotFound;
                        }
                        else
                        {
                            _db.UserMsts.Add(userMst);
                            _db.SaveChanges();
                              
                            addUserResDTO.Id = userMst.Id;

                            if (addUserResDTO != null)
                            {
                                response.Data = addUserResDTO;
                                response.Status = true;
                                response.Message = "user is add";
                                response.StatusCode = System.Net.HttpStatusCode.OK;
                            }
                           
                        }
                    }
                    else
                    {
                        response.Message = "user first name can not be null.";
                        response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    }
                }
                else
                {
                    response.Message = "categoryId or SubcategoryId is not valid.";
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                }

            }

            catch { throw; }
            return response;
        }

        public CommonResponse UpdateUser(UpdateUserReqDTO updateUserReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                UpdateUserResDTO updateUserResDTO = new UpdateUserResDTO();
                UserMst userMst = new UserMst();

                var subcategoryId = _db.SubcategoryMsts.FirstOrDefault(x => x.SubcategoryId == updateUserReqDTO.SubcategoryId && x.CategoryId == updateUserReqDTO.CategoryId  && x.IsDelete == false);
                userMst = _db.UserMsts.FirstOrDefault(x => x.Id == updateUserReqDTO.Id);

                if (userMst != null && subcategoryId != null)
                {
                    userMst.Fullname = updateUserReqDTO.Fullname.Trim();
                    userMst.Address = updateUserReqDTO.Address.Trim();
                    userMst.Mobilenumber = updateUserReqDTO.Mobilenumber;
                    userMst.Percentage = updateUserReqDTO.Percentage;
                    userMst.Dob = updateUserReqDTO.Dob;
                    userMst.CategoryId = updateUserReqDTO.CategoryId;
                    userMst.SubcategoryId = updateUserReqDTO.SubcategoryId;
                    userMst.UpdateBy = true;
                    userMst.UpdatedOn = DateTime.Now;

                    if (userMst.Fullname.Length > 0)
                    {
                        if (_db.UserMsts.Where(u => u.Fullname.Trim() == userMst.Fullname && u.Id != userMst.Id).Any())
                        {
                            response.Message = "first name already exist";
                            response.StatusCode = System.Net.HttpStatusCode.NotFound;
                        }
                        else
                        {
                            _db.Entry(userMst).State = EntityState.Modified;
                            _db.SaveChanges();

                            updateUserResDTO.Id = userMst.Id;

                            if (updateUserResDTO != null)
                            {
                                response.Data = updateUserResDTO;
                                response.Status = true;
                                response.Message = "user detail is updated";
                                response.StatusCode = System.Net.HttpStatusCode.OK;
                            }
                        }
                    }
                    else
                    {
                        response.Message = "user name can not be null.";
                        response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    }
                }
                else
                {
                    response.Message = "category Id or Subcategory Id is not valid";
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
            }
            catch { throw; }
            return response;
        }

        public CommonResponse DeleteUser(DeleteUserReqDTO deleteUserReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                DeleteUserResDTO deleteUserResDTO = new DeleteUserResDTO();
                UserMst userMst = new UserMst();

                userMst = _db.UserMsts.FirstOrDefault(x => x.Id == deleteUserReqDTO.Id);

                if (userMst != null)
                {
                    userMst.Id = deleteUserReqDTO.Id;
                    userMst.IsActive = false;
                    userMst.IsDelete = true;
                    // _db.SubcategoryMsts.Remove(subcategoryMst);
                    _db.SaveChanges();

                    deleteUserResDTO.Id = userMst.Id;

                    if (deleteUserResDTO != null)
                    {
                        response.Data = deleteUserResDTO;
                        response.Status = true;
                        response.Message = "user is deleted";
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                }
                else
                {
                    response.Message = "user is not found.";
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
            }
            catch { throw; }
            return response;
        }
    }
}
