using DataAccessLayer.Concreate.Repositories;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class CategoryManager
    {
        GenericRepository<Category> repo = new GenericRepository<Category>();

        public List<Category> GetAllBL()
        {
            return repo.List();
        }
        public void CategoryAddBl(Category p)
        {
            if (p.CategoryName=="" || p.CategoryName.Length <= 3 || p.CategoryName.Length >= 51 || p.CategoryDescription == "")
            {
                //hata mesajı
            }
            else
            {
                repo.Insert(p);
            }
            
        }
    }
}
