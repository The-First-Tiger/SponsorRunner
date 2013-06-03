namespace SponsorRunner
{
    using System.Linq;
    using System.Windows;
    using SponsorRunner.Model;

    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        private readonly PersonContext context;

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

            context = new PersonContext();
 
            this.Runner = context.Persons.FirstOrDefault(person => person.Id == 1);            
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }

        private void AddNewSponsor(object sender, RoutedEventArgs e)
        {
            var addPersonView = new AddPersonView();
            addPersonView.ShowDialog();

            if (addPersonView.DialogResult.HasValue && addPersonView.DialogResult.Value)
            {
                context.Persons.Add(addPersonView.Person);
                this.Runner.Sponsors.Add(new RunnerSponsor
                                         {
                                             Betrag = 0,
                                             Runner = this.Runner,
                                             Sponsor = addPersonView.Person
                                         });
            }
        }
    }
}
