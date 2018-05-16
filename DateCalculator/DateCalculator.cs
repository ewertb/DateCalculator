using System;
using System.Collections.Generic;
using System.Text;

namespace DateCalculator
{
    public class DateCalculator
    {
        public Dictionary<string, Func<DateTime, CountryWorkdayCalculator>> workdayCalculators = new Dictionary<string, Func<DateTime, CountryWorkdayCalculator>>
        {
            { "za", (date) => { return new ZaWorkdayCalculator(date); } },
            { "eg", (date) => { return new EgWorkdayCalculator(date); } }
        };

        public DateTime GetPreviousWorkday(string countryCode, DateTime date)
        {
            if (this.workdayCalculators.ContainsKey(countryCode))
            {
                CountryWorkdayCalculator workingCalculator = this.workdayCalculators[countryCode](date);

                do
                {
                    date = date.AddDays(-1.0);
                }
                while (!workingCalculator.IsWorkday(date));
            }

            return date;
            
        }

        public DateTime GetNextWorkday(string countryCode, DateTime date)
        {
            if (this.workdayCalculators.ContainsKey(countryCode))
            {
                CountryWorkdayCalculator workingCalculator = this.workdayCalculators[countryCode](date);

                do
                {
                    date = date.AddDays(1.0);
                }
                while (!workingCalculator.IsWorkday(date));
            }

            return date;

        }
    }
}
