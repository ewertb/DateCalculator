using System;
using DateCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateCalculatorTests
{
    [TestClass]
    public class DateCalculatorTests
    {
        [TestMethod]
        public void HasCorrectPreviousWorkingdayDateZaEaster()
        {
            DateCalculator.DateCalculator dateCalculator = new DateCalculator.DateCalculator();

            string countryCode = "za";
            DateTime currentDate = new DateTime(2018, 4, 3);
            
            DateTime workingday = dateCalculator.GetPreviousWorkday(countryCode, currentDate);

            Assert.AreEqual(new DateTime(2018, 3, 29), workingday);
        }

        [TestMethod]
        public void HasCorrectPreviousWorkingdayDateEgMonday()
        {
            DateCalculator.DateCalculator dateCalculator = new DateCalculator.DateCalculator();

            string countryCode = "eg";
            DateTime currentDate = new DateTime(2018, 5, 14);

            DateTime workingday = dateCalculator.GetPreviousWorkday(countryCode, currentDate);

            Assert.AreEqual(new DateTime(2018, 5, 12), workingday);
        }

        [TestMethod]
        public void HasCorrectNextWorkingdayDateEgFriday()
        {
            DateCalculator.DateCalculator dateCalculator = new DateCalculator.DateCalculator();

            string countryCode = "eg";
            DateTime currentDate = new DateTime(2018, 5, 11);

            DateTime workingday = dateCalculator.GetNextWorkday(countryCode, currentDate);

            Assert.AreEqual(new DateTime(2018, 5, 12), workingday);
        }

        [TestMethod]
        public void HasCorrectNextWorkingdayDateZaFriday()
        {
            DateCalculator.DateCalculator dateCalculator = new DateCalculator.DateCalculator();

            string countryCode = "za";
            DateTime currentDate = new DateTime(2018, 5, 11);

            DateTime workingday = dateCalculator.GetNextWorkday(countryCode, currentDate);

            Assert.AreEqual(new DateTime(2018, 5, 14), workingday);
        }

        [TestMethod]
        public void HasCorrectNextWorkingdayDateZaEaster()
        {
            DateCalculator.DateCalculator dateCalculator = new DateCalculator.DateCalculator();

            string countryCode = "za";
            DateTime currentDate = new DateTime(2018, 3, 29);

            DateTime workingday = dateCalculator.GetNextWorkday(countryCode, currentDate);

            Assert.AreEqual(new DateTime(2018, 4, 3), workingday);
        }

        [TestMethod]
        public void HasCorrectPreviousWorkingdayDateCustom()
        {
            DateCalculator.DateCalculator dateCalculator = new DateCalculator.DateCalculator();
            dateCalculator.workdayCalculators.Add("in", (date) => { return new InWorkdayCalculator(date); });

            string countryCode = "in";
            DateTime currentDate = new DateTime(2018, 5, 14);

            DateTime workingday = dateCalculator.GetPreviousWorkday(countryCode, currentDate);

            Assert.AreEqual(new DateTime(2018, 5, 12), workingday);
        }
    }

    class InWorkdayCalculator : CountryWorkdayCalculator
    {
        public InWorkdayCalculator(DateTime date)
            : base("in", date)
        { }

        protected override bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}
