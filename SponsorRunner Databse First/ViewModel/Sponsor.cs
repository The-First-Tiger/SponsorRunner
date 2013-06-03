using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SponsorRunner_Databse_First.ViewModel
{
    public class Sponsor : Runner
    {
        private int betrag;

        public Sponsor(Person person)
            : base(person)
        {
        }

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
    }
}
