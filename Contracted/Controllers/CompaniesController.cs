using System;
using System.Collections.Generic;
using Contracted.Models;
using Contracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contracted.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {

        private readonly CompaniesService _cs;

        public CompaniesController(CompaniesService cs)
        {
            _cs = cs;
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

        [HttpPost]
        // [Authorize]

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
        // [Authorize]

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
        // [Authorize] Grab brear token later
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