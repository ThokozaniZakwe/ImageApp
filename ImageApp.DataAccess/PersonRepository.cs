using ImageApp.DataAccess.Data;
using ImageApp.DataAccess.IRepository;
using ImageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageApp.DataAccess
{
    public class PersonRepository: Repository<Person>, IPersonRepository
    {
        private readonly AppDbContext context;

        public PersonRepository(AppDbContext ctx):base(ctx)
        {
            context = ctx;
        }

        public void Update(Person person)
        {
            var objFromDb = context.People.FirstOrDefault(p => p.Id == person.Id);
            if(objFromDb != null)
            {
                objFromDb.Name = person.Name;
                objFromDb.ImgeUrl = person.ImgeUrl;
            }
        }
    }
}
