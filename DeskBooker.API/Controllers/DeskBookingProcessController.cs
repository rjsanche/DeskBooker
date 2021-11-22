using DeskBooker.Core.DeskBooker.Application;
using DeskBooker.Core.DeskBooker.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeskBooker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeskBookingProcessController : ControllerBase
    {
        private IDeskBookingRequestProcessor _deskBookingRequestProcessor;

        public DeskBookingProcessController(IDeskBookingRequestProcessor deskBookingRequestProcessor)
        {
            _deskBookingRequestProcessor = deskBookingRequestProcessor;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] DeskBookingRequest request)
        {
            if (ModelState.IsValid)
            {
                _deskBookingRequestProcessor.BookDesk(request);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
