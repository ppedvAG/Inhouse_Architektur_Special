namespace ppedv.CarRent8000.Model.DomainModel
{
    public class Rent : Entity
    {
        public DateTime OrderDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Car? Car { get; set; }
        public Customer? Customer { get; set; }
    }

}
