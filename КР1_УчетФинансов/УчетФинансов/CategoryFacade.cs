using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетФинансов
{
    public class CategoryFacade
    {
        private readonly CategoryService _categoryService;

        public CategoryFacade(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public Category CreateCategory(TransactionType type, string name)
        {
            return _categoryService.Create(type, name);
        }

        public bool UpdateCategory(int id, TransactionType type, string name)
        {
            return _categoryService.Update(id, type, name);
        }

        public bool DeleteCategory(int id)
        {
            return _categoryService.Delete(id);
        }

        public IReadOnlyList<Category> GetAllCategories()
        {
            return _categoryService.GetAll();
        }

        public Category? GetCategoryById(int id)
        {
            return _categoryService.GetById(id);
        }
    }
}
