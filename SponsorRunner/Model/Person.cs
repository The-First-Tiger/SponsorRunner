namespace SponsorRunner.Model
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    using SponsorRunner.Annotations;

    public class Person : INotifyPropertyChanged
    {
        private string vorname;

        private int id;

        private string nachname;

        private string strasse;

        private string plz;

        private string ort;

        private ObservableCollection<Person> sponsors;

        private int betrag;

        public Person()
        {
            Sponsors = new ObservableCollection<Person>();
        }

        [Key]        
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value == this.id)
                {
                    return;
                }
                this.id = value;
                this.OnPropertyChanged();
            }
        }

        [NotNull]
        public string Vorname
        {
            get
            {
                return this.vorname;
            }
            set
            {
                if (value == this.vorname)
                {
                    return;
                }
                this.vorname = value;
                this.OnPropertyChanged();
            }
        }

        [NotNull]
        public string Nachname
        {
            get
            {
                return this.nachname;
            }
            set
            {
                if (value == this.nachname)
                {
                    return;
                }
                this.nachname = value;
                this.OnPropertyChanged();
            }
        }

        [NotNull]
        public string Strasse
        {
            get
            {
                return this.strasse;
            }
            set
            {
                if (value == this.strasse)
                {
                    return;
                }
                this.strasse = value;
                this.OnPropertyChanged();
            }
        }

        [NotNull]
        public string Plz
        {
            get
            {
                return this.plz;
            }
            set
            {
                if (value == this.plz)
                {
                    return;
                }
                this.plz = value;
                this.OnPropertyChanged();
            }
        }

        [NotNull]
        public string Ort
        {
            get
            {
                return this.ort;
            }
            set
            {
                if (value == this.ort)
                {
                    return;
                }
                this.ort = value;
                this.OnPropertyChanged();
            }
        }

        [CanBeNull]
        public int Betrag
        {
            get
            {
                return this.betrag;
            }
            set
            {
                if (value == this.betrag)
                {
                    return;
                }
                this.betrag = value;
                this.OnPropertyChanged();
            }
        }

        [CanBeNull]
        public ObservableCollection<Person> Sponsors
        {
            get
            {
                return this.sponsors;
            }
            set
            {
                if (Equals(value, this.sponsors))
                {
                    return;
                }
                this.sponsors = value;
                this.OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
