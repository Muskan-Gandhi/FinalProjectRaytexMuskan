using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Web1.Models;
using Web1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EDIController : ControllerBase
    {
        private Container _container;
        private readonly ICosmosDbServices _cosmosDbServices;
        // GET: api/<EDIController>
        public EDIController(ICosmosDbServices cosmosDbServices)
        {
            _cosmosDbServices = cosmosDbServices ?? throw new ArgumentNullException(nameof(cosmosDbServices));
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await _cosmosDbServices.GetMultipleAsync("Select * from c"));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _cosmosDbServices.GetAsync(id));
        }
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(string id)
        //{
        //    EDI edi =await _cosmosDbServices.GetAsync(id);
        //    var query = _container.EDI(new QueryDefinition(queryString));
        //    var results = new List<EDI>();
        //    while (query.HasMoreResults)
        //    {
        //        var respone = await query.ReadNextAsync();
        //        results.AddRange(respone.ToList());
        //    }
        //    return results;
        //}


        // GET api/<EDIController>/5
        /*
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EDIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EDIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EDIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/

    }
}
