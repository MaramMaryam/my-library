using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MyCmsContext:DbContext
    {
        public DbSet<PageGroup> PageGroups { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageComment> PageComments { get; set; }
        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookLoan> BookLoan { get; set; }
        public DbSet<Return> Return { get; set; }
    }
}
