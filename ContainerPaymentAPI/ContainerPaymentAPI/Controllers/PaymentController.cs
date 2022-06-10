using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContainerPaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly SqlConnection _connection;
        private SqlDataAdapter _adapter;
        private DataTable _dataTable = new DataTable();

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
        public ActionResult<IEnumerable<Payment>> Get()
        {
            List<Payment> fees = new List<Payment>();
            _adapter = new SqlDataAdapter("SELECT * FROM Payment", _connection);
            _adapter.Fill(_dataTable);
            _connection.Close();

            foreach (DataRow row in _dataTable.Rows)
            {
                fees.Add(new Payment
                {
                    containerId = Convert.ToString(row["ContainerID"]),
                    Amount = (float)Convert.ToDouble(row["Amount"]),
                });
            }
            return fees;
        }
        [HttpGet("{ContainerID}")]
        public ActionResult<Payment> Details(string ContainerID)
        {
            return GetFees().Find(p => p.containerId == ContainerID);
        }
        [HttpPut]
        public ActionResult<Payment> Edit(string ContainerID)
        {
            Payment fees = new Payment();
            fees = GetFees().Find(p => p.containerId == ContainerID);
            _adapter = new SqlDataAdapter("UPDATE Payment SET Amount = 0 WHERE containerId = '" + ContainerID + "'", _connection);
            _adapter.Fill(_dataTable);
            _connection.Close();
            return fees;
        }

    }
}
