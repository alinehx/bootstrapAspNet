using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Business;
using Core.Data.Repositories;
using Core.Interfaces.Data;

namespace Core.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IDatabase _idatabase;
        public ValuesController(IDatabase database)
        {
            _idatabase = database;
        }
        // GET api/values
        [HttpGet]
        public List<OrderRepository> Get()
        {
            
            OrderRepository orderRepository = new OrderRepository(_idatabase);
            Order order = new Order(orderRepository);

            var returnValue = order.getAll();

            return returnValue;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
