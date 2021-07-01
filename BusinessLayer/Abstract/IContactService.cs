using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GEtlist();
        void ContactAdd(Contact contact);
        void ContactDelete(Contact contact);
        void ContactUpdate(Contact contact);
        Contact GetById(int id);
        List<Contact> GetListByID(int id);
    }
}
