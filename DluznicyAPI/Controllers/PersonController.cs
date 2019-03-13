using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using DluznicyAPI.DAL.Converters;
using DluznicyAPI.DAL.DAO;
using DluznicyAPI.DAL.Repositories;
using DluznicyAPI.DTO.ViewModels;
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



        [HttpGet("{personId?}")]
        public async Task<IActionResult> ShowPerson(string personId)
        {
            if (personId == null)
            {
                var persons = await _personRepository.GetAllPersons();
                var personsConverted = persons.Select(p => p.ConvertPersonToShowAll()).ToList();
                return Ok(personsConverted);
            }
            else
            {
                var person = await _personRepository.GetPerson(personId);
                if (person == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(person.ConvertPersonToShowSingle());
                }
            }

        }

        [HttpPost("register")]
        public async Task<IActionResult> AddPerson([FromBody]PersonCreate person)
        {
            if (ModelState.IsValid)
            {
                Person personConverted = person.ConvertPersonWhenCreate();
                await _personRepository.AddPerson(personConverted,  person.Password);

                return Ok(personConverted);
            }
            else
            {
                return BadRequest();
            }
        }

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