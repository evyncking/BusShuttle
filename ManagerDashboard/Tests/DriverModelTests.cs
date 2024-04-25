using Xunit;
using ManagerDashboard.Models;

namespace ManagerDashboard.Tests
{
    public class DriverModelTests
    {
        [Fact]
        public void CanCreateDriver()
        {
            
            var driver = new DriverModel { FirstName = "Evyn", LastName = "King", IsActive = true, Username = "evynking", Password = "shuttlebus" };

           
            Assert.Equal("Evyn", driver.FirstName);
            Assert.Equal("King", driver.LastName);
            Assert.True(driver.IsActive);
            Assert.Equal("evynking", driver.Username);
            Assert.Equal("shuttlebus", driver.Password);
        }

        [Fact]
        public void CanUpdateDriver()
        {
            var driver = new DriverModel { FirstName = "Evyn", LastName = "King", IsActive = true, Username = "evynking", Password = "shuttlebus" };

            driver.FirstName = "Evyn";
            driver.LastName = "King";
            driver.IsActive = false;
            driver.Username = "evynking";
            driver.Password = "busshuttle";

            Assert.Equal("Evyn", driver.FirstName);
            Assert.Equal("King", driver.LastName);
            Assert.False(driver.IsActive);
            Assert.Equal("evynking", driver.Username);
            Assert.Equal("busshuttle", driver.Password);
        }

        [Fact]
        public void CanDeleteDriver()
        {
            var driver = new DriverModel { FirstName = "John", LastName = "Doe", IsActive = true, Username = "johndoe", Password = "password" };

            _dbContext.Drivers.Remove(driver);


            Assert.DoesNotContain(driver, _dbContext.Drivers);
        }
        
    }
}