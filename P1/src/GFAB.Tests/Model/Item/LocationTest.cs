using System;
using Xunit;
using GFAB.Model;

namespace GFAB.Tests
{

    public class LocationTest
    {
        /// <summary>
        /// Test that guarantees that an exception is thrown when the system tries to create a location with a null name
        /// </summary>
        [Fact]
        public void NullNameThrowsArgumentException()
        {
            try
            {
                Location.ValueOf(null);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
                Assert.True(e is ArgumentException);
                Assert.Equal("name cannot be empty", e.Message);
            }

        }

        /// <summary>
        /// Test that guarantees that an exception is thrown whenever the system tries to create a location with an empty string
        /// </summary>
        [Fact]
        public void EmptyNameThrowsArgumentException()
        {
            try
            {
                Location.ValueOf(String.Empty);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
                Assert.True(e is ArgumentException);
                Assert.Equal("name cannot be empty", e.Message);
            }
        }

        /// <summary>
        /// Test that guarantees that an exception is thrown whenever the system tries to create a location with a name with lenght lower than 3
        /// </summary>
        [Fact]
        public void NameLessThan3CharsThrowsException()
        {
            try
            {
                Location.ValueOf("pa");
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
                Assert.True(e is ArgumentException);
                Assert.Equal("name must have more than 3 characters", e.Message);
            }
        }

        /// <summary>
        /// Test that guarantees that the location value object is created with success 
        /// </summary>
        [Fact]
        public void LocationIsCreatedSuccessfully()
        {
            string expected = "cantina";
            try
            {
                Location location = Location.ValueOf("cantina");
                //expected to proceed because exception will not be thrown
                Assert.NotNull(location);
                Assert.Equal(expected, location.Name);
            }
            catch (Exception e)
            {
                Assert.Null(e); //passes if exception was thrown
            }
        }
    }
}