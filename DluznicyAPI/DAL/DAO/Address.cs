using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DluznicyAPI.DAL.DAO
{
    public class Address
    {

        public int AddressId { get; set; }
        public string Street { get; set; }
        public int HouseNum { get; set; }
        public int PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public ICollection<Person> Persons { get; set; }
        public ICollection<Company> Companies { get; set; }
    }
}