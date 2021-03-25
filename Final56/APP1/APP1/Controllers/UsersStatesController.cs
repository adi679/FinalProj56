using APP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APP1.Controllers
{
    public class UsersStatesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
   

        // PUT api/<controller>/5
        public void Put(List<UsersStates> lus)
        {
           lus[0].Insert_arr_states(lus);

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        [HttpPost]
        [Route("api/UsersDistrict/list_user_States")]
        public int Post(List<UsersStates> us)
        {
            UsersStates usersstates = new UsersStates();
            return usersstates.Insert_arr_states(us);

        }
    }
}