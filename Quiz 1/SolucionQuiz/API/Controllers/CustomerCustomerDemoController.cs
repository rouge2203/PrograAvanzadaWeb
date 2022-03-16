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
    public class CustomerCustomerDemoController : ControllerBase
    {
        private readonly NDbContext dbcontext;
        private readonly IMapper mapper;

        public CustomerCustomerDemoController(NDbContext context, IMapper _mapper)
        {
            dbcontext = context;
            mapper = _mapper;
        }

        // GET: api/CustomerCustomerDemo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.CustomerCustomerDemo>>> GetCustomerCustomerDemo()
        {
            var res = await new BE.CustomerCustomerDemo(dbcontext).GetAllAsync();
            var mapaux = mapper.Map<IEnumerable<data.CustomerCustomerDemo>, IEnumerable<models.CustomerCustomerDemo>>(res).ToList();
            return mapaux;
        }

        // GET: api/CustomerCustomerDemo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.CustomerCustomerDemo>> GetCustomerCustomerDemo(string id)
        {
            var CustomerCustomerDemo = await new BE.CustomerCustomerDemo(dbcontext).GetOneByIdAsync(id);
            var mapaux = mapper.Map<data.CustomerCustomerDemo, models.CustomerCustomerDemo>(CustomerCustomerDemo);

            if (CustomerCustomerDemo == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/CustomerCustomerDemo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerCustomerDemo(string id, models.CustomerCustomerDemo CustomerCustomerDemo)
        {
            if (id != CustomerCustomerDemo.CustomerTypeId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.CustomerCustomerDemo, data.CustomerCustomerDemo>(CustomerCustomerDemo);
                new BE.CustomerCustomerDemo(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!CustomerCustomerDemoExists(id))
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

        // POST: api/CustomerCustomerDemo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.CustomerCustomerDemo>> PostCustomerCustomerDemo(models.CustomerCustomerDemo CustomerCustomerDemo)
        {
            try
            {
                var mapaux = mapper.Map<models.CustomerCustomerDemo, data.CustomerCustomerDemo>(CustomerCustomerDemo);
                new BE.CustomerCustomerDemo(dbcontext).Insert(mapaux);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return CreatedAtAction("GetCustomerCustomerDemo", new { id = CustomerCustomerDemo.CustomerTypeId }, CustomerCustomerDemo);
        }

        // DELETE: api/CustomerCustomerDemo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.CustomerCustomerDemo>> DeleteCustomerCustomerDemo(string id)
        {
            var CustomerCustomerDemo = new BE.CustomerCustomerDemo(dbcontext).GetOneById(id);
            var mapaux = mapper.Map<data.CustomerCustomerDemo, models.CustomerCustomerDemo>(CustomerCustomerDemo);
            if (CustomerCustomerDemo == null)
            {
                return NotFound();
            }

            try
            {
                new BE.CustomerCustomerDemo(dbcontext).Delete(CustomerCustomerDemo);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return mapaux;
        }

        private bool CustomerCustomerDemoExists(string id)
        {
            return (new BE.CustomerCustomerDemo(dbcontext).GetOneById(id) != null);
        }
    }
}
