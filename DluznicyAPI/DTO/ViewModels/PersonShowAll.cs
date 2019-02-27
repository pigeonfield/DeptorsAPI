using DluznicyAPI.DAL.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DluznicyAPI.DTO.ViewModels
{
    public class PersonShowAll
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        public bool WantToLend { get; set; }
        public bool WantToBorrow { get; set; }

    }
}
