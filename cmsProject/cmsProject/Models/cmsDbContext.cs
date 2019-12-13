using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsProject.Models
{
    public class cmsDbContext:DbContext
    {
        public cmsDbContext(DbContextOptions<cmsDbContext> options) : base(options)
        {

        }
        public DbSet<UserAccount> UserAccounts { get; set; }

        public DbSet<Content> Contents { get; set; }

    }
}
