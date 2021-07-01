using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Ability
    {
        [Key]
        public int AbilityID { get; set; }
        [StringLength(60)]
        public string AbilityName { get; set; }
        public int AbilityValue { get; set; }
        public int AbilitBarsValue { get; set; }
    }
}
