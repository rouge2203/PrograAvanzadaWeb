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
    public class CustomerDemographicsController : Controller
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
            // GET: api/CustomerDemographics
            [HttpGet]
            public async Task<ActionResult<IEnumerable<models.CustomerDemographics>>> GetCustomerDemographics()
            {
                //return new BE.BS.CustomerDemographics(_context).GetAll().ToList();
                var res = new BE.CustomerDemographics(_context).GetAll();
                List<models.CustomerDemographics> mapaAux = _mapper.Map<IEnumerable<data.CustomerDemographics>, IEnumerable<models.CustomerDemographics>>(res).ToList();
                return mapaAux;
            }

            // GET: api/CustomerDemographics/5
            [HttpGet("{id}")]
            public async Task<ActionResult<models.CustomerDemographics>> GetCustomerDemographics(string id)
            {
                var CustomerDemographics = new BE.CustomerDemographics(_context).GetOneById(id);

                if (CustomerDemographics == null)
                {
                    return NotFound();
                }
                models.CustomerDemographics mapaAux = _mapper.Map<data.CustomerDemographics, models.CustomerDemographics>(CustomerDemographics);

                return mapaAux;
            }

            // PUT: api/CustomerDemographics/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPut("{id}")]
            public async Task<IActionResult> PutCustomerDemographics(string id, models.CustomerDemographics CustomerDemographics)
            {
                if (id != CustomerDemographics.CustomerTypeId)
                {
                    return BadRequest();
                }

                try
                {
                    data.CustomerDemographics mapaAux = _mapper.Map<models.CustomerDemographics, data.CustomerDemographics>(CustomerDemographics);
                    new BE.CustomerDemographics(_context).Update(mapaAux);
                }
                catch (Exception ee)
                {
                    if (!CustomerDemographicsExists(id))
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

            // POST: api/CustomerDemographics
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPost]
            public async Task<ActionResult<CustomerDemographics>> PostCustomerDemographics(models.CustomerDemographics CustomerDemographics)
            {
                try
                {
                    data.CustomerDemographics mapaAux = _mapper.Map<models.CustomerDemographics, data.CustomerDemographics>(CustomerDemographics);

                    new BE.CustomerDemographics(_context).Insert(mapaAux);
                }
                catch (Exception)
                {
                    BadRequest();
                }

                return CreatedAtAction("GetCustomerDemographics", new { id = CustomerDemographics.CustomerTypeId }, CustomerDemographics);
            }

            // DELETE: api/CustomerDemographics/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<models.CustomerDemographics>> DeleteCustomerDemographics(string id)
            {
                var CustomerDemographics = new BE.CustomerDemographics(_context).GetOneById(id);
                if (CustomerDemographics == null)
                {
                    return NotFound();
                }

                try
                {
                    new BE.CustomerDemographics(_context).Delete(CustomerDemographics);
                }
                catch (Exception)
                {
                    BadRequest();
                }
                models.CustomerDemographics mapaAux = _mapper.Map<data.CustomerDemographics, models.CustomerDemographics>(CustomerDemographics);

                return mapaAux;
            }

            private bool CustomerDemographicsExists(string id)
            {
                return (new BE.CustomerDemographics(_context).GetOneById(id) != null);
            }
        }
    }
}