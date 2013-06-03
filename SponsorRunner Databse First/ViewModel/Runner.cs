using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SponsorRunner_Databse_First.ViewModel
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using SponsorRunner_Databse_First.Annotations;

    public class Runner : INotifyPropertyChanged
    {
        public ObservableCollection<Sponsor> sponsors;

        protected Person person; 

        public Runner(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("Argument person cannot be null!");
            }

            this.person = person;
            this.sponsors = new ObservableCollection<Sponsor>();

            if (this is Sponsor)
            {
                return;
            }

            var query =
                    person.RunnerSponsor.Select(
                        sponsor =>
                            new Sponsor(sponsor.Person)
                            {
                                Betrag = sponsor.Betrag
                            });

            foreach (var sponsor in query)
            {                
                sponsors.Add(sponsor);
            }
        }

        public string Vorname
        {
            get
            {
                return this.person.vorname;
            }
            set
            {
                if (value == this.person.vorname)
                {
                    return;
                }
                this.person.vorname = value;
                this.OnPropertyChanged();
            }
        }

        public string Nachname
        {
            get
            {
                return this.person.nachname;
            }
            set
            {
                if (value == this.person.nachname)
                {
                    return;
                }
                this.person.nachname = value;
                this.OnPropertyChanged();
            }
        }

        public string Strasse
        {
            get
            {
                return this.person.strasse;
            }
            set
            {
                if (value == this.person.strasse)
                {
                    return;
                }
                this.person.strasse = value;
                this.OnPropertyChanged();
            }
        }

        public string Ort
        {
            get
            {
                return this.person.ort;
            }
            set
            {
                if (value == this.person.ort)
                {
                    return;
                }
                this.person.ort = value;
                this.OnPropertyChanged();
            }
        }

        public string Plz
        {
            get
            {
                return this.person.plz;
            }
            set
            {
                if (value == this.person.plz)
                {
                    return;
                }
                this.person.plz = value;
                this.OnPropertyChanged();
            }
        }

        public ObservableCollection<Sponsor> Sponsors
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
