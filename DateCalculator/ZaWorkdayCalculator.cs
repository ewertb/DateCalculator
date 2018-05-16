using System;
using System.Linq;

namespace DateCalculator
{
    public class ZaWorkdayCalculator : CountryWorkdayCalculator
    {
        public ZaWorkdayCalculator()
            : base("za", DateTime.Now)
        { }

        public ZaWorkdayCalculator(DateTime date)
            : base("za", date)
        { }

        protected override void AddHolidays()
        {
            base.AddHolidays();
            this.Holidays.Add("Human Rights Day", new DateTime(this.Date.Year, 3, 21));
            this.Holidays.Add("Good Friday", new DateTime(this.Date.Year, 3, 30));
            this.Holidays.Add("Family Day", new DateTime(this.Date.Year, 4, 2));
        }
    }
}
