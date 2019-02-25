using DluznicyAPI.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DluznicyAPI.DTO.ViewModels
{
    public class PersonShowSingle
    {
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

        public int MoneyNeeded { get; set; }
        public bool NeedToBorrow
        {
            get
            {
                return (MoneyNeeded > 0);
            }
        }
    }
}
