using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace LoanApplications.RestApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanApplicationsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post()
        {
            return Ok("Response from post");
        }

        [HttpPut("{id}/Status")]
        public IActionResult RejectOrConfirm(long id, string value)
        {
            return Ok("Response from put");
        }
    }
}
