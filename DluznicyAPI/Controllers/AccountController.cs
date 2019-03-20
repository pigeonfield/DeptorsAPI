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
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly IPersonRepository _personRepository;
        private readonly UserManager<Person> _userManager;
        private readonly SignInManager<Person> _signinManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(IPersonRepository personRepository, SignInManager<Person> signinManager, 
            UserManager<Person> userManager, RoleManager<IdentityRole> roleManager)
        {
            _personRepository = personRepository;
            _userManager = userManager;
            _signinManager = signinManager;
            _roleManager = roleManager;
        }

        [AllowAnonymous]
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
               
        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return Ok();
        }

        [Authorize(Roles="Administrator")]
        [HttpPost("setadmin/{personId}")]
        private async Task<IdentityResult> SetRoleToAdmin(string personId)
        {
            Person person = await _personRepository.GetPerson(personId);            
            return await _userManager.AddToRoleAsync(person, "Administrator");
        }

        [Authorize(Roles="Administrator")]
        [HttpPost("setsuperuser/{personId}")]
        public async Task<IdentityResult> SetRoleToSuperUser(string personId)
        {
            Person person = await _personRepository.GetPerson(personId);
            return await _userManager.AddToRoleAsync(person, "SuperUser");
        }

    }
}