using Microsoft.AspNetCore.Mvc;
using ppedv.CarRent8000.Model.Contracts;
using ppedv.CarRent8000.Model.DomainModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ppedv.CarRent8000.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IRepository repository;

        public CarsController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/<CarsController>
        [HttpGet]
        public IEnumerable<CarDTO> Get()
        {
            return repository.GetAll<Car>().Select(x => CarDTO.ToDTO(x));
        }

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CarsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
