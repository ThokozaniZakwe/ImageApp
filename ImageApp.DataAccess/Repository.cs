using ImageApp.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageApp.DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ImageApp.DataAccess
{
    public class Repository<T>: IRepository<T> where T:class
    {
        private readonly AppDbContext context;
        internal DbSet<T> dbSet;

        public Repository(AppDbContext ctx)
        {
            context = ctx;
            this.dbSet = ctx.Set<T>();
        }

        public IEnumerable<T> GetAll() => dbSet.ToList();

        public T Get(int id) => dbSet.Find(id);

        public void Delete(int id)
        {
            Delete(dbSet.Find(id));
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }
    }
}
