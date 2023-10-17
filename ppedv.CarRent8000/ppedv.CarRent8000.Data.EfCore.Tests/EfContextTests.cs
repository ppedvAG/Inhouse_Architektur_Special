using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using ppedv.CarRent8000.Model.DomainModel;
using System.Reflection;

namespace ppedv.CarRent8000.Data.EfCore.Tests
{
    public class EfContextTests
    {
        string conString = "Server=(localdb)\\mssqllocaldb;Database=CarRent8000_dev;Trusted_Connection=true;";

        [Fact]
        public void Can_create_db()
        {
            var con = new EfContext(conString);
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            Assert.True(result);
        }

        [Fact]
        public void Can_insert_Car()
        {
            var car = new Car() { Color = "gelb" };
            var con = new EfContext(conString);

            con.Cars.Add(car);
            var rows = con.SaveChanges();

            Assert.Equal(1, rows);
        }


        [Fact]
        public void Can_read_Car()
        {
            var car = new Car() { Color = $"blau_{Guid.NewGuid()}" };
            using (var con = new EfContext(conString))
            {
                con.Cars.Add(car);
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Cars.Find(car.Id);
                Assert.Equal(car.Color, loaded.Color);
            }
        }


        [Fact]
        public void Can_read_Car_AutoFixture()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new PropertyNameOmitter(nameof(Entity.Id)));

            var car = fix.Create<Car>();

            using (var con = new EfContext(conString))
            {
                con.Cars.Add(car);
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Cars.Find(car.Id);
                loaded.Should().BeEquivalentTo(car, x => x.IgnoringCyclicReferences());

            }
        }


        internal class PropertyNameOmitter : ISpecimenBuilder
        {
            private readonly IEnumerable<string> names;

            internal PropertyNameOmitter(params string[] names)
            {
                this.names = names;
            }

            public object Create(object request, ISpecimenContext context)
            {
                var propInfo = request as PropertyInfo;
                if (propInfo != null && names.Contains(propInfo.Name))
                    return new OmitSpecimen();

                return new NoSpecimen();
            }
        }

    }
}