using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace LoanApplications.RestApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanApplicationsQueryController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Response from get all");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            return Ok("Response from get by id");
        }
    }
}
