using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Repositories
{
    public class DbProvider : IDbProvider
    {
        private readonly IConfiguration _config;

        public DbProvider(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Get or set the db connection of a microservice
        /// </summary>
        /// <value></value>
        public IDbConnection Connection
        {
            get { return new SqlConnection(_config.GetConnectionString("DapperConnectionString")); }
        }
    }
}
