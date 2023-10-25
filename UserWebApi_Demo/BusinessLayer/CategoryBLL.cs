using DataLayer.Entities;
using DTO.Category;
using Helper.CommonModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CategoryBLL
    {
        public readonly UserApidbContext _db;
        public CategoryBLL(UserApidbContext db)
        {
            _db = db;
        }

        public CommonResponse GetAllCategory()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                List<GetCategoryResDTO> lstGetCategoryResDTO = new List<GetCategoryResDTO>();
                GetCategoryResDTO getCategoryResDTO = new GetCategoryResDTO();

                foreach (CategoryMst category in _db.CategoryMsts.ToList())
                {
                    getCategoryResDTO = new GetCategoryResDTO();
                    getCategoryResDTO.CategoryId = category.CategoryId;
                    getCategoryResDTO.Categoryname = category.Categoryname;
                    lstGetCategoryResDTO.Add(getCategoryResDTO);
                }

                if (lstGetCategoryResDTO.Count > 0)
                {
                    response.Data = lstGetCategoryResDTO;
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

        public CommonResponse AddCategory(AddCategoryReqDTO addCategoryReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AddCategoryResDTO addCategoryResDTO = new AddCategoryResDTO();

                CategoryMst categoryMst = new CategoryMst();
                categoryMst.Categoryname = addCategoryReqDTO.Categoryname.Trim();
                if (categoryMst.Categoryname.Length > 0)
                {
                    if (_db.CategoryMsts.Where(u => u.Categoryname.Trim() == categoryMst.Categoryname && u.CategoryId != categoryMst.CategoryId).Any())
                    {
                        response.Message = "category name already exist";
                        response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    }
                    else
                    {
                        _db.CategoryMsts.Add(categoryMst);
                        _db.SaveChanges();

                        addCategoryResDTO.CategoryId = categoryMst.CategoryId;

                        if (addCategoryResDTO != null)
                        {
                            response.Data = addCategoryResDTO;
                            response.Status = true;
                            response.Message = "Category is add";
                            response.StatusCode = System.Net.HttpStatusCode.OK;
                        }
                        else
                        {
                            response.Message = "Category is not add.";
                            response.StatusCode = System.Net.HttpStatusCode.NotFound;
                        }
                    }
                }
                else
                {
                    response.Message = "category name can not be null.";
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
            }
            catch { throw; }

            return response;
        }

        public CommonResponse UpdateCategory(UpdateCategoryReqDTO updateCategoryReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                UpdateCategoryResDTO updateCategoryResDTO = new UpdateCategoryResDTO();
                CategoryMst categoryMst = new CategoryMst();
                categoryMst = _db.CategoryMsts.FirstOrDefault(x => x.CategoryId == updateCategoryReqDTO.CategoryId);
                if (categoryMst != null)
                {
                    categoryMst.Categoryname = updateCategoryReqDTO.Categoryname.Trim();

                    if (categoryMst.Categoryname.Length > 0)
                    {
                        if (_db.CategoryMsts.Where(u => u.Categoryname.Trim() == categoryMst.Categoryname && u.CategoryId != categoryMst.CategoryId).Any())
                        {
                            response.Message = "category name already exist";
                            response.StatusCode = System.Net.HttpStatusCode.NotFound;
                        }
                        else
                        {
                            _db.Entry(categoryMst).State = EntityState.Modified;
                            _db.SaveChanges();
                            updateCategoryResDTO.CategoryId = categoryMst.CategoryId;

                            if (updateCategoryResDTO != null)
                            {
                                response.Data = updateCategoryResDTO;
                                response.Status = true;
                                response.Message = "Category is updated";
                                response.StatusCode = System.Net.HttpStatusCode.OK;
                            }
                        }
                    }
                    else
                    {
                        response.Message = "category name can not be null.";
                        response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    }
                }
                else
                {
                    response.Message = "category is not found";
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
            }
            catch { throw; }
            return response;
        }

        public CommonResponse DeleteCategory(DeleteCategoryReqDTO deleteCategoryReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                DeleteCategoryResDTO deleteCategoryResDTO = new DeleteCategoryResDTO();
                CategoryMst categoryMst = new CategoryMst();
                categoryMst = _db.CategoryMsts.FirstOrDefault(x => x.CategoryId == deleteCategoryReqDTO.CategoryId);
                if (categoryMst != null)
                {
                    categoryMst.CategoryId = deleteCategoryReqDTO.CategoryId;
                    _db.CategoryMsts.Remove(categoryMst);
                    _db.SaveChanges();

                    deleteCategoryResDTO.CategoryId = categoryMst.CategoryId;

                    if (deleteCategoryResDTO != null)
                    {
                        response.Data = deleteCategoryResDTO;
                        response.Status = true;
                        response.Message = "Category is deleted";
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                }
                else
                {
                    response.Message = "category is not found";
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
            }
            catch { throw; }
            return response;
        }

    }
}
