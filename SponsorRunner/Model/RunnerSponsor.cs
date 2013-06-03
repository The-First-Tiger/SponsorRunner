namespace SponsorRunner.Model
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    using SponsorRunner.Annotations;

    public class RunnerSponsor : INotifyPropertyChanged
    {
        private int betrag;

        private int runnerId;

        private int sponsorId;

        private Person runner;

        private Person sponsor;

        public virtual int Betrag
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

        [Key]
        [Column(Order = 0)]
        public virtual int RunnerId
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

        [Key]
        [Column(Order = 1)]
        public virtual int SponsorId
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

        public virtual Person Runner
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

        public virtual Person Sponsor
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
