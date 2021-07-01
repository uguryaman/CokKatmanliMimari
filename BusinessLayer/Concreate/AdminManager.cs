using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class AdminManager: IAdminService
    {
        IAdminDal _AdminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _AdminDal = adminDal;
        }

        public void AddAdmin(Admin admin)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            var encryedPassword = crypto.Compute(admin.AdminPassword);

            var amdin = new Admin();
            int result = 0;
            if (admin.AdminID == 0)
            {
                amdin.AdminUserName = admin.AdminUserName;
                amdin.AdminPassword = encryedPassword;
                amdin.AdminSalt = crypto.Salt.ToString();
                amdin.AdminRole = admin.AdminRole;
            }
            _AdminDal.Insert(amdin);
        }       

        public void AdminDelete(Admin admin)
        {
            _AdminDal.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _AdminDal.Update(admin);
        }

        public void DogruMu(Admin admin)
        {
            throw new NotImplementedException();
        }

        public Admin GetById(int id)
        {
            return _AdminDal.Get(x => x.AdminID == id);
        }

        public List<Admin> GEtlist()
        {
            return _AdminDal.List();
        }

        public List<Admin> GetListByID(int id)
        {
            return _AdminDal.List(x => x.AdminID == id);
        }

        public bool IsLoginSuccess(string AdmşnUserName, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            bool IsValid = false;
            using (Context db = new Context())
            {
                var user = db.Admins.FirstOrDefault(u => u.AdminUserName == AdmşnUserName);
                if (user != null)
                {
                    if (user.AdminPassword == crypto.Compute(password, user.AdminSalt))
                    {
                        IsValid = true;
                    }
                }
            }
            return IsValid;
        }
    }
}
