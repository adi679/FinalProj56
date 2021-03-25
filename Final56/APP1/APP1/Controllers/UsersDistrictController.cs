using APP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace APP1.Controllers
{
    public class UsersDistrictController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpPost]
        [Route("api/UsersDistrict/1/{email}")]
        public int Get(string email)
        {
            UsersDistrict u = new UsersDistrict();
            return u.get_User_district(email);
        }

        //POST api/<controller>
        [HttpPost]
        [Route("api/UsersDistrict")]
        public int Post(List<UsersDistrict> list_user_districts)
        {
            UsersDistrict u = new UsersDistrict();
           return u.Insert_arry_region(list_user_districts);
           
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

        }
    }
}