using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContainersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
        public class ContainerFeesController : Controller
        {
            private readonly SqlConnection _connection;
            private SqlDataAdapter _adapter;
            private DataTable _dataTable = new DataTable();

            public ContainerFeesController()
            {
                _connection = new SqlConnection("Server=EFCYIT-LTR91;Database=eModalProject;Trusted_Connection=True;MultipleActiveResultSets=true;");
                _connection.Open();
            }
            private List<Container> GetFees()
            {
                List<Container> fees = new List<Container>();
                _adapter = new SqlDataAdapter("SELECT * FROM Containers", _connection);
                _adapter.Fill(_dataTable);
                _connection.Close();

                foreach (DataRow row in _dataTable.Rows)
                {
                    fees.Add(new Container
                    {
                        containerId = Convert.ToString(row["containerId"])
                    });
                }
                return fees;
            }

            [HttpGet]
            public ActionResult<IEnumerable<Container>> Get()
            {
                List<Container> fees = new List<Container>();
                _adapter = new SqlDataAdapter("SELECT * FROM Containers", _connection);
                _adapter.Fill(_dataTable);
                _connection.Close();

                foreach (DataRow row in _dataTable.Rows)
                {
                    fees.Add(new Container
                    {
                        containerId = Convert.ToString(row["containerId"]),
                        
                    });
                }
                return fees;
            }
            [HttpGet("{ContainerID}")]
            public ActionResult<Container> Details(string ContainerID)
            {
                return GetFees().Find(p => p.containerId == ContainerID);
            }
            [HttpPost]
            public ActionResult<IEnumerable<Container>> AddContainer([FromBody] Container container)
            {
            _adapter = new SqlDataAdapter("insert into Containers (containerId) values('"+container.containerId+"')", _connection);
            _adapter.Fill(_dataTable);
            _connection.Close();
            return GetFees();
            }
            

        }
    }

