// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using ppedv.CarRent8000.Model.DomainModel;

namespace ppedv.CarRent8000.Api.Controllers
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int KW { get; set; }
        public DateTime BuildDate { get; set; }

        public static CarDTO ToDTO(Car car)
        {
            if (car == null)
            {
                return null;
            }

            return new CarDTO
            {
                Id = car.Id,
                Manufacturer = car.Manufacturer,
                Model = car.Model,
                Color = car.Color,
                KW = car.KW,
                BuildDate = car.BuildDate
            };
        }


        public static Car ToCar(CarDTO carDTO)
        {
            if (carDTO == null)
            {
                throw new ArgumentNullException(nameof(carDTO));
            }


            return new Car
            {
                Manufacturer = carDTO.Manufacturer,
                Model = carDTO.Model,
                Color = carDTO.Color,
                KW = carDTO.KW,
                BuildDate = carDTO.BuildDate
            };


        }

    }

}
