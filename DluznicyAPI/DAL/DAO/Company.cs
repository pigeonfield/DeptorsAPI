using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DluznicyAPI.DAL.DAO
{
    public class Company
    {
        
        public int CompanyId { get; set; }
        public string Name { get; set; }

        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}