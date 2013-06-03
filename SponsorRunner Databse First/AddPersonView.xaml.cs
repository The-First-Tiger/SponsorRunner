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
using System.Windows.Shapes;

namespace SponsorRunner_Databse_First
{
    /// <summary>
    /// Interaction logic for AddPersonView.xaml
    /// </summary>
    public partial class AddPersonView : Window
    {
        public static readonly DependencyProperty PersonProperty = DependencyProperty.Register(
            "Person",
            typeof(Person),
            typeof(AddPersonView),
            new PropertyMetadata(default(Person)));

        public Person Person
        {
            get
            {
                return (Person)GetValue(PersonProperty);
            }
            set
            {
                SetValue(PersonProperty, value);
            }
        }

        public AddPersonView()
        {
            InitializeComponent();
            this.Person = new Person();
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
