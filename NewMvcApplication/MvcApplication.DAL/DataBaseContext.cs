using NewMvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApplication.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
            : base("DBConnection")
        {

        }

        public DbSet<Person> Persons { get; set; }
    }
}
