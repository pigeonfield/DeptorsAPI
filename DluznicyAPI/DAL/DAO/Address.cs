using System.ComponentModel.DataAnnotations;

namespace DluznicyAPI.DAL.DAO
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string Street { get; set; }
        public int HouseNum { get; set; }
        public int PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }


    }
}