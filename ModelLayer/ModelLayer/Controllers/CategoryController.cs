using Common.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ModelLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IService<CategoryDto> service;
        public CategoryController(IService<CategoryDto> service)
        {
            this.service = service;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public Task<List<CategoryDto>> Get()
        {
            return service.GetAll();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public Task<CategoryDto> Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        [Authorize]
        public async Task<CategoryDto> Post([FromForm] CategoryDto value)
        {
            //שמירת התמונה בתקייה
            //יוצרת ניתוב לתמונה
           
            
           return await service.AddItem(value);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] CategoryDto value)
        {
          await  service.UpdateItem(id, value);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           await service.DeleteItem(id);
        }
    }
}
