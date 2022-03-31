using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equity.Positions.Web.Infrastructure.Repository.Interface
{
    public interface IEquityRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T Entity);
        void Update(T Entity);
        void Delete(int id);
        void Save();
    }
}
