﻿using DluznicyAPI.DAL.DAO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluznicyAPI.DAL.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<Person> _userManager;

        public PersonRepository(AppDbContext appDbContext, UserManager<Person> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }

        public Task<List<Person>> GetAllPersons()
        {
            return _userManager.Users.AsNoTracking().ToListAsync();
        }

        [Authorize] //user 
        public Task<Person> GetPerson(string personId)
        {
            return _userManager.Users.FirstOrDefaultAsync(p => p.Id == personId);
        }

        [Authorize] //admin
        public async Task AddPerson(Person person, string pswd)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }
            else
            {
                var identityResult = await _userManager.CreateAsync(person, pswd);
                if (!identityResult.Succeeded)
                {
                    if (identityResult.Errors.Any())
                    {
                        throw new InvalidOperationException(identityResult.Errors.First().Description);
                    }
                }
            }
        }

        [Authorize]  //admin
        public  async Task DeletePerson(string personId)
        {
            Person personToDelete = _userManager.Users.FirstOrDefault(p => p.Id == personId);

            if (personToDelete == null)
            {
                throw new ArgumentNullException(nameof(personToDelete));
            }

            if (personToDelete != null)
            {
                var identityResult = await _userManager.DeleteAsync(personToDelete);
                if (!identityResult.Succeeded)
                {
                    if (identityResult.Errors.Any())
                    {
                        throw new InvalidOperationException(identityResult.Errors.First().Description);
                    }
                }
            }
            
        }

    }
}
