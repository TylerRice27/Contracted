using System.Collections.Generic;
using Contracted.Models;
using Contracted.Repositories;

namespace Contracted.Services
{
    public class JobsService
    {

        private readonly JobsRepository _repo;

        public JobsService(JobsRepository repo)
        {
            _repo = repo;
        }

        internal List<ContractorCompanyViewModel> GetByCompanyId(int id)
        {
            return _repo.GetByCompanyId(id);
        }
    }
}