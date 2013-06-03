namespace SponsorRunner_Own_Database_Handling.Model
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Windows.Documents;
    using System.Windows.Media;

    public class Database
    {
        private string ConnectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=\"C:\\Users\\Alexander\\Documents\\Visual Studio 2012\\Projects\\SponsorRunner\\SponsorRunner Own Database Handling\\SponsorRunnerOwnDatabase.mdf\";Integrated Security=True";

        public Person GetPerson(int personId)
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
            
            command = new SqlCommand(
                "SELECT sponsorid, betrag FROM runnersponsor WHERE runnerid =" + person.PersonId,
                connection);

            reader = command.ExecuteReader();

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
                command =
                    new SqlCommand(
                        "SELECT personid, vorname, nachname, strasse, plz, ort FROM person WHERE personid = "
                        + runnerSponsor.SponsorId,
                        connection);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    runnerSponsor.Sponsor = new Person
                                            {
                                                PersonId = Convert.ToInt32(reader[0]),
                                                Vorname = reader[1].ToString(),
                                                Nachname = reader[2].ToString(),
                                                Strasse = reader[3].ToString(),
                                                Plz = reader[4].ToString(),
                                                Ort = reader[5].ToString()
                                            };
                }

                reader.Close();
            }

            connection.Close();

            return person;
        }
    }
}
