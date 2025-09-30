namespace _1sem8lab
{
    public abstract class Car
    {
        protected CarModel Model { get; set; }
        protected CarPlate LicensePlate { get; set; }
        protected CarFuel FuelType { get; set; }
        abstract public CarModel GetCarType();
        abstract public CarPlate GetCarPlate();
        abstract public CarFuel GetCarFuel();
    }
}
