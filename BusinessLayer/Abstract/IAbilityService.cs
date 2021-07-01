using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAbilityService
    {
        List<Ability> GetList();
        void AbilityAdd(Ability ability);
        Category GetByID(int id);
        void AbilityDelete(Ability ability);
        void AbilityEdit(Ability ability);
    }
}
