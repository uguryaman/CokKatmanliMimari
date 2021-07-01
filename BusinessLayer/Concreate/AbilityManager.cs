using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class AbilityManager:IAbilityService
    {
        IAbilityDal _abilityDal;

        public AbilityManager(IAbilityDal abilityDal)
        {
            _abilityDal = abilityDal;
        }
        public List<Ability> GetList()
        {
            return _abilityDal.List();
        }
        public void AbilityAdd(Ability ability)
        {
            _abilityDal.Insert(ability);
        }

        public void AbilityDelete(Ability ability)
        {
            throw new NotImplementedException();
        }

        public void AbilityEdit(Ability ability)
        {
            throw new NotImplementedException();
        }

        public Category GetByID(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
