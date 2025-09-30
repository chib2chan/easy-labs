using System;
using System.Diagnostics;
using _1sem8lab;

namespace _1sem8lab
{
    class Program
    {
        static void Main()
        {
            Fleet Avtopark = new Fleet();
            Avtopark.AddCar(CarModel.sedan, CarPlate.Н345УХ45);
            Avtopark.AddCar(CarModel.truck, CarPlate.К123ЕН777);
            Avtopark.AddCar(CarModel.sedan, CarPlate.Н345УХ45);
            Avtopark.AddCar(CarModel.truck, CarPlate.Т890СХ123);

            Driver driver1 = new Driver("Daniel Morales", 30, 10021, new DateTime(1998, 4, 8), "Dr. Malysheva");
            Driver driver2 = new Driver("Vin Diesel", 40, 10451, new DateTime(2001, 7, 18), "Dr. Kupitman");
            Driver driver3 = new Driver("Dominic Toretto", 40, 10391, new DateTime(2001, 10, 18), "Dr. Bykov");

            Avtopark.RegisterDriver(driver1);
            Avtopark.RegisterDriver(driver2);
            Avtopark.RegisterDriver(driver3);

            Avtopark.CreateTrip(Avtopark.Drivers[0], new Sedan(CarPlate.Н345УХ45), new DateTime(2024, 7, 10, 8, 00, 00), new DateTime(2024, 7, 11, 6, 30, 00), CarFuel.Gasoline);
            Avtopark.CreateTrip(Avtopark.Drivers[1], new Truck(CarPlate.К123ЕН777), new DateTime(2024, 7, 10, 6, 00, 00), new DateTime(2024, 7, 10, 12, 18, 00), CarFuel.Diesel);
            Avtopark.CreateTrip(Avtopark.Drivers[2], new Sedan(CarPlate.Н345УХ45), new DateTime(2024, 7, 15, 5, 00, 00), new DateTime(2024, 7, 15, 20, 40, 00), CarFuel.Gasoline);
            Avtopark.CreateTrip(Avtopark.Drivers[0], new Truck(CarPlate.Т890СХ123), new DateTime(2024, 8, 01, 14, 00, 00), new DateTime(2024, 8, 01, 21, 10, 00), CarFuel.Diesel);

            Console.WriteLine($"Поездки за {new DateTime(2024, 7, 10)}");
            Console.WriteLine(Avtopark.DisplayTripInfoByDate(new DateTime(2024, 7, 10)));


            Console.WriteLine($"Поездки за {new DateTime(2024, 7, 15)}");
            Console.WriteLine(Avtopark.DisplayTripInfoByDate(new DateTime(2024, 7, 15)));

            Console.WriteLine($"Поездки за {new DateTime(2024, 8, 01)}");
            Console.WriteLine(Avtopark.DisplayTripInfoByDate(new DateTime(2024, 8, 01)));

            Console.ReadKey();
        }
    }
}
