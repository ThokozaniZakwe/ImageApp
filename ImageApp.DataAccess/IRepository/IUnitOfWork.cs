using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageApp.DataAccess.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
        IPersonRepository Person { get; }
        void Save();
    }
}
