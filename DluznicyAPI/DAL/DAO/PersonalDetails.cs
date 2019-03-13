using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluznicyAPI.DAL.DAO
{
    public class PersonalDetails
    {
        public int PersonalDetailsId { get; set; }
        public string DarkSecrets { get; set; }
        
        public string PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
