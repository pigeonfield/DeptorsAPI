using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DluznicyAPI.DAL.DAO
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string Name { get; set; }

        public virtual Address Address { get; set; }
    }
}