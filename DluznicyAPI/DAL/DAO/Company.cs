using System.ComponentModel.DataAnnotations;

namespace DluznicyAPI.DAL.DAO
{
    public class Company
    {
        [Key]
        public string Name { get; set; }

        public Address Address { get; set; }
    }
}