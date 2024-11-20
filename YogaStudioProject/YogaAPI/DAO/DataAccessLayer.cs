using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{

    public class DataAccessLayer
    {
        private readonly IConfiguration _cofiguration;
        private readonly string connectionstring;
        public DataAccessLayer(IConfiguration cofiguration){
            this._cofiguration = cofiguration;
            this.connectionstring = this._cofiguration.GetConnectionString("connection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(connectionstring);
    }
}
