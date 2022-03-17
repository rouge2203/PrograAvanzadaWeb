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
    public class Autores : ICRUD<data.Autores>
    {
        private Repository<data.Autores> repo;
        public Autores(NDbContext dbContext)
        {
            repo = new Repository<data.Autores>(dbContext);
        }
        public void Delete(data.Autores t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Autores> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Autores>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Autores GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Autores> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Autores t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Autores t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }

}
