using FE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FE.Services
{
    public interface IKidsServices
    {
        void Insert(Kids t);
        void Update(Kids t);
        void Delete(Kids t);
        IEnumerable<Kids> GetAll();
        Kids GetOneById(int id);
        Task<IEnumerable<Kids>> GetAllAsync();
        Task<Kids> GetOneByIdAsync(int id);
    }
}