using System;
using System.Collections.Generic;
using System.Text;
using data = DAL.DO.Objects;
using dal = DAL;
using DAL.DO.Interfaces;
using System.Threading.Tasks;
using DAL.EF;


namespace BE
{
    public class Libros : ICRUD<data.Libros>
    {
        private dal.Libros _dal;
        public Libros(NDbContext dbContext)
        {
            _dal = new dal.Libros(dbContext);
        }
        public void Delete(data.Libros t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Libros> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Libros>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Libros GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Libros> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Libros t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Libros t)
        {
            _dal.Update(t);
        }
    }

}
