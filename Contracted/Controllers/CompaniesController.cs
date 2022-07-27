using System;
using System.Collections.Generic;
using Contracted.Models;
using Contracted.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contracted.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {

        private readonly CompaniesService _cs;

        private readonly JobsService _js;

        public CompaniesController(CompaniesService cs, JobsService js)
        {
            _cs = cs;
            _js = js;
        }

        [HttpGet]
        public ActionResult<List<Company>> Get()
        {

            try
            {
                List<Company> companies = _cs.Get();
                return Ok(companies);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }

        [HttpGet("{id}")]

        public ActionResult<Company> Get(int id)
        {

            try
            {
                Company company = _cs.Get(id);
                return Ok(company);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        // Get all Contractors working for this company
        [HttpGet("{id}/contractors")]
        public ActionResult<List<Company>> GetContractors(int id)
        {
            try
            {
                List<ContractorCompanyViewModel> contractors = _js.GetByCompanyId(id);
                return Ok(contractors);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]

        public ActionResult<Company> Create([FromBody] Company company)
        {

            try
            {
                Company newCompany = _cs.Create(company);
                return Created($"/api/companies/{newCompany.Id}", newCompany);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        [HttpPut("{id}")]
        [Authorize]

        public ActionResult<Company> Edit([FromBody] Company company, int id)
        {
            try
            {
                company.Id = id;
                Company editCompany = _cs.Edit(company);
                return Ok(editCompany);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<Company> Delete(int id)
        {

            try
            {
                _cs.Delete(id);
                return Ok("Deleted Company");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

    }
}