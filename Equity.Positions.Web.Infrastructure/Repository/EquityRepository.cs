using Equity.Positions.Web.Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equity.Positions.Web.Infrastructure.Repository
{
    public class EquityRepository<T> : IEquityRepository<T> where T : class
    {
        AppDBContext _context;

        public EquityRepository(AppDBContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T Entity)
        {
            _context.Add<T>(Entity);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(T Entity)
        {
            throw new NotImplementedException();
        }
    }
}
