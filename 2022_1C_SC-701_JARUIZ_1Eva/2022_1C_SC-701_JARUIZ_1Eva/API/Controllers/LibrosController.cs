using AutoMapper;
using DAL.DO.Objects;
using DAL.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using models = API.DataModels;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly NDbContext dbcontext;
        private readonly IMapper mapper;

        public LibrosController(NDbContext context, IMapper _mapper)
        {
            dbcontext = context;
            mapper = _mapper;
        }

        // GET: api/Libros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Libros>>> GetLibros()
        {
            var res = await new BE.Libros(dbcontext).GetAllAsync();
            var mapaux = mapper.Map<IEnumerable<data.Libros>, IEnumerable<models.Libros>>(res).ToList();
            return mapaux;
        }

        // GET: api/Libros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Libros>> GetLibros(int id)
        {
            var Libros = await new BE.Libros(dbcontext).GetOneByIdAsync(id);
            var mapaux = mapper.Map<data.Libros, models.Libros>(Libros);

            if (Libros == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Libros/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibros(int id, models.Libros Libros)
        {
            if (id != Libros.Id)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Libros, data.Libros>(Libros);
                new BE.Libros(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!LibrosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Libros
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Libros>> PostLibros(models.Libros Libros)
        {
            try
            {
                var mapaux = mapper.Map<models.Libros, data.Libros>(Libros);
                new BE.Libros(dbcontext).Insert(mapaux);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return CreatedAtAction("GetLibros", new { id = Libros.Id }, Libros);
        }

        // DELETE: api/Libros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Libros>> DeleteLibros(int id)
        {
            var Libros = new BE.Libros(dbcontext).GetOneById(id);
            var mapaux = mapper.Map<data.Libros, models.Libros>(Libros);
            if (Libros == null)
            {
                return NotFound();
            }

            try
            {
                new BE.Libros(dbcontext).Delete(Libros);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return mapaux;
        }

        private bool LibrosExists(int id)
        {
            return (new BE.Libros(dbcontext).GetOneById(id) != null);
        }
    }
}
