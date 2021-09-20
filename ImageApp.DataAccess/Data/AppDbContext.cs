using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageApp.DataAccess.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<Person> People { get; set; }
    }
}
