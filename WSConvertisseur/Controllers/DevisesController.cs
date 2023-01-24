﻿using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSConvertisseur.Controllers
{
    [Route("api/devises")]
    [ApiController]
    public class DevisesController : ControllerBase
    {
        IList<Devise> devises = new List<Devise>();
        public IList<Devise> Devises { get => devises; set => devises = value; }

        public DevisesController() {
            Devises.Add(new Devise(1, "Dollar", 1.08));
            Devises.Add(new Devise(2, "Franc Suisse", 1.07));
            Devises.Add(new Devise(3, "Yen", 120));
        }
       

        // GET: api/<DevisesController>
        [HttpGet]
        public IEnumerable<Devise> GetAll()
        {
            return Devises;
        }

        // GET api/<DevisesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DevisesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DevisesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DevisesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}