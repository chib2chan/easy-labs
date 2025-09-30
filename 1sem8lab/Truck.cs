using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1sem8lab
{
    public class Truck : Car
    {
        public int LoadCapacity { get; set; }
        public Truck(CarPlate licensePlate)
        {
            Model = CarModel.truck;
            LicensePlate = licensePlate;
            FuelType = CarFuel.Diesel;
        }
        public Truck(CarModel truck, CarPlate carPlate, CarFuel Diesel)
        {
            Model = truck;
            LicensePlate = carPlate;
            FuelType = CarFuel.Diesel;
        }
        public override CarModel GetCarType()
        {
            return Model;
        }
        public override CarPlate GetCarPlate()
        {
            return LicensePlate;
        }
        public override CarFuel GetCarFuel()
        {
            return FuelType;
        }
    }
}
