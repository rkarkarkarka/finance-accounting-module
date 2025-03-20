using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетФинансов
{
    public class CategoryService
    {
        private readonly List<Category> _categories = new();

        public Category Create(TransactionType type, string name)
        {
            var newId = _categories.Any() ? _categories.Max(c => c.Id) + 1 : 1;
            var category = new Category(newId, type, name);
            _categories.Add(category);
            return category;
        }

        public bool Update(int categoryId, TransactionType newType, string newName)
        {
            var category = _categories.FirstOrDefault(c => c.Id == categoryId);
            if (category == null)
                return false;

            category.Type = newType;
            category.Name = newName;
            return true;
        }

        public bool Delete(int categoryId)
        {
            var category = _categories.FirstOrDefault(c => c.Id == categoryId);
            if (category == null)
                return false;

            _categories.Remove(category);
            return true;
        }

        public IReadOnlyList<Category> GetAll()
        {
            return _categories;
        }

        public Category? GetById(int categoryId)
        {
            return _categories.FirstOrDefault(c => c.Id == categoryId);
        }
    }
}
