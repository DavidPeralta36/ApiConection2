using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static List<string> valuesList = new List<string> { "valor1", "valor22" };

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return valuesList;
        }

        [HttpPost]
        public IActionResult Post([FromBody] string newValue)
        {
            valuesList.Add(newValue);
            Console.WriteLine(valuesList.Count());
            return Ok();
        }
    }
}
