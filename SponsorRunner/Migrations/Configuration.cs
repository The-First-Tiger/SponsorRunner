namespace SponsorRunner.Migrations
{
    using System.Data.Entity.Migrations;

    using SponsorRunner.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<PersonContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PersonContext context)
        {
            context.Persons.AddOrUpdate(
                person => person.Id,
                new Person
                {
                    Vorname = "Max",
                    Nachname = "Mustermann",
                    Ort = "Musterstadt",
                    Plz = "12345",
                    Strasse = "Musterstrasse"
                });
        }       
    }
}
