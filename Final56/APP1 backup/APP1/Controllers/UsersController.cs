﻿using APP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace APP1.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/<controller>/5
        public List<Users> Get()
        {
            Users user = new Users();
            List<Users> uList = user.Show();
            return uList;

        }
        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5
        [HttpGet]
        [Route("api/Users/{email}/{password}")]
        public int Get(string email, string password)
        {
            Users u = new Users();
            return u.Login_User(email, password);
        }
        [HttpGet]
        [Route("api/Users/{users_show}/Show_all_users")]
        public List <Users> Get(string users_show)
        {
            Users u = new Users();
            return u.Show_Users();
        }


<<<<<<< HEAD
        
       
=======
>>>>>>> eb1b561236a2c86e2c9e5fe12608ed8303ae51dc
        public int Post(Users u)
        {
            return u.Insert_New_Users(u);
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