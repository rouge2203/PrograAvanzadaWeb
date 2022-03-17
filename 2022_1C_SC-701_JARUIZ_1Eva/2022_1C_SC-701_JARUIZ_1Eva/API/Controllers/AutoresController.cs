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
        public class AutoresController : Controller
        {
            private readonly NDbContext _context;
            private readonly IMapper _mapper;

            public AutoresController(NDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            // GET: api/Autores
            [HttpGet]
            public async Task<ActionResult<IEnumerable<models.Autores>>> GetAutores()
            {
                //return new BE.BS.Autores(_context).GetAll().ToList();
                var res = new BE.Autores(_context).GetAll();
                List<models.Autores> mapaAux = _mapper.Map<IEnumerable<data.Autores>, IEnumerable<models.Autores>>(res).ToList();
                return mapaAux;
            }

            // GET: api/Autores/5
            [HttpGet("{id}")]
            public async Task<ActionResult<models.Autores>> GetAutores(int id)
            {
                var Autores = new BE.Autores(_context).GetOneById(id);

                if (Autores == null)
                {
                    return NotFound();
                }
                models.Autores mapaAux = _mapper.Map<data.Autores, models.Autores>(Autores);

                return mapaAux;
            }

            // PUT: api/Autores/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPut("{id}")]
            public async Task<IActionResult> PutAutores(int id, models.Autores Autores)
            {
                if (id != Autores.Id)
                {
                    return BadRequest();
                }

                try
                {
                    data.Autores mapaAux = _mapper.Map<models.Autores, data.Autores>(Autores);
                    new BE.Autores(_context).Update(mapaAux);
                }
                catch (Exception ee)
                {
                    if (!AutoresExists(id))
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

            // POST: api/Autores
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPost]
            public async Task<ActionResult<Autores>> PostAutores(models.Autores Autores)
            {
                try
                {
                    data.Autores mapaAux = _mapper.Map<models.Autores, data.Autores>(Autores);

                    new BE.Autores(_context).Insert(mapaAux);
                }
                catch (Exception)
                {
                    BadRequest();
                }

                return CreatedAtAction("GetAutores", new { id = Autores.Id }, Autores);
            }

            // DELETE: api/Autores/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<models.Autores>> DeleteAutores(int id)
            {
                var Autores = new BE.Autores(_context).GetOneById(id);
                if (Autores == null)
                {
                    return NotFound();
                }

                try
                {
                    new BE.Autores(_context).Delete(Autores);
                }
                catch (Exception)
                {
                    BadRequest();
                }
                models.Autores mapaAux = _mapper.Map<data.Autores, models.Autores>(Autores);

                return mapaAux;
            }

            private bool AutoresExists(int id)
            {
                return (new BE.Autores(_context).GetOneById(id) != null);
            }
        }
    }

