using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis_Club
{
    abstract class Evenements
    {
        private DateTime date;

    public Evenements(DateTime date)
        {
            this.date = date;
        }

    public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }
    }
}
