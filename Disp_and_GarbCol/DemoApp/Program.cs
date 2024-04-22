// See https://aka.ms/new-console-template for more information

// Garbage Collection and Disposal - Code Demo
// Andrew McGann & Lalith Shashwath Krishna Shastry
// Cpt_S 321

using System;
using System.Collections.Generic;

public interface ICarManagement : IDisposable
{
    void ManageCars();
}

public class CarManager1 : ICarManagement
{
    private List<Car> cars;

    class Car
    {
        public int ID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }

        public Car(int id, string make, string model, int year, string color, double price)
        {
            /*
            Add relevant code here
            */
        }
    }

    public CarManager1()
    {
        cars = new List<Car>();
    }

    public void ManageCars()
    {
        const int numCars = 1000000; // Number of cars to create

        for (int i = 0; i < numCars; i++)
        {
            Car car = new Car(i, "Toyota", "Camry", 2020, "Red", 25000.00);
            cars.Add(car);
            Console.WriteLine($"Car added: {car.ID} {car.Make} {car.Model} {car.Year}");

            GarbageCollectionHelper.PrintGCStatus();
        }

        // Explicitly dispose the car management object
        Dispose();
    }

    public void Dispose()
    {
        
        /*
        Add relevant code here 
        */ 
    }
}

public static class GarbageCollectionHelper
{
    private static int checkInterval = 10000; // Adjust as needed
    private static int carsProcessed = 0;

    public static void PrintGCStatus()
    {
        carsProcessed++;
        if (/*add your condition here*/)
        {
            bool invoked = CheckGCStatus();
            if (invoked)
            {
                Console.WriteLine("Garbage collection: invoked");
            }
            else
            {
                Console.WriteLine("Garbage collection: not invoked");
            }
        }
    }

    public static bool CheckGCStatus()
    {
        // Create some objects to generate garbage
        var temp = new byte[1024];
        temp = null;

        // Ensure these objects are collected
        /*
           Add relevant code here
        */

        // Check if garbage collection is invoked
        return GC.GetTotalMemory(false) > 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ICarManagement carManagement;

        carManagement = new CarManager1();

        carManagement.ManageCars();
    }
}
