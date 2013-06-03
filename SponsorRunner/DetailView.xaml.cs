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
                
            this.Runner = context.Persons.Include("Sponsors").FirstOrDefault(person => person.Id == 1);            
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }
    }
}
