using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BelInt_WebHelper.Models;
using Microsoft.AspNetCore.Identity;
using BelInt_WebHelper.Data;

namespace BelInt_WebHelper
{
    public class BelIntDbContext : IdentityDbContext<Models.User>
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Organisation> Organisations { get; set; }

        public BelIntDbContext(DbContextOptions<BelIntDbContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var dbinitializer = new DbInitializer();
            base.OnModelCreating(builder);
            dbinitializer.SeedOrganisations(builder);
            dbinitializer.SeedDepartments(builder);
            dbinitializer.SeedRoles(builder);
            dbinitializer.SeedUsers(builder);
            dbinitializer.SeedUserRoles(builder);
        }

    }
}
