using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using SenderAPI.Models;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SenderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        public readonly IConfiguration _configuration;

        public ItemsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        // POST api/<ItemsController>

        [HttpPost]
        public async Task<IActionResult> Create(string item)
        {
            IQueueClient queueClient = new QueueClient(_configuration["QueueConnectionStrings"], _configuration["QueueName"]);
            //var orderJSON = JsonConvert.SerializeObject(item);
            var orderMessage = new Message(Encoding.UTF8.GetBytes(item))
            {
                MessageId = Guid.NewGuid().ToString(),
                ContentType = "application/json"
            };
            await queueClient.SendAsync(orderMessage).ConfigureAwait(false);
            return Ok("Sent Successfully!");
        }
    }
}
