using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
   public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        [StringLength(100)]

        public string UserName { get; set; }

        [StringLength(250)]

        public string UserMail { get; set; }
        [StringLength(100)]

        public string Subject { get; set; }

        public string Message { get; set; }
        public DateTime MessageDate { get; set; }

        public bool ContactStatus { get; set; }
    }
}
