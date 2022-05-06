using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BelInt_WebHelper
{
    public class BelIntDbContext : IdentityDbContext<Models.User>
    {
        public BelIntDbContext(DbContextOptions<BelIntDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
