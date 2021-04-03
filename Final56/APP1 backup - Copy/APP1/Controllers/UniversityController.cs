﻿using APP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APP1.Controllers
{
    public class UniversityController : ApiController
    {
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet]
        [Route("api/University/getdiv")]
        public List<University> Get()
        {
            University un = new University();
            return un.getdiv();
        }
     



        // GET api/<controller>/5
        public int Get(int division)
        {
            University un= new University();
           return un.getDivision(division);
        }

        // POST api/<controller>
        public void Post(List <University> IUE)
        {
            //University u
            //u.Insert_University_Email(IUE);
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