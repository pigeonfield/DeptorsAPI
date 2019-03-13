using DluznicyAPI.DAL.DAO;
using DluznicyAPI.DTO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluznicyAPI.DAL.Converters
{
    public static class PersonConverter
    {
        public static Person ConvertPersonWhenCreate(this PersonCreate person)
        {
            return new Person
            {
                UserName = person.UserName,
                Name = person.Name,
                Surname = person.Surname,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber,
                Details = new PersonalDetails(),
                Address = person.Address,
                IsEmployed = person.IsEmployed,
                Company = person.Company,
                MoneyToLend = person.MoneyToLend,
                MoneyToBorrow = person.MoneyToBorrow,
                WaitingTime = person.WaitingTime,
                LendOnlyToEmployed = person.LendOnlyToEmployed,
                RequiresAddress = person.RequiresAddress,
                MaxAmountOfMoney = person.MaxAmountOfMoney
            };
        }

        public static PersonShowSingle ConvertPersonToShowSingle(this Person person)
        {
            return new PersonShowSingle
            {
                UserName = person.UserName,
                Name = person.Name,
                Surname = person.Surname,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber,
                AddressIsGiven = (!(person.Address == null)),
                IsEmployed = person.IsEmployed,
                CompanyIsGiven = (!(person.Company == null)),

                MoneyToLend = person.MoneyToLend,
                WantToLend = (person.MoneyToLend > 0),
                MoneyToBorrow = person.MoneyToBorrow,
                WantToBorrow = (person.MoneyToBorrow > 0),

                WaitingTime = person.WaitingTime,
                LendOnlyToEmployed = person.LendOnlyToEmployed,
                RequiresAddress = person.RequiresAddress,
                MaxAmountOfMoney = person.MaxAmountOfMoney
            };
        }

        public static PersonShowAll ConvertPersonToShowAll(this Person person)
        {
            return new PersonShowAll
            {
                Name = person.Name,
                Surname = person.Surname,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber,

                WantToLend = ((person.MoneyToLend) > 0),
                WantToBorrow = ((person.MoneyToBorrow) > 0)
            };
        }


    }
}

