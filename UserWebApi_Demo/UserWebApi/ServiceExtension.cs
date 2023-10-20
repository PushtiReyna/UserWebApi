using BusinessLayer;
using ServiceLayer.Implementation;
using ServiceLayer.Interface;

namespace UserWebApi
{
    public static class ServiceExtension
    {
        public static void DIScopes(this IServiceCollection services)
        {
            services.AddScoped<ICategory, CategoryImpl>();
            services.AddScoped<CategoryBLL>();

            services.AddScoped<ISubCategory, SubCategoryImpl>();
            services.AddScoped<SubCategoryBLL>();
            
        }
    }
}
