using MassTransit;
using MassTranzitT4_GTaylor_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MassTranzitT4_GTaylor_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        readonly IPublishEndpoint _publishEndpoint;

        public ValueController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        // GET: api/<ValueController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValueController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValueController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            await _publishEndpoint.Publish<ExampleClass>(new
            {
                Value = value
            });

            return Ok();
        }

        // PUT api/<ValueController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValueController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
