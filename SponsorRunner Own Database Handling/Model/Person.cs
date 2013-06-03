namespace SponsorRunner_Own_Database_Handling.Model
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using SponsorRunner_Own_Database_Handling.Annotations;

    public class Person : INotifyPropertyChanged
    {
        private int personId;

        private string vorname;

        private string nachname;

        private string strasse;

        private string plz;

        private string ort;

        private ObservableCollection<RunnerSponsor> sponsors;

        public Person()
        {
            this.Sponsors = new ObservableCollection<RunnerSponsor>();
        }

        public int PersonId
        {
            get
            {
                return this.personId;
            }
            set
            {
                if (value == this.personId)
                {
                    return;
                }
                this.personId = value;
                this.OnPropertyChanged();
            }
        }

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

        public ObservableCollection<RunnerSponsor> Sponsors
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
