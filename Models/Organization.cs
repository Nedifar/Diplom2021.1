using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Organization
    {
        [Key]
        public int Id_Org { get; set; }
        [Required]
        [StringLength(50, MinimumLength =3)]
        public string Leader_Last_Name { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Leader_First_Name { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Leader_Middle_Name { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Org_Name { get; set; }
        [Required]
        [Phone]
        public string Org_Telephone { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string INN { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string OGRN { get; set; }
        public int Id_User { get; set; }
        public List<Contract> Contracts { get; set; } = new List<Contract>();
        public User User { get; set; }
        public string fullName 
        {
            get
            {
                return $"{Leader_Last_Name} {Leader_First_Name} {Leader_Middle_Name}";
            }
        }
    }
}
