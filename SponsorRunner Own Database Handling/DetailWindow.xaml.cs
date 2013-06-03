using System.Windows;

namespace SponsorRunner_Own_Database_Handling
{
    using SponsorRunner_Own_Database_Handling.Model;

    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        private readonly Database database;

        public static readonly DependencyProperty RunnerProperty = DependencyProperty.Register(
            "Runner",
            typeof(Person),
            typeof(DetailWindow),
            new PropertyMetadata());

        public Person Runner
        {
            get
            {
                return (Person)this.GetValue(RunnerProperty);
            }
            set
            {
                this.SetValue(RunnerProperty, value);
            }
        }

        public DetailWindow()
        {
            InitializeComponent();

            database = new Database();

            this.Runner = database.GetPerson(1);
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            database.SavePerson(Runner);
        }

        private void AddNewSponsor(object sender, RoutedEventArgs e)
        {
            var addPersonView = new AddPersonView();
            addPersonView.ShowDialog();

            if (addPersonView.DialogResult.HasValue && addPersonView.DialogResult.Value)
            {
                this.Runner.Sponsors.Add(new RunnerSponsor
                                         {
                                             Betrag = 0,
                                             Runner = this.Runner,
                                             Sponsor = addPersonView.Person,
                                             RunnerId = this.Runner.PersonId,
                                             SponsorId = addPersonView.Person.PersonId
                                         });

                //context.Persons.Add(addPersonView.Person);
                //this.Runner.Sponsors.Add(new RunnerSponsor
                //{
                //    Betrag = 0,
                //    Runner = this.Runner,
                //    Sponsor = addPersonView.Person
                //});
            }
        }
    }
}
