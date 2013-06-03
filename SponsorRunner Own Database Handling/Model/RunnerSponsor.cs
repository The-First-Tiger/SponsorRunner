namespace SponsorRunner_Own_Database_Handling.Model
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using SponsorRunner_Own_Database_Handling.Annotations;

    public class RunnerSponsor : INotifyPropertyChanged
    {
        private int runnerId;

        private int sponsorId;

        private Person runner;

        private Person sponsor;

        private int betrag;

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

        public int RunnerId
        {
            get
            {
                return this.runnerId;
            }
            set
            {
                if (value == this.runnerId)
                {
                    return;
                }
                this.runnerId = value;
                this.OnPropertyChanged();
            }
        }

        public int SponsorId
        {
            get
            {
                return this.sponsorId;
            }
            set
            {
                if (value == this.sponsorId)
                {
                    return;
                }
                this.sponsorId = value;
                this.OnPropertyChanged();
            }
        }

        public Person Runner
        {
            get
            {
                return this.runner;
            }
            set
            {
                if (Equals(value, this.runner))
                {
                    return;
                }
                this.runner = value;
                this.OnPropertyChanged();
            }
        }

        public Person Sponsor
        {
            get
            {
                return this.sponsor;
            }
            set
            {
                if (Equals(value, this.sponsor))
                {
                    return;
                }
                this.sponsor = value;
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
