using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Numerics;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DluznicyAPI.DAL.DAO
{
    public class Person: IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BornAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public int PersonalDetailsId { get; set; }
        public PersonalDetails Details { get; set; }

        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }
        public bool IsEmployed { get; set; }
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public int MoneyToLend { get; set; }
        public int MoneyToBorrow { get; set; }

        public int WaitingTime { get; set; }
        public bool LendOnlyToEmployed { get; set; }
        public bool RequiresAddress { get; set; }
        public int MaxAmountOfMoney { get; set; }

    }

}
