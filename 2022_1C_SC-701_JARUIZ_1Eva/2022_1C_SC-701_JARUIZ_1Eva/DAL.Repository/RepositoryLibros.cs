using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;


namespace DAL.Repository
{
    public class RepositoryLibros : Repository<data.Libros>, IRepositoryLibros
    {

        public RepositoryLibros(NDbContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<data.Libros>> GetAllAsync()
        {
            return (IEnumerable<data.Libros>)await _db.Libros
                .Include(m => m.Autor)
                .ToListAsync();
        }

        public async Task<data.Libros> GetOneByIdAsync(int id)
        {
            return await _db.Libros
                .Include(m => m.Autor)
                .SingleOrDefaultAsync(m => m.AutorId == id);

            return null;
        }
        private NDbContext _db
        {
            get { return dbContext as NDbContext; }
        }
    }

}
