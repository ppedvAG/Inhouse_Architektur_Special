using ppedv.CarRent8000.Model.DomainModel;

namespace ppedv.CarRent8000.Logic
{
    public interface IRentService
    {
        bool IsCarAvailable(Car car, DateTime start, DateTime end);
        void StartRent();
    }
}