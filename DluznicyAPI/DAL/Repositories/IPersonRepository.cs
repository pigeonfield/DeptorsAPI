using DluznicyAPI.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluznicyAPI.DAL.Repositories
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAllPersons();
        Task<Person> GetPerson(string personId);

        Task AddPerson(Person person, string pswd);

        Task DeletePerson(string personId);


    }
}
