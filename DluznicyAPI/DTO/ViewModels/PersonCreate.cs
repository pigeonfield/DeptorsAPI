using DluznicyAPI.DAL.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DluznicyAPI.DTO.ViewModels
{
    public class PersonCreate
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string UserName { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required]
        [Phone] //add regex later
        public string PhoneNumber { get; set; }
        public PersonalDetails Details { get; set; }
        public virtual Address Address { get; set; }
        [Required]
        public bool IsEmployed { get; set; }
        public virtual Company Company { get; set; }

        public int MoneyToLend { get; set; }
        public int MoneyToBorrow { get; set; }

        public int WaitingTime { get; set; }
        public bool LendOnlyToEmployed { get; set; }
        public bool RequiresAddress { get; set; }
        public int MaxAmountOfMoney { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
