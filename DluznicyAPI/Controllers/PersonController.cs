using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using DluznicyAPI.CustomExceptions;
using DluznicyAPI.DAL.Converters;
using DluznicyAPI.DAL.DAO;
using DluznicyAPI.DAL.Repositories;
using DluznicyAPI.DTO.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DluznicyAPI.Controllers
{
    [Route("api/persons")]
    public class PersonController : Controller

    {
        private readonly IPersonRepository _personRepository;
        private readonly UserManager<Person> _userManager;

        public PersonController(IPersonRepository personRepository, UserManager<Person> userManager)
        {
            _personRepository = personRepository;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet("{personId}")]
        public async Task<IActionResult> ShowPerson(string personId)
        {
            var person = await _personRepository.GetPerson(personId);
            if (person == null)
            {
                throw new PersonNotFoundException();
            }
            else
            {
                return Ok(person.ConvertPersonToShowSingle());
            }
        }

        [HttpGet]
        public async Task<IActionResult> ShowPersons()
        {
            var persons = await _personRepository.GetAllPersons();
            var personsConverted = persons.Select(p => p.ConvertPersonToShowAll()).ToList();
            return Ok(personsConverted);
        }
               
        [HttpPost("register")]
        public async Task<IActionResult> AddPerson([FromBody]PersonCreate person)
        {
            if (ModelState.IsValid)
            {
                Person personConverted = person.ConvertPersonWhenCreate();
                await _personRepository.AddPerson(personConverted, person.Password);

                return Ok(personConverted.ConvertPersonToShowSingle());
            }

            else
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{personId}")]
        public async Task<IActionResult> DeletePerson(string personId)
        {
            if (string.IsNullOrEmpty(personId))
            {
                return BadRequest();
            }
            else
            {
                await _personRepository.DeletePerson(personId);
                return Ok();
            }
        }

    }
}