using System.Collections.Generic;
using Contracted.Models;
using Contracted.Repositories;

namespace Contracted.Services
{
    public class ContractorService
    {

        private readonly ContractorRepository _repo;

        public ContractorService(ContractorRepository repo)
        {
            _repo = repo;
        }

        internal List<Contractor> Get()
        {
            return _repo.Get();
        }

        internal Contractor Get(int id)
        {

            Contractor foundContractor = _repo.Get(id);
            if (foundContractor == null)
            {
                throw new System.Exception("Invaild Id");
            }
            return foundContractor;


        }

        internal Contractor Create(Contractor contractor)
        {
            Contractor newContractor = _repo.Create(contractor);
            return newContractor;
        }

        internal Contractor Edit(Contractor contractor)
        {
            Contractor original = Get(contractor.Id);
            original.Name = contractor.Name ?? original.Name;

            _repo.Edit(original);
            return original;
        }

        internal void Delete(int id)
        {
            Contractor foundContractor = Get(id);
            _repo.Delete(id);

        }
    }
}