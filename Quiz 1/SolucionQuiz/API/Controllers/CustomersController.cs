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
    public class CustomersController : Controller
    {
        [Route("api/[controller]")]
        [ApiController]
        public class CustomerController : Controller
        {
            private readonly NDbContext _context;
            private readonly IMapper _mapper;

            public CustomerController(NDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            // GET: api/Customers
            [HttpGet]
            public async Task<ActionResult<IEnumerable<models.Customers>>> GetCustomers()
            {
                //return new BE.BS.Customers(_context).GetAll().ToList();
                var res = new BE.Customers(_context).GetAll();
                List<models.Customers> mapaAux = _mapper.Map<IEnumerable<data.Customers>, IEnumerable<models.Customers>>(res).ToList();
                return mapaAux;
            }

            // GET: api/Customers/5
            [HttpGet("{id}")]
            public async Task<ActionResult<models.Customers>> GetCustomers(string id)
            {
                var Customers = new BE.Customers(_context).GetOneById(id);

                if (Customers == null)
                {
                    return NotFound();
                }
                models.Customers mapaAux = _mapper.Map<data.Customers, models.Customers>(Customers);

                return mapaAux;
            }

            // PUT: api/Customers/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPut("{id}")]
            public async Task<IActionResult> PutCustomers(string id, models.Customers Customers)
            {
                if (id != Customers.CustomerId)
                {
                    return BadRequest();
                }

                try
                {
                    data.Customers mapaAux = _mapper.Map<models.Customers, data.Customers>(Customers);
                    new BE.Customers(_context).Update(mapaAux);
                }
                catch (Exception ee)
                {
                    if (!CustomersExists(id))
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

            // POST: api/Customers
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPost]
            public async Task<ActionResult<Customers>> PostCustomers(models.Customers Customers)
            {
                try
                {
                    data.Customers mapaAux = _mapper.Map<models.Customers, data.Customers>(Customers);

                    new BE.Customers(_context).Insert(mapaAux);
                }
                catch (Exception)
                {
                    BadRequest();
                }

                return CreatedAtAction("GetCustomers", new { id = Customers.CustomerId }, Customers);
            }

            // DELETE: api/Customers/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<models.Customers>> DeleteCustomers(string id)
            {
                var Customers = new BE.Customers(_context).GetOneById(id);
                if (Customers == null)
                {
                    return NotFound();
                }

                try
                {
                    new BE.Customers(_context).Delete(Customers);
                }
                catch (Exception)
                {
                    BadRequest();
                }
                models.Customers mapaAux = _mapper.Map<data.Customers, models.Customers>(Customers);

                return mapaAux;
            }

            private bool CustomersExists(string id)
            {
                return (new BE.Customers(_context).GetOneById(id) != null);
            }
        }
    }
}
