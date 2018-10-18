using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KuscoServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace KuscoServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly QueueService queueService;

        public ValuesController(QueueService queueService)
        {
            this.queueService = queueService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{message}")]
        public async Task<ActionResult> GetAsync(string message)
        {
            await this.queueService.QueueMessagesAsync(message);

            return new StatusCodeResult((int) HttpStatusCode.Accepted);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
