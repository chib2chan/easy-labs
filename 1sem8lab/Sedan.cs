using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1sem8lab
{
    public class Sedan : Car
    {
        public int TrunkCapacity { get; set; }

        public Sedan(CarPlate licensePlate)
        {
            Model = CarModel.sedan;
            LicensePlate = licensePlate;
            FuelType = CarFuel.Gasoline;
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
