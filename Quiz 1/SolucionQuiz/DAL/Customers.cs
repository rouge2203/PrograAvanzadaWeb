using System;
using System.Collections.Generic;
using System.Text;
using data = DAL.DO.Objects;
using DAL.EF;
using DAL.Repository;
using DAL.DO.Interfaces;
using System.Threading.Tasks;

namespace DAL
{
   
    public class Customers : ICRUD<data.Customers>
    {
        private Repository<data.Customers> repo;
        public Customers(NDbContext dbContext)
        {
            repo = new Repository<data.Customers>(dbContext);
        }
        public void Delete(data.Customers t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Customers> GetAll()
        {
            return repo.GetAll();
        }
        
        public Task<IEnumerable<data.Customers>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Customers GetOneById(string id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Customers> GetOneByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Customers t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Customers t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
