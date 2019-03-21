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
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double ActiveSince { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public bool AddressIsGiven { get; set; }        
        public bool IsEmployed { get; set; }
        public bool CompanyIsGiven { get; set; }
                
        public int MoneyToLend { get; set; }
        public bool WantToLend { get; set; }

        public int MoneyToBorrow { get; set; }
        public bool WantToBorrow { get; set; }

        public int WaitingTime { get; set; }
        public bool LendOnlyToEmployed { get; set; }
        public bool RequiresAddress { get; set; }
        public int MaxAmountOfMoney { get; set; }

    }
}
