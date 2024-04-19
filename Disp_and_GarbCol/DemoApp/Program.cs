// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;

public static class GarbageCollectionHelper
{
    public static void PrintGCStatus(bool invoked)
    {
        string status = invoked ? "invoked" : "not invoked";
        Console.WriteLine($"Garbage collection: {status}");
    }

    public static bool CheckGCStatus()
    {
        // Create some objects to generate garbage
        var temp = new byte[1024];
        temp = null;

        // Ensure these objects are collected
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        // Check if garbage collection is invoked
        return GC.GetTotalMemory(false) > 0;
    }
}



class CarManagementWithoutGC
{
    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }

        public Car(string make, string model, int year, string color, double price)
        {
            Make = make;
            Model = model;
            Year = year;
            Color = color;
            Price = price;
        }
    }

    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        const int numCars = 100000; // Number of cars to create

        for (int i = 0; i < numCars; i++)
        {
            Car car = new Car("Toyota", "Camry", 2020, "Red", 25000.00);
            cars.Add(car);
            Console.WriteLine($"Car added: {car.Make} {car.Model} {car.Year}");
        }

        // Print the status indicating that garbage collection was not invoked
        GarbageCollectionHelper.PrintGCStatus(false);
    }
}




/*
class CarManagementWithGC
{
    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }

        public Car(string make, string model, int year, string color, double price)
        {
            Make = make;
            Model = model;
            Year = year;
            Color = color;
            Price = price;
        }
    }

    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        const int numCars = 10000; // Number of cars to create

        for (int i = 0; i < numCars; i++)
        {
            Car car = new Car("Toyota", "Camry", 2020, "Red", 25000.00);
            cars.Add(car);
            Console.WriteLine($"Car added: {car.Make} {car.Model} {car.Year}");

            // Check if garbage collection is invoked
            bool invoked = GarbageCollectionHelper.CheckGCStatus();
            GarbageCollectionHelper.PrintGCStatus(invoked);
        }
    }
}

*/