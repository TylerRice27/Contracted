using System.Collections.Generic;
using System.Data;
using System.Linq;
using Contracted.Models;
using Dapper;

namespace Contracted.Repositories
{
    public class CompaniesRepository
    {

        private readonly IDbConnection _db;

        public CompaniesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Company> Get()
        {
            string sql = "SELECT * FROM companies";
            return _db.Query<Company>(sql).ToList();
        }
    }
}