using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Model;

namespace TarziniYarat.DataAccess.Concrete.EntityFramework
{
   public class TarziniYaratDbContext :DbContext
    {
        public TarziniYaratDbContext()
           : base("name=TarziniYaratConnStr")
        {

        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Like> Users { get; set; }






        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {




            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
