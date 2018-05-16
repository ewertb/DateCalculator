using System;
using System.Collections.Generic;
using System.Linq;

namespace DateCalculator
{
    public abstract class CountryWorkdayCalculator
    {
        public DateTime Date { get; set; }
        public string CountryCode { get; set; }
        protected Dictionary<string, DateTime> Holidays { get; set; }

        public CountryWorkdayCalculator(string countryCode, DateTime date)
        {
            this.CountryCode = countryCode;
            this.Date = date;
            this.Holidays = new Dictionary<string, DateTime>();
            this.AddHolidays();
        }

        protected virtual void AddHolidays()
        {
            this.Holidays.Add("New Years Day", new DateTime(this.Date.Year, 1, 1));
        }

        public virtual bool IsWorkday(DateTime date)
        {
            return !IsWeekend(date) && !IsHoliday(date);
        }

        protected virtual bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        protected virtual bool IsHoliday(DateTime date)
        {
            return this.Holidays.Values.Any(holiday => holiday.Date == date.Date);
        }
    }
}
