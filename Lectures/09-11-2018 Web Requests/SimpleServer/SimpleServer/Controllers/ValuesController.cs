using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace SimpleServer.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private static List<ValueEntity> values = new List<ValueEntity>() { new ValueEntity() { Value = "steven" } };

        public class ValueEntity
        {
            public string Value { get; set; }
        }

        [HttpGet]
        public IEnumerable<ValueEntity> Get()
        {
            return values;
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(values[id]);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ValueEntity valueEntity)
        {
            values.Add(valueEntity);

            return new JsonResult(valueEntity);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put([FromBody] ValueEntity valueEntity, int id)
        {
            values[id] = valueEntity;

            return new JsonResult(valueEntity);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            values.RemoveAt(id);

            return new StatusCodeResult((int)HttpStatusCode.NoContent);
        }
    }
}
