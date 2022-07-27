using System.Collections.Generic;
using System.Data;
using System.Linq;
using Contracted.Models;
using Dapper;

namespace Contracted.Repositories
{
    public class JobsRepository
    {

        private readonly IDbConnection _db;

        public JobsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<ContractorCompanyViewModel> GetByCompanyId(int id)
        {
            string sql = @"
            c.*,
            j.id AS JobId
            FROM jobs j
            JOIN contractors c on c.id = j.contractorId
            WHERE j.companyId = @Id
            ";
            return _db.Query<ContractorCompanyViewModel>(sql, new { id }).ToList();
        }
    }
}