using MvcApplication.Core.Data;
using NewMvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApplication.DAL.Repositories
{
    public class PersonRepository : IRepository<Person>
    {

        public List<Person> GetAll()
        {
            DataBaseContext db = new DataBaseContext();
            return (from p in db.Persons select p).ToList();
        }
    }
}
