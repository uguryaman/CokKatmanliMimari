using DataAccessLayer.Concreate;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KatmanlıMvc.Models
{
    public class LoginCheck
    {
        Context _contex;

        public LoginCheck()
        {
            _contex = new Context();
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

        //public bool IsLoginSuccess(Admin admin)
        //{
        //    var crypto = new SimpleCrypto.PBKDF2();
        //    var user = _contex.Admins.Where(x => x.AdminUserName == admin.AdminUserName).FirstOrDefault();
        //    if (user!=null)
        //    {
        //        if (user.AdminPassword==crypto.Compute(admin.AdminPassword, admin.AdminSalt))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}



    }
}

   