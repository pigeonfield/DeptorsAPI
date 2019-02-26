using DluznicyAPI.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DluznicyAPI.DAL
{
    public static class DataInitializer
    {
        public static void Seed(this AppDbContext context)
        {
            if (!context.Persons.Any())
            {
                context.Persons.AddRange
                    (
                        new Person()
                        {
                            Name = "John",
                            Surname = "Brown",
                            Email = "johnbrown@mail.com", 
                            PhoneNumber = 123456789,
                            Address = new Address(),
                            IsEmployed = false,

                            MoneyToBorrow = 500, 
                            MoneyToLend = 0
                        },

                        new Person()
                        {
                            Name = "Anna",
                            Surname = "Smith",
                            Email = "annasmith@mail.com", 
                            PhoneNumber = 123456790,
                            Address = new Address(),
                            IsEmployed = true,
                            Company = new Company(),

                            MoneyToBorrow = 0,
                            MoneyToLend = 700,

                            WaitingTime = 60,
                            LendOnlyToEmployed = true,
                            MaxAmountOfMoney = 500

                        },

                        new Person()
                        {
                            Name = "John",
                            Surname = "Smith",
                            Email = "johnsmith@mail.com",
                            PhoneNumber = 123456776,
                            Address = new Address(),
                            IsEmployed = false,

                            MoneyToBorrow = 400,
                            MoneyToLend = 0
                        },

                        new Person()
                        {
                            Name = "Maria",
                            Surname = "Black",
                            Email = "mariablack@mail.com", 
                            PhoneNumber = 123457462,
                            Address = new Address(),
                            IsEmployed = false,
                            
                            MoneyToBorrow = 0,
                            MoneyToLend = 10000,

                            WaitingTime = 30,
                            LendOnlyToEmployed = true
                        }
                        
                    );

                 context.SaveChanges();
            }

            if (!context.Companies.Any())
            {
                context.Companies.AddRange
                    (
                        new Company()
                        {
                            Name = "ABC DE",
                            Address = new Address(),
                        },

                        new Company()
                        {
                            Name = "XXX BCD",
                            Address = new Address(),
                        },

                        new Company()
                        {
                            Name = "Company X",
                            Address = new Address(),
                        },

                        new Company()
                        {
                            Name = "X&Partners Agency",
                            Address = new Address(),
                        }

                    );

                context.SaveChanges();
            }

            if (!context.Addresses.Any())
            {
                context.Addresses.AddRange
                    (
                        new Address()
                        {
                            Street = "Strangers Lane",
                            HouseNum = 60,
                            PostCode = 12345,
                            City = "New York",
                            Country = "US"
                        },

                        new Address()
                        {
                            Street = "Strangers Lane",
                            HouseNum = 290,
                            PostCode = 12345,
                            City = "New York",
                            Country = "US"
                        },

                        new Address()
                        {
                            Street = "Unicorns",
                            HouseNum = 40,
                            PostCode = 60789,
                            City = "Radom",
                            Country = "PL"
                        },

                        new Address()
                        {
                            Street = "New Street",
                            HouseNum = 22,
                            PostCode = 50390,
                            City = "Toronto",
                            Country = "CA"
                        }

                    );

                context.SaveChanges();
            }
        }
    }
}

