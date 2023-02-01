using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSConvertisseur.Controllers
{
    [Route("api/devises")]
    [ApiController]
    public class DevisesController : ControllerBase
    {
        List<Devise> devises = new List<Devise>();
        public List<Devise> Devises { get => devises; set => devises = value; }

        public DevisesController() {
            Devises.Add(new Devise(1, "Dollar", 1.08));
            Devises.Add(new Devise(2, "Franc Suisse", 1.07));
            Devises.Add(new Devise(3, "Yen", 120));
        }

        /// <summary>
        /// Get all currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <response code="200">When the currency id is found</response>
        /// <response code="404">When the currency id is not found</response>
        // GET: api/<DevisesController>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet]
        public IEnumerable<Devise> GetAll()
        {
            return Devises;
        }

        /// <summary>
        /// Get a single currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the currency</param>
        /// <response code="200">When the currency id is found</response>
        /// <response code="404">When the currency id is not found</response>
        // GET api/<DevisesController>/5
        [HttpGet("{id}", Name ="GetDevise")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Devise> GetById([FromRoute] int id)
        {
            Devise? devise = devises.FirstOrDefault((d) => d.Id == id);
            if (devise == null)
            {
                return NotFound();
            }
            return devise;
        }

        /// <summary>
        /// POST (Create) a new devise
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="devise">Object devise</param>
        /// <response code="200">When the currency id is found</response>
        /// <response code="404">When the currency id is not found</response>
        // POST api/<DevisesController>
        [HttpPost]
        [ProducesResponseType(200)]
        public ActionResult<Devise> Post([FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            devises.Add(devise);
            return CreatedAtRoute("GetDevise", new { id = devise.Id }, devise);
        }

        /// <summary>
        /// Update a single currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the currency</param>
        /// <param name="devise">Object where change attribute</param>
        /// <response code="200">When the currency id is found</response>
        /// <response code="404">When the currency id is not found</response>
        // PUT api/<DevisesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult Put(int id, [FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != devise.Id)
            {
                return BadRequest();
            }
            int index = Devises.FindIndex((d) => d.Id == id);
            if (index < 0)
            {
                return NotFound();
            }
            devises[index] = devise;
            return NoContent();
        }

        /// <summary>
        /// Delete a single currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the currency</param>        
        /// <response code="200">When the currency id is found</response>
        /// <response code="404">When the currency id is not found</response>
        // DELETE api/<DevisesController>/5
        [HttpDelete("{id}", Name = "GetDevise")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<bool> Delete(int id)
        {
            Devise? devise = Devises.FirstOrDefault((d) => d.Id == id);
            if (devise == null)
            {
                return NoContent();
            }
            return Devises.Remove(devise);
        }





    }
}
