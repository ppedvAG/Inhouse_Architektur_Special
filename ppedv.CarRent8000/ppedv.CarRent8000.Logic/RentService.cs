using ppedv.CarRent8000.Model.Contracts;
using ppedv.CarRent8000.Model.DomainModel;
using System.Data;

namespace ppedv.CarRent8000.Logic
{
    public class RentService : IRentService
    {
        private readonly IRepository repository;

        public RentService(IRepository repository)
        {
            this.repository = repository;
        }

        public bool IsCarAvailable(Car car, DateTime start, DateTime end)
        {
            if (car == null)
                throw new ArgumentNullException(nameof(car));

            if (end < start)
                throw new ArgumentException("Ende darf nicht vor dem Start sein");

            // Check if there are any existing rentals for the car that overlap with the specified time period
            var overlappingRentals = repository.GetAll<Rent>()
                .Where(x => x.Car == car &&
                            !(x.StartDate >= end || x.EndDate <= start))
                .ToList();

            return overlappingRentals.Count == 0;
        }

        public void StartRent()
        {
            //Check Car Availibily
            //Check Customer aGE
            //insert Rent
        }

    }
}
