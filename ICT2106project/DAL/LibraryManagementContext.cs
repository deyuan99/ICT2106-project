using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ICT2106project.Models;

namespace ICT2106project.DAL
{
    public class LibraryManagementContext : DbContext
    {
        public LibraryManagementContext() : base("LibraryManagementDB")
        {

        }
        public DbSet<Book> Book { get; set; }
        public DbSet<Loan> Loan { get; set; }
    }
}