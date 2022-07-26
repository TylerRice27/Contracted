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

        internal Company Get(int id)
        {
            Company foundCompany = _repo.Get(id);
            if (foundCompany == null)
            {
                throw new System.Exception("Invaild Id");
            }
            return foundCompany;


        }

        internal void Delete(int id)
        {
            Company foundCompany = Get(id);
            _repo.Delete(id);
        }
    }
}