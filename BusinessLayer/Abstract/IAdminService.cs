using EntityLayer.Concreate;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GEtlist();
        void AdminDelete(Admin admin);
        void AdminUpdate(Admin admin);
        Admin GetById(int id);
        List<Admin> GetListByID(int id);

        bool IsLoginSuccess(string AdmşnUserName, string password);
        void AddAdmin(Admin admin);



    }
}
