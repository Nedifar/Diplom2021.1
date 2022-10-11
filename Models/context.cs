using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class context : DbContext
    {
        private static context _context;
        public context() : base("sqLiteConnection") { }
        public static context AgetDB()
        {
            if (_context == null)
                _context = new context();
            return _context;
        }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Organization> Organizations { get; set; }
    }
}
