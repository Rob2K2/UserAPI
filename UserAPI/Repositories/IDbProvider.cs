using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Repositories
{
    public interface IDbProvider
    {
        IDbConnection Connection { get; }
    }
}
