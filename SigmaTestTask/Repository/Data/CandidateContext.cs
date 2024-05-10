using Microsoft.EntityFrameworkCore;
using SigmaTestTask.Domain;
using System.Reflection;

namespace SigmaTestTask.Repository.Data
{
    public class CandidateContext :DbContext
    {
        public CandidateContext(DbContextOptions<CandidateContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // apply fluent api configuration file at Repository/Data.Config

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
