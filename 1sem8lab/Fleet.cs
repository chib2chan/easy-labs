using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace _1sem8lab
{
    //пример агрегации - класс Driver и класс Fleet.
    //если автопарк перестанет существовать, то водители будут жить дальше.
    public class Fleet
    {
        private List<Car> Cars = new List<Car>(); 
        public List<Driver> Drivers { get; set; } = new List<Driver>();
        public List<Trip> Trips { get; } = new List<Trip>();

        public CarModel CarPlateToCarType(CarPlate licensePlate)
        {
            foreach (var item in Cars)
            {
                if (item.GetCarPlate() == licensePlate) return item.GetCarType();
            }
            return CarModel.walker; //чтобы "все пути вели к возвращению"
        }

        public void AddCar(CarModel carModel, CarPlate carPlate)
        {
            if (carModel == CarModel.truck) Cars.Add(new Truck(carPlate));
            if (carModel == CarModel.sedan) Cars.Add(new Sedan(carPlate));
        }

        public void RegisterDriver(Driver driver)
        {
            Drivers.Add(driver);
        }

        public void CreateTrip(Driver driver, Car car, DateTime starDate, DateTime endDate, CarFuel carFuel)
        {
            Trips.Add(new Trip(driver, car, starDate, endDate, carFuel));
        }

        public string DisplayTripInfoByDate(DateTime dateTime)
        {
            string a = "";

            foreach (var item in Trips)
            {
                if ((item.StartDate.Year == dateTime.Year) && (item.StartDate.Month == dateTime.Month) && (item.StartDate.Day == dateTime.Day))
                {
                    a += (item.DisplayTripInfo());
                }
            }
            return a;
        }
    }
}
