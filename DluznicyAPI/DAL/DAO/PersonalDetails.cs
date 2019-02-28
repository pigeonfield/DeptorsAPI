using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluznicyAPI.DAL.DAO
{
    public class PersonalDetails
    {
        public string Details { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
