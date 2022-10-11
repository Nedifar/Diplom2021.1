using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class User
    {
        [Key]
        public int Id_User { get; set; }
        [StringLength(50, MinimumLength = 1)]
        public string Login { get; set; }
        [StringLength(50, MinimumLength = 1)]
        public string Password { get; set; }
        public int Id_Role { get; set; }
        public Role Role { get; set; }
        public List<Organization> Organizations { get; set; } = new List<Organization>();
    }
}
