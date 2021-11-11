using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        int AddCategory(Category category);
        int UpdateCategory(int id, Category category);
        int DeleteCategory(int id);
    }
}