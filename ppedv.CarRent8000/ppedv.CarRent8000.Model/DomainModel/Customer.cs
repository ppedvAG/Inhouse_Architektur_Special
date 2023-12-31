﻿namespace ppedv.CarRent8000.Model.DomainModel
{
    public class Customer : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Rent> Rents { get; set; } = new HashSet<Rent>();
    }

}
