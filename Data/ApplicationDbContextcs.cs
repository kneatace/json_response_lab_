using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using json_return_lab_practice.Models;

namespace json_return_lab_practice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductClass> Products { get; set; }
    }
}
