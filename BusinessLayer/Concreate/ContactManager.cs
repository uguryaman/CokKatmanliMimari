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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void ContactAdd(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public void ContactDelete(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            _contactDal.Update(contact);
        }

        public Contact GetById(int id)
        {
            return _contactDal.Get(x => x.ContactID == id);
        }

        public List<Contact> GEtlist()
        {
            return _contactDal.List();

        }

        public List<Contact> GetListByID(int id)
        {
            return _contactDal.List(x => x.ContactID == id);
        }
    }
}
