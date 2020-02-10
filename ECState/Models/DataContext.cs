using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ECState.Models
{

    public class DataContext : DbContext
    {
        public DataContext() : base("Connect")
        { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> cities { get; set; }
    }
}