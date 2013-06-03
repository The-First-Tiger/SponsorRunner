using System.Windows;

namespace SponsorRunner_Own_Database_Handling
{
    using SponsorRunner_Own_Database_Handling.Model;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var db = new Database();
            db.GetPerson(1);
        }
    }
}
