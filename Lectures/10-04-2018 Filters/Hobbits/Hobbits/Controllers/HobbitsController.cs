using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Hobbits.Entities;
using Hobbits.Services;
using System.Net;
using Hobbits.Filters;

namespace Hobbits.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(RequestIdFilter))]
    [TypeFilter(typeof(ModelStateFilter))]
    public class HobbitsController : Controller
    {
        private LoggingService loggingService;

        private HobbitDatabase hobbits;

        private IRequestIdGenerator requestIdGenerator;

        public HobbitsController(LoggingService loggingService, HobbitDatabase hobbitDatabase, IRequestIdGenerator requestIdGenerator)
        {
            this.loggingService = loggingService;
            this.hobbits = hobbitDatabase;
            this.requestIdGenerator = requestIdGenerator;
        }

        [HttpGet]
        public IEnumerable<HobbitEntity> Get()
        {
            loggingService.Log("GET all hobbits");

            return hobbits.Get().Select(hm => hm.ToEntity());
        }

        [HttpGet("{id}")]
        public HobbitEntity Get(int id)
        {
            loggingService.Log($"GET one hobbit {id}");

            return hobbits.Get(id).ToEntity();
        }

        [HttpPost]
        public IActionResult Post([FromBody]HobbitEntity hobbit)
        {
            loggingService.Log("Created a new hobbit");

            if (!ModelState.IsValid)
            {
                return new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = "Check to ensure the structure of your JSON hobbit."
                };
            }

            if (hobbits.Add(hobbit.ToModel()))
            {
                return Json(hobbit);
            }
            else
            {
                return new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = "Could not add your hobbit"
                };
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]HobbitEntity hobbit)
        {
            loggingService.Log("Created a new hobbit");

            if (!ModelState.IsValid)
            {
                return new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = "Check to ensure the structure of your JSON hobbit."
                };
            }

            if (hobbits.Add(hobbit.ToModel(), id))
            {
                return Json(hobbit);
            }
            else
            {
                return new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = "Your hobbit index was invalid."
                };
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            loggingService.Log("Deleted a hobbit");

            hobbits.Delete(id);
        }
    }
}
