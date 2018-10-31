using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Gargoyles.Entities;
using Gargoyles.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace Gargoyles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GargoylesController : ControllerBase
    {
        private readonly GargoyleDatabase gargoyleDatabase;

        public GargoylesController(GargoyleDatabase gargoyleDatabase)
        {
            this.gargoyleDatabase = gargoyleDatabase;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<GargoyleEntity> Get(int id)
        {
            // not doing any index checking. Make sure you do.

            var entity = this.gargoyleDatabase.GargoyleEntities[id];

            Response.Headers["ETag"] = entity.ETag();

            return entity;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] GargoyleEntity entity)
        {
            // not doing any type checking here for the lecture. Make sure you use a ModelStateFilter

            this.gargoyleDatabase.GargoyleEntities.Add(entity);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]  GargoyleEntity entity)
        {
            
            if (Request.Headers.TryGetValue("If-Match", out StringValues ifMatchHeader))
            {
                var gargoyle = this.gargoyleDatabase.GargoyleEntities[id];
                if (ifMatchHeader == gargoyle.ETag())
                {
                    this.gargoyleDatabase.GargoyleEntities[id] = entity;
                    return StatusCode((int)HttpStatusCode.OK);
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed);
                }
            }
            else
            {
                return StatusCode((int) HttpStatusCode.PreconditionFailed);
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
