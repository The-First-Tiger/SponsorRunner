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
    using SponsorRunner_Databse_First.ViewModel;

    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        public static readonly DependencyProperty RunnerProperty = DependencyProperty.Register(
            "Runner",
            typeof(Runner),
            typeof(DetailWindow),
            new PropertyMetadata());

        public Runner Runner
        {
            get
            {
                return (Runner)this.GetValue(RunnerProperty);
            }
            set
            {
                this.SetValue(RunnerProperty, value);
            }
        }

        public DetailWindow()
        {
            InitializeComponent();

            var context = new PersonEntities();

            this.Runner = new Runner(context.Person.FirstOrDefault(person => person.PeronId == 1));
        }
    }
}
