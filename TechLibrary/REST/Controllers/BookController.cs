using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TechLibrary.Controllers.REST
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private static readonly string[] Books = new[]
        {
            "Book 1", "Book 2", "Book 3", "Book 3", "Book 4", "Book 5", "Book 6", "Book 7", "Book 8", "Book 9"
        };

        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Books;
        }
    }
}
