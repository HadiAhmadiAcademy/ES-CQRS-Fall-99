using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;
using LoanApplications.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LoanApplications.RestApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanApplicationsController : ControllerBase
    {
        private ICommandBus _bus;

        public LoanApplicationsController(ICommandBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PlaceLoanApplicationCommand command)
        {
            await _bus.Dispatch(command);
            return Ok();
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(Guid id, RejectApplicationCommand command)
        //{
        //    await _bus.Dispatch(command);
        //    return Ok();
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, AcceptApplicationCommand command)
        {
            await _bus.Dispatch(command);
            return Ok();
        }
    }
}
