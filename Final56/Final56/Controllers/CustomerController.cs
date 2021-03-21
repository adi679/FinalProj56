using APP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APP1.Controllers
{
    public class CustomerController : ApiController
    {
        public List<Customer> Get()
        {
            Customer costumer = new Customer();
            List<Customer> cList = costumer.Show();
            return cList;

        }

        [HttpGet]
        [Route("api/Costumer/{email}/{password}")]
        public bool Get(string email, string password)
        {
            Customer customer = new Customer();
            return customer.show_u(email, password);

        }
        // POST api/<controller>
        public int Post([FromBody]Customer customer)
        {
            return customer.InsertCust();
        }
        [HttpPost]
        [Route("api/Costumer/{title}/0")]
        public int Post(string title)
        {
            Customer customer = new Customer();

            return customer.title(title);
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("api/Customer/{title}/{email}/{status}")]
        public int Put(string title, string email, int status)
        {
            Customer customer = new Customer();
             return customer.put_c(title, email, status);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}