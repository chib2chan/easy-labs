using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1sem8lab
{
    public class Trip
    {
        public Driver Driver;
        private Car car;

        public CarPlate LicensePlate { get; set; }
        public CarModel CarType { get; set; }
        public CarFuel FuelType { get; set; }
        public TimeSpan TripDuration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Trip(Driver driver, Car car, DateTime starDate, DateTime endDate, CarFuel FuelType)
        {
            Driver = driver;
            this.car = car;
            StartDate = starDate;
            EndDate = endDate;
            CarType = car.GetCarType();
            if (CarType == CarModel.sedan)
            {
                FuelType = CarFuel.Gasoline;
            }
            else
            {
                FuelType = CarFuel.Diesel;
            }
            TripDuration = endDate.Subtract(starDate);
            
        }

        public string DisplayTripInfo() //вот и вывод содержимого журнала, собственно
        {
            if (CarType == CarModel.sedan) //если убрать эту штуку - будет плохо. не надо её убирать.
            {
                FuelType = CarFuel.Gasoline;
            }
            else
            {
                FuelType = CarFuel.Diesel;
            }
            return ($"Водитель: {Driver.Name} \n " +
                    $"Дата: {StartDate.Year}:{StartDate.Month}:{StartDate.Day}\n " +
                    $"Продолжительность: {TripDuration}\n " +
                    $"Автомобиль: {CarType}\n " +
                    $"Вид топлива: {FuelType}\n");
        }
    }
}
