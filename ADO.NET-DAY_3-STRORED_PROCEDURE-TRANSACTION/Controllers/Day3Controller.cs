using ADO.NET_DAY_3_STRORED_PROCEDURE_TRANSACTION.Model;
using ADO.NET_DAY_3_STRORED_PROCEDURE_TRANSACTION.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADO.NET_DAY_3_STRORED_PROCEDURE_TRANSACTION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Day3Controller : ControllerBase
    {
        public readonly IService _service;
        public Day3Controller(IService service)
        {
            _service = service;
        }
        [HttpGet("All")]
        public IActionResult GetAll()
        {
            return Ok(_service.allstd());
        }
        [HttpGet("ById")]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }
        [HttpPost]
        public IActionResult InsertStd(D3STD std)
        {
            return Ok(_service.InsertStd(std));
        }
        [HttpPut]
        public IActionResult UpdateStd(D3STD std)
        {
            return Ok(_service.UpdateStd(std));
        }
        [HttpDelete]
        public IActionResult DeleteStd(int id)
        {
            return Ok(_service.DeleteStd(id));
        }
    }
}
