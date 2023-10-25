using DataLayer.Entities;
using DTO.SubCateogory;
using Helper.CommonModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
                AddSubCategoryResDTO addSubCategoryResDTO = new AddSubCategoryResDTO();
                SubcategoryMst subcategoryMst = new SubcategoryMst();

                var categoryId = _db.CategoryMsts.FirstOrDefault(x => x.CategoryId == addSubCategoryReqDTO.CategoryId);

                if (categoryId != null)
                {
                    subcategoryMst.CategoryId = addSubCategoryReqDTO.CategoryId;
                    subcategoryMst.Subcategoryname = addSubCategoryReqDTO.Subcategoryname.Trim();

                    if (subcategoryMst.Subcategoryname.Length > 0)
                    {
                        if (_db.SubcategoryMsts.Where(u => u.Subcategoryname.Trim() == subcategoryMst.Subcategoryname && u.SubcategoryId != subcategoryMst.SubcategoryId).Any())
                        {
                            response.Message = "subcategory name already exist";
                            response.StatusCode = System.Net.HttpStatusCode.NotFound;
                        }
                        else
                        {
                            _db.SubcategoryMsts.Add(subcategoryMst);
                            _db.SaveChanges();

                            addSubCategoryResDTO.SubcategoryId = subcategoryMst.SubcategoryId;

                            if (addSubCategoryResDTO != null)
                            {
                                response.Data = addSubCategoryResDTO;
                                response.Status = true;
                                response.Message = "subcategory is add";
                                response.StatusCode = System.Net.HttpStatusCode.OK;
                            }
                            else
                            {
                                response.Message = "subcategory is not add.";
                                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                            }
                        }
                    }
                    else
                    {
                        response.Message = "subcategory name can not be null.";
                        response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    }
                }

            }

            catch { throw; }
            return response;
        }

        public CommonResponse UpdateSubCategory(UpdateSubCategoryReqDTO updateSubCategoryReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                UpdateSubCategoryResDTO updateSubCategoryResDTO = new UpdateSubCategoryResDTO();
                SubcategoryMst subcategoryMst = new SubcategoryMst();

                var categoryId = _db.CategoryMsts.FirstOrDefault(x => x.CategoryId == updateSubCategoryReqDTO.CategoryId);
                subcategoryMst = _db.SubcategoryMsts.FirstOrDefault(x => x.SubcategoryId == updateSubCategoryReqDTO.SubcategoryId);

                if (subcategoryMst != null && categoryId != null)
                {
                    subcategoryMst.CategoryId = categoryId.CategoryId;
                    subcategoryMst.Subcategoryname = updateSubCategoryReqDTO.Subcategoryname.Trim();

                    if (subcategoryMst.Subcategoryname.Length > 0)
                    {
                        if (_db.SubcategoryMsts.Where(u => u.Subcategoryname.Trim() == subcategoryMst.Subcategoryname && u.SubcategoryId != subcategoryMst.SubcategoryId).Any())
                        {
                            response.Message = "subcategory name already exist";
                            response.StatusCode = System.Net.HttpStatusCode.NotFound;
                        }
                        else
                        {
                            _db.Entry(subcategoryMst).State = EntityState.Modified;
                            _db.SaveChanges();

                            updateSubCategoryResDTO.SubcategoryId = subcategoryMst.SubcategoryId;

                            if (updateSubCategoryResDTO != null)
                            {
                                response.Data = updateSubCategoryResDTO;
                                response.Status = true;
                                response.Message = "subcategory is updated";
                                response.StatusCode = System.Net.HttpStatusCode.OK;
                            }
                        }
                    }
                    else
                    {
                        response.Message = "subcategory name can not be null.";
                        response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    }
                }
                else
                {
                    response.Message = "subcategory is not found.";
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
            }
            catch { throw; }
            return response;
        }

        public CommonResponse DeleteSubCategory(DeleteSubCategoryReqDTO deleteSubCategoryReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                DeleteSubCategoryResDTO deleteSubCategoryResDTO = new DeleteSubCategoryResDTO();
                SubcategoryMst subcategoryMst = new SubcategoryMst();

                subcategoryMst = _db.SubcategoryMsts.FirstOrDefault(x => x.SubcategoryId == deleteSubCategoryReqDTO.SubcategoryId);

                if (subcategoryMst != null)
                {
                    subcategoryMst.CategoryId = subcategoryMst.CategoryId;
                    subcategoryMst.Subcategoryname = deleteSubCategoryReqDTO.Subcategoryname;
                    _db.SubcategoryMsts.Remove(subcategoryMst);
                    _db.SaveChanges();

                    deleteSubCategoryResDTO.SubcategoryId = subcategoryMst.SubcategoryId;

                    if (deleteSubCategoryResDTO != null)
                    {
                        response.Data = deleteSubCategoryResDTO;
                        response.Status = true;
                        response.Message = "subcategory is deleted";
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                }
                else
                {
                    response.Message = "subcategory is not deleted.";
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
            }
            catch { throw; }
            return response;
        }


    }
}
