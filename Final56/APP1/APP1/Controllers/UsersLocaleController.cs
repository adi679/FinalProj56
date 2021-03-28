using APP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APP1.Controllers
{
    public class UsersLocaleController : ApiController
    {

        [HttpGet]
        [Route("api/UsersDistrict/{email}/get_all_Locale")]
        public List<UsersLocale> Get(string email)
        {
            UsersLocale u = new UsersLocale();
            return u.get_User_Locale(email);
        }
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

        [HttpPost]
        [Route("api/UsersLocale/list_user_Locale")]
        public int Post(List<UsersLocale> us)
        {
           
            return us[0].Insert_arr_Locale(us);

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