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
        [Key]
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public MailAddress Email { get; set; }
        public int PhoneNumber { get; set; }
        public Address Address { get; set; }
        public bool IsEmployed { get; set; }
        public Company Company { get; set; }

    }
}
