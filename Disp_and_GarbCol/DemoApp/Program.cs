// See https://aka.ms/new-console-template for more information

/*
 This is a rough demo code made using AI to gain a basic understanding of the topic and showcase it.
 AI was used due to a lack of time as midterms were going on. 
 We'll be further developing this over spring break and before the class presentation to show the 
 actual usage and provide an understanding on the code.
 */

using System;

// A class that implements IDisposable
public class DemoResource : IDisposable
{
    private bool disposed = false;

    // Resource-intensive operation in the constructor
    public DemoResource()
    {
        Console.WriteLine("DemoResource created.");
    }

    // Method to simulate a resource-intensive operation
    public void PerformOperation()
    {
        if (disposed)
            throw new ObjectDisposedException(nameof(DemoResource));

        Console.WriteLine("Performing operation with DemoResource.");
    }

    // Implementation of IDisposable
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // Custom disposal logic
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                // Dispose managed resources
                Console.WriteLine("Disposing managed resources.");
            }

            // Dispose unmanaged resources
            Console.WriteLine("Disposing unmanaged resources.");

            disposed = true;
        }
    }

    // Destructor as a safeguard
    ~DemoResource()
    {
        Dispose(false);
        Console.WriteLine("DemoResource finalized.");
    }
}

class Program
{
    static void Main()
    {
        // Creating a DemoResource instance
        using (DemoResource demoResource = new DemoResource())
        {
            // Using the resource
            demoResource.PerformOperation();
        } // The Dispose method is automatically called when leaving the using block

        Console.WriteLine("After leaving the using block.");

        // Uncomment the line below to see the impact of not disposing the resource
        //DemoResource resourceWithoutDisposal = new DemoResource();

        Console.WriteLine("End of Main method.");
    }
}
