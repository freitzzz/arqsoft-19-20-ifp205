using System;
using Xunit;
using GFAB.Model;

namespace GFAB.Tests.Model
{
    public class TimePeriodTest
    {
        private static readonly DateTime NOW = DateTime.Now; //CONSTANT
        /// <summary>
        /// Unit test to guarantee that user can´t choose a startDateTime which is after the endDateTime
        /// because is logically impossible
        /// </summary>
        [Fact]
        public void GrantStartDateTimeIsBeforeEndDateTimeTest1()
        {
            DateTime endDateTime = new DateTime(1996, 6, 3, 22, 15, 0);
            DateTime startDateTime = NOW;
            try
            {
                TimePeriod.ValueOf(startDateTime, endDateTime);
            }
            catch (ArgumentException e)
            {
                Assert.NotNull(e);
                Assert.Equal(e.Message, "startDateTime can´t be after endDateTime");
            }
        }

        /// <summary>
        /// Unit test that guarantees the success of the creation of a value object of type TimePeriod 
        /// </summary>
        [Fact]
        public void GrantStartDateTimeIsBeforeEndDateTimeTest2()
        {
            DateTime endDateTime = NOW;
            DateTime startDateTime = new DateTime(1996, 6, 3, 22, 15, 0);

            // startDateTime is before endDateTime which is now logically possible
            TimePeriod period = null; //reference to TimePeriod value object 

            try
            {
                period = TimePeriod.ValueOf(startDateTime, endDateTime);

            }
            catch (Exception e)
            {
                Assert.Null(e); //which means no exception was thrown
            }

            Assert.NotNull(period);
            Assert.Equal(startDateTime, period.StartDateTime);
            Assert.Equal(endDateTime, period.EndDateTime);
        }
    }
}
