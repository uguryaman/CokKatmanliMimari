﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [StringLength(50)]
        public string AdminUserName { get; set; }

        public string AdminPassword { get; set; }
        public string AdminSalt { get; set; }
        [StringLength(1)]
        public string AdminRole { get; set; }
        
    }
}
