namespace SponsorRunner.Model
{
    using System.Data.Entity;
    using System.Windows.Documents;

    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RunnerSponsor>()
                .HasRequired(runnerSponsor => runnerSponsor.Sponsor)
                .WithMany()
                .HasForeignKey(sponsor => sponsor.SponsorId)
                .WillCascadeOnDelete(false);
        }
    }    
}
