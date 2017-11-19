using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbrigoPetsBackend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AbrigoPetsBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Pet> Pet { get; set; }
        public DbSet<Shelter> Shelter { get; set; }
    }
}
