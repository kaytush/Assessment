using Assessment.Models;
using Assessment.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assessment.Controllers
{
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        // POST api/Person
        [HttpPost]
        public async Task<IActionResult> PersonAsync([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            await _personService.AddAsync(person);
            return Ok("Employee Added Successfully");
        }

        // GET api/Person
        [HttpGet()]
        public Task<IEnumerable<Person>> GetEmployeessAsync() => _personService.GetAllAsync();

        // GET api/Person/id
        [HttpGet("{Id}", Name = nameof(GetEmployeeByIdAsync))]
        public async Task<IActionResult> GetEmployeeByIdAsync(Guid Id)
        {
            Person person = await _personService.FindAsync(Id);
            if (person == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(person);
            }
        }
        // DELETE api/Person/1
        [HttpDelete("{Id}")]
        public async Task DeleteAsync(Guid Id) =>
            await _personService.RemoveAsync(Id);

        // PUT api/Person/Guid
        [HttpPut("{Id}")]
        public async Task<IActionResult> EmployeeAsync(Guid Id, [FromBody] Person person)
        {
            if (person == null || Id != person.Id)
            {
                return BadRequest();
            }
            if (await _personService.FindAsync(Id) == null)
            {
                return NotFound();
            }
            await _personService.UpdateAsync(person);
            //return new NoContentResult();
            return Ok("Person Updated Successfully");
        }
    }
}
