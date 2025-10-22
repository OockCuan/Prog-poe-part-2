using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProgPOE.Models;

namespace ProgPOE.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Claim> Claim { get; set; }
    }
}
