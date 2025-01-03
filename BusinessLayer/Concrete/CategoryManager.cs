using BusinessLayer.Abatract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categorydal;

        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }


        public List<Category> GetCategoryList()
        {
            return _categorydal.List();
        }

        public void CategoryAddBL(Category category)
        {
            _categorydal.Insert(category);
        }

        public Category GetByID(int id)
        {
            return _categorydal.Get(x=>x.CategoryId==id);
        }
    }
}
