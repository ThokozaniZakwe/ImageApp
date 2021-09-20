using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageApp.Models;

namespace ImageApp.DataAccess.IRepository
{
    public interface IPersonRepository: IRepository<Person>
    {
        void Update(Person person);
    }
}
