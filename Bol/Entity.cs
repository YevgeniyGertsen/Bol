using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bol
{
    public class Entity: DbContext
    {
        public Entity() : base("DefaultConnection"){ }
        public DbSet<TablePatient> TablePatients { get; set; }
        public DbSet<TableUsers> TableUsers { get; set; }
        public DbSet<TableUserRoles> TableUserRoles { get; set; }
        public DbSet<TableMedOraganizations> TableMedOraganizations { get; set; }
        public DbSet<TableRequests> TableRequests { get; set; }
    }
}
