using System;

namespace ParkingCar3.Models
{
    /// <summary>
    /// Entidade Carro
    /// </summary>

    public class Car
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public string Brand { get; set; }

        public int LicensePlate { get; set; }

        public int ParkingId { get; set; }

        public DateTime DateInitial { get; set; }

        public DateTime DateEnd { get; set; }

    }
}
