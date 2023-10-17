using NSubstitute;
using ppedv.CarRent8000.Model.Contracts;
using ppedv.CarRent8000.Model.DomainModel;

namespace ppedv.CarRent8000.Logic.Tests
{
    public class RentServiceTests
    {
        [Fact]
        public void IsCarAvailable_NoOverlappingRentals_ReturnsTrue()
        {
            // Arrange
            var repository = Substitute.For<IRepository>();
            var rentService = new RentService(repository);

            var car = new Car();
            var start = new DateTime(2023, 10, 1);
            var end = new DateTime(2023, 10, 5);

            // Simulate that there are no overlapping rentals in the repository
            repository.GetAll<Rent>().Returns(new List<Rent>());

            // Act
            bool isAvailable = rentService.IsCarAvailable(car, start, end);

            // Assert
            Assert.True(isAvailable);
        }

        [Fact]
        public void IsCarAvailable_OverlappingRentals_ReturnsFalse()
        {
            // Arrange
            var repository = Substitute.For<IRepository>();
            var rentService = new RentService(repository);

            var car = new Car();
            var start = new DateTime(2023, 10, 1);
            var end = new DateTime(2023, 10, 5);

            // Simulate overlapping rentals in the repository
            var overlappingRentals = new List<Rent>
            {
            new Rent { Car = car, StartDate = start.AddDays(-1), EndDate = end.AddDays(1) }
             };
            repository.GetAll<Rent>().Returns(overlappingRentals);

            // Act
            bool isAvailable = rentService.IsCarAvailable(car, start, end);

            // Assert
            Assert.False(isAvailable);
        }
    }
}