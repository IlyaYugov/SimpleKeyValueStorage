using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KeyValueStorageAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorageController : ControllerBase
    {
        private readonly KeyValueDomain _domain;

        public StorageController(KeyValueDomain domain)
        {
            _domain = domain;
        }

        [HttpPut]
        public IActionResult SetValue(KeyValueInputModel input)
        {
            _domain.SetValue(input.Key, input.Value);

            return NoContent();
        }

        [HttpGet("GetValue")]
        public ActionResult<ValueModel> GetValue([FromQuery]KeyModel key)
        {
            return _domain.GetValue(key);
        }

        [HttpDelete]
        public IActionResult RemoveValue(KeyModel key)
        {
            bool res = _domain.RemoveValue(key);

            if (!res)
                BadRequest();
            
            return NoContent();
        }

        [HttpGet("GetAllNotEmptyKeys")]
        public ActionResult<List<KeyModel>>  GetAllNotEmptyKeys()
        {
            var result = _domain.GetAllNotEmptyKeys().ToList();
            return result;
        }
    }
}