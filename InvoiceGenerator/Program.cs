using System;

namespace InvoiceGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Cab Invoice Generator");
            Invoice_Generator invoice_Generator = new Invoice_Generator(RideType.NORMAL);
            double fare = invoice_Generator.CalculateFare(4,10);
            Console.WriteLine($"Fare:{fare}");
        }
    }
}
