using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;


namespace DAL.Repository
{
    public interface IRepositoryLibros : IRepository<data.Libros>
    {
        Task<IEnumerable<data.Libros>> GetAllAsync();
        Task<data.Libros> GetOneByIdAsync(int id);
    }

}
