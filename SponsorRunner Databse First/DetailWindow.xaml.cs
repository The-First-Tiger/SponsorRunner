using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SponsorRunner_Databse_First
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
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

        private PersonEntities context;

        public DetailWindow()
        {
            InitializeComponent();

            context = new PersonEntities();

            this.Runner = context.Person.FirstOrDefault(person => person.PeronId == 1);
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }

        private void AddNewSponsorButtonClick(object sender, RoutedEventArgs e)
        {
            var addPersonView = new AddPersonView();
            addPersonView.ShowDialog();

            if (addPersonView.DialogResult.HasValue && addPersonView.DialogResult.Value)
            {
                context.Person.Add(addPersonView.Person);
                this.Runner.RunnerSponsor.Add(new RunnerSponsor
                {
                    Betrag = 0,
                    Person = this.Runner,
                    Person1 = addPersonView.Person
                });
            }
        }
    }
}
