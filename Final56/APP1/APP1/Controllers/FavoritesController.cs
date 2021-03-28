using APP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APP1.Controllers
{
    public class FavoritesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet]
        [Route("api/Favorites/{UniversityLevel}/get_all_D")]
        public List<Favorites> Get(int UniversityLevel)
        {
            Favorites f = new Favorites();
            return f.get_User_D(UniversityLevel);
        }


        [HttpGet]
        [Route("api/Favorites/{email}/{cost}/{sit}/{UniversityType}/{UniversitySize}/{UniversityLevel}/get_all_fav")]
        public List<Favorites> Get(string email, int cost, int sit ,int UniversityType, int UniversitySize, int UniversityLevel)
        {
            Favorites f = new Favorites();
            return f.get_all_fav(email, cost,sit, UniversityType, UniversitySize, UniversityLevel);
        }




        // GET api/<controller>/5
        //למה פםעמיים גט?
        //public List<Favorites> Get(string email, int id)
        //{
        //    Favorites f = new Favorites();
        //    return f.Get_Favorites_By_email(email,id);
        //}

        // POST api/<controller>
        public void Post(Favorites f )
        {
            f.Insert_Favorites(f);
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