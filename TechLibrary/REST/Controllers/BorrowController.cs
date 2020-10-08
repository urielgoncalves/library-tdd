using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechLibrary.REST.Payloads;

namespace TechLibrary.Controllers.REST
{
    [ApiController]
    [Route("[controller]")]
    public class BorrowController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(BorrowBookPayload request)
        {
            return Ok(request);
        }
    }
}
