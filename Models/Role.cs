﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Role
    {
        [Key]
        public int Id_Role { get; set; }
        public string Name_Role { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
