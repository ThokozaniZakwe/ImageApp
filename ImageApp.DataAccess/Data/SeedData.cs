using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageApp.DataAccess.Data
{
    public static class SeedData
    {
        public static void EnsureSeeded(AppDbContext context)
        {
            context.Database.Migrate();

            if (!context.People.Any())
            {
                var people = new Person[]
                {
                    new Person{ Name = "Thokozani", ImgeUrl = "No Image"},
                    new Person{ Name = "Nkanyiso", ImgeUrl = "No Image" },
                    new Person{ Name = "Lucia", ImgeUrl = "No Image" },
                    new Person{ Name = "Peter", ImgeUrl = "No Image" },
                    new Person{ Name = "Bongani", ImgeUrl = "No Image" },
                    new Person{ Name = "Zipho", ImgeUrl = "No Image" },
                    new Person{ Name = "Zinhle", ImgeUrl = "No Image" },
                    new Person{ Name = "Tumi", ImgeUrl = "No Image" },
                    new Person{ Name = "Homer", ImgeUrl = "No Image" },
                    new Person{ Name = "Batman", ImgeUrl = "No Image" }
                };

                context.People.AddRange(people);
                context.SaveChanges();
            }
        }
    }
}
