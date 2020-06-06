namespace TarziniYarat.DataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TarziniYarat.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<TarziniYarat.DataAccess.Concrete.EntityFramework.TarziniYaratDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(TarziniYarat.DataAccess.Concrete.EntityFramework.TarziniYaratDbContext context)
        {
            List<Role> roles = new List<Role>()
            {
                new Role(){RoleName="Admin"},
                new Role(){RoleName="Uye"},
                new Role(){RoleName="Modelist"},
                new Role(){RoleName="Ziyaretci", IsActive=false},

            };
            context.Roles.AddRange(roles);
            context.SaveChanges();
        }
    }
}
