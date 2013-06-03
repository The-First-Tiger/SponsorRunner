namespace SponsorRunner.Model
{
    using System.Data.Entity;

    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasMany(person => person.Sponsors).WithMany();
        }
    }    
}
