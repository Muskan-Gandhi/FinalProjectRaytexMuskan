using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly SqlConnection _connection;
        private SqlDataAdapter _adapter;
        private DataTable _dataTable = new DataTable();



        string connectionString = "Endpoint=sb://trngahmedabd.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=kkNMAoMhIPaQouXaiB570uBPdiXSba1lHxOHebdJ5go=";
        string queueName = "queue-muskan";

        public PaymentController()
        {
            _connection = new SqlConnection("Server=EFCYIT-LTR91;Database=eModalProject;Trusted_Connection=True;MultipleActiveResultSets=true;");
            _connection.Open();
        }
        private List<Payment> GetFees()
        {
            List<Payment> fees = new List<Payment>();
            _adapter = new SqlDataAdapter("SELECT * FROM Payment", _connection);
            _adapter.Fill(_dataTable);
            _connection.Close();

            foreach (DataRow row in _dataTable.Rows)
            {
                fees.Add(new Payment
                {
                    containerId = Convert.ToString(row["containerId"]),
                    Amount = (float)Convert.ToDouble(row["Amount"]),
                });
            }
            return fees;
        }




        [HttpGet]
        public async Task<IActionResult> Get()
        {

            //    await using var client = new ServiceBusClient(connectionString);

            //    ServiceBusReceiver receiver = client.CreateReceiver(queueName);
            //    ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();


            //    string body = receivedMessage.Body.ToString();
            //    dynamic json = JsonConvert.DeserializeObject(body);


            //return Ok(json);

            List<Payment> fees = new List<Payment>();
            _adapter = new SqlDataAdapter("SELECT * FROM Payment", _connection);
            _adapter.Fill(_dataTable);
            _connection.Close();

            foreach (DataRow row in _dataTable.Rows)
            {
                fees.Add(new Payment
                {
                    containerId = Convert.ToString(row["containerId"]),
                    Amount = (float)Convert.ToDouble(row["Amount"]),
                });
            }
            return Ok(fees);

        }




        [HttpGet("{ContainerID}")]
        public ActionResult<Payment> Details(string containerId)
        {
            return GetFees().Find(p => p.containerId == containerId);
        }
        [HttpPut]
        public ActionResult<Payment> Edit(string containerId)
        {

            Payment fees = new Payment();
            fees = GetFees().Find(p => p.containerId == containerId);
            _adapter = new SqlDataAdapter("UPDATE Payment SET Amount = 0 WHERE containerId = '" + containerId + "'", _connection);
            _adapter.Fill(_dataTable);
            _connection.Close();
            return fees;
        }


}
}
