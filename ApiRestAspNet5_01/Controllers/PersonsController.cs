using ApiRestAspNet5_01.Model;
using ApiRestAspNet5_01.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiRestAspNet5_01.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonsController : ControllerBase
    {
        private readonly ILogger<PersonsController> _logger;
        private IPersonService _personService;

        public PersonsController(ILogger<PersonsController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var persons = _personService.FindAll();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
