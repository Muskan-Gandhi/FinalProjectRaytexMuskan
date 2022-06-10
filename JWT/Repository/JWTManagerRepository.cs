using JWT.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace JWT.Repository
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        
        private readonly IConfiguration iconfiguration;
        private readonly SqlConnection _connection;
        private SqlDataAdapter _adapter;
        private DataTable _dataTable = new DataTable();

        public JWTManagerRepository(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
            _connection = new SqlConnection("Server=EFCYIT-LTR91;Database=eModalProject;Trusted_Connection=True;MultipleActiveResultSets=true;");
            _connection.Open();

        }
        public List<Users> GetAllUsers()
        {
            List<Users> users = new List<Users>();
            _adapter = new SqlDataAdapter("select * from Users",_connection);
            _adapter.Fill(_dataTable);
            _connection.Close();
            foreach(DataRow row in _dataTable.Rows)
            {
                users.Add(new Users
                {
                    Username = Convert.ToString(row["username"]),
                    Password = Convert.ToString(row["password"])
                });
            }
            return users;

        }
        public Tokens Authenticate(Users users)
        {
            if (!GetAllUsers().Any(x => x.Username == users.Username && x.Password == users.Password))
            {
                return null;
            }



            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Name, users.Username)
            }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };



        }
    }
}
