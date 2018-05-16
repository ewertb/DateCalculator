using System;

namespace DateCalculator
{
    public class EgWorkdayCalculator : CountryWorkdayCalculator
    {
        public EgWorkdayCalculator()
            : base("eg", DateTime.Now)
        { }

        public EgWorkdayCalculator(DateTime date)
            : base("eg", date)
        { }

        protected override bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}
