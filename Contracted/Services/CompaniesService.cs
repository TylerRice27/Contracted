using System.Collections.Generic;
using Contracted.Models;
using Contracted.Repositories;

namespace Contracted.Services
{
    public class CompaniesService
    {

        private readonly CompaniesRepository _repo;

        public CompaniesService(CompaniesRepository repo)
        {
            _repo = repo;
        }

        internal List<Company> Get()
        {
            return _repo.Get();
        }

        internal Company Create(Company company)
        {
            Company newCompany = _repo.Create(company);
            return newCompany;
        }
    }
}