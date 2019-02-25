using DluznicyAPI.DAL.DAO;
using DluznicyAPI.DTO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DluznicyAPI.DAL.Converters
{
    public static class PersonConverter
    {
        public static Person ConvertPersonWhenCreate(this PersonCreate person)
        {
            return new Person
            {

            };
        }

        public static PersonShowSingle ConvertPersonToShowSingle(this Person person)
        {
            return new PersonShowSingle
            {

            };
        }

        public static PersonShowAll ConvertPersonToShowAll(this Person person)
        {
            return new PersonShowAll
            {

            };
        }


    }
}
