namespace SponsorRunner_Own_Database_Handling.Model
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Windows.Documents;
    using System.Windows.Media;

    public class Database
    {
        private string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Alexander\SponsorRunnerOwnDbHandler.mdf;Integrated Security=True";

        private Person GetPersonWithoutSponsors(int personId)
        {
            var person = new Person();

            var connection = new SqlConnection(ConnectionString);

            connection.Open();

            var command =
                new SqlCommand(
                    "SELECT personid, vorname, nachname, strasse, plz, ort FROM person WHERE personid = " + personId,
                    connection);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                person.PersonId = Convert.ToInt32(reader[0]);
                person.Vorname = reader[1].ToString();
                person.Nachname = reader[2].ToString();
                person.Strasse = reader[3].ToString();
                person.Plz = reader[4].ToString();
                person.Ort = reader[5].ToString();
            }

            reader.Close();

            connection.Close();

            return person;
        }

        private void FillSponsors(Person person)
        {
            var connection = new SqlConnection(ConnectionString);

            connection.Open();

            var command = new SqlCommand(
                "SELECT sponsorid, betrag FROM runnersponsor WHERE runnerid =" + person.PersonId,
                connection);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                person.Sponsors.Add(new RunnerSponsor
                {
                    RunnerId = person.PersonId,
                    SponsorId = Convert.ToInt32(reader[0]),
                    Runner = person,
                    Betrag = Convert.ToInt32(reader[1])
                });
            }

            reader.Close();

            foreach (var runnerSponsor in person.Sponsors)
            {
                runnerSponsor.Sponsor = this.GetPersonWithoutSponsors(runnerSponsor.SponsorId);
            }
            
            connection.Close();
        }

        public Person GetPerson(int personId)
        {
            var person = this.GetPersonWithoutSponsors(personId);
            
            this.FillSponsors(person);
            
            return person;
        }

        public void SavePerson(Person person)
        {
            if (DoesPersonExists(person.PersonId))
            {
                this.UpdatePerson(person);
                return;
            }

            this.CreatePerson(person);
        }

        private void CreatePerson(Person person)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var command =
                    new SqlCommand(
                        string.Format(
                            "INSERT INTO person (vorname, nachname, strasse, plz, ort) OUTPUT INSERTED.IDENTITYCOL VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                            person.Vorname,
                            person.Nachname,
                            person.Strasse,
                            person.Plz,
                            person.Ort),
                        connection);

                person.PersonId = (int)command.ExecuteScalar();
                
                foreach (var runnerSponsor in person.Sponsors)
                {
                    if (this.DoesRunnerSponsorExists(runnerSponsor))
                    {
                        this.UpdateRunnerSponsor(runnerSponsor);
                    }
                    else
                    {
                        this.CreateRunnerSponsor(runnerSponsor);
                    }
                }
            }
        }

        private void UpdatePerson(Person person)
        {
            var connection = new SqlConnection(ConnectionString);

            connection.Open();

            var command =
                new SqlCommand(
                    string.Format(
                        "UPDATE person SET  vorname = '{0}', nachname = '{1}', strasse = '{2}', plz = '{3}', ort = '{4}' WHERE personid = {5}",
                        person.Vorname,
                        person.Nachname,
                        person.Strasse,
                        person.Plz,
                        person.Ort,
                        person.PersonId),
                    connection);

            command.ExecuteNonQuery();

            foreach (var runnerSponsor in person.Sponsors)
            {
                if (DoesRunnerSponsorExists(runnerSponsor))
                {
                    this.UpdateRunnerSponsor(runnerSponsor);
                }
                else
                {
                    if (!this.DoesPersonExists(runnerSponsor.SponsorId))
                    {
                        this.CreatePerson(runnerSponsor.Sponsor);
                    }

                    runnerSponsor.SponsorId = runnerSponsor.Sponsor.PersonId;

                    this.CreateRunnerSponsor(runnerSponsor);   
                }                
            }

            connection.Close();
        }

        private void CreateRunnerSponsor(RunnerSponsor runnerSponsor)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var command =
                    new SqlCommand(
                        string.Format(
                            "INSERT INTO runnersponsor (runnerid, sponsorid, betrag) VALUES ({0}, {1}, {2})",
                            runnerSponsor.RunnerId,
                            runnerSponsor.SponsorId,
                            runnerSponsor.Betrag),
                        connection);

                command.ExecuteNonQuery();
            }
        }

        private void UpdateRunnerSponsor(RunnerSponsor runnerSponsor)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var command =
                    new SqlCommand(
                        string.Format(
                            "UPDATE runnersponsor SET betrag = {0} where runnerid = {1} and sponsorid = {2}",
                            runnerSponsor.Betrag,
                            runnerSponsor.RunnerId,
                            runnerSponsor.SponsorId),
                        connection);

                command.ExecuteNonQuery();
            }
        }

        private bool DoesRunnerSponsorExists(RunnerSponsor runnerSponsor)
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var command =
                new SqlCommand(
                    string.Format(
                        "SELECT runnerid FROM runnersponsor WHERE runnerid = {0} AND sponsorid = {1}",
                        runnerSponsor.RunnerId,
                        runnerSponsor.SponsorId),
                    connection);

            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    connection.Close();
                    return true;
                }

                connection.Close();
                return false;
            }            
        }

        private bool DoesPersonExists(int personId)
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var command = new SqlCommand("SELECT personid FROM person WHERE personid =" + personId, connection);

            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Close();
                connection.Close();
                return true;
            }

            reader.Close();
            connection.Close();

            return false;
        }
    }
}
