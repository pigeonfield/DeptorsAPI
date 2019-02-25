using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Numerics;

namespace DluznicyAPI.DAL.DAO
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public MailAddress Email { get; set; }
        public int PhoneNumber { get; set; }
        public Address Address { get; set; }
        public bool IsEmployed { get; set; }
        public Company Company { get; set; }
        
        public RulesFilter rules { get; set; }

        public int MoneyToLend { get; set; }
        public bool WantToLend
        {
            get
            {
                return (MoneyToLend > 0);
            }
        }

        public int MoneyToBorrow { get; set; }
        public bool WantToBorrow
        {
            get
            {
                return (MoneyToBorrow> 0);
            }
        }

        //public int MoneyToLend { get; set; }
        //public bool WantToLend { get; set; }


        //public int MoneyToBorrow { get; set; }
        //public bool WantToBorrow { get; set; }

    }
}
