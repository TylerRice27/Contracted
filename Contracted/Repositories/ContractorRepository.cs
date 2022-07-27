using System.Collections.Generic;
using System.Data;
using System.Linq;
using Contracted.Models;
using Dapper;

namespace Contracted.Repositories
{
    public class ContractorRepository
    {
        private readonly IDbConnection _db;

        public ContractorRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Contractor Get(int id)
        {
            string sql = "SELECT * FROM contractors WHERE id =@id";
            return _db.QueryFirstOrDefault<Contractor>(sql, new { id });
        }

        internal List<Contractor> Get()
        {
            string sql = "SELECT * FROM contractors";
            return _db.Query<Contractor>(sql).ToList();
        }

        internal Contractor Create(Contractor contractor)
        {
            string sql = @"
        INSERT INTO contractors
        (name)
        VALUES
        (@Name);
        SELECT LAST_INSERT_ID();";

            contractor.Id = _db.ExecuteScalar<int>(sql, contractor);
            return contractor;
        }

        internal void Edit(Contractor original)
        {
            string sql = @"
            UPDATE contractors
            SET
            name =@Name
            WHERE id = @Id;";
            _db.Execute(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM contractors WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });
        }
    }
}