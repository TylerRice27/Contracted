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
    }
}