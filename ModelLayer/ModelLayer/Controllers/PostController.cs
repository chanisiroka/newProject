using Microsoft.AspNetCore.Mvc;
using Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ModelLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IAlgorithem algorithem;
        public PostController(IAlgorithem alg)
        {
            algorithem = alg;
        }
        // GET: api/<PostController>
        [HttpGet]
        public async Task<string> Get()
        {
            return await algorithem.getData();
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PostController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
