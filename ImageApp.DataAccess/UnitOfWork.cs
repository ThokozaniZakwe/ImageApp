using ImageApp.DataAccess.Data;
using ImageApp.DataAccess.IRepository;
using ImageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ImageApp.DataAccess
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AppDbContext context;

        public UnitOfWork(AppDbContext ctx)
        {
            context = ctx;
            Person = new PersonRepository(context);
        }
        public IPersonRepository Person { get; private set; }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
