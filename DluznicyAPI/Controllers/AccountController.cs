using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DluznicyAPI.DAL.DAO;
using DluznicyAPI.DAL.Repositories;
using DluznicyAPI.DTO.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DluznicyAPI.Controllers
{
    [Route("api/persons")]
    public class AccountController : Controller
    {
        private readonly IPersonRepository _personRepository;
        private readonly UserManager<Person> _userManager;
        private readonly SignInManager<Person> _signinManager;

        public AccountController(IPersonRepository personRepository, SignInManager<Person> signinManager, UserManager<Person> userManager)
        {
            _personRepository = personRepository;
            _userManager = userManager;
            _signinManager = signinManager;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Dupa()
        {
            return Ok("cycki");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]PersonLogin person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByNameAsync(person.UserName);

            if (user != null)
            {
                var result = await _signinManager.PasswordSignInAsync(user, person.Password, false, false);

                if (result.Succeeded)
                {
                    return Ok(result);
                }
            }

            return null;       
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return Ok();

        }


    }
}