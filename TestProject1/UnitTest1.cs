using InvoiceGenerator;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        Invoice_Generator invoice_Generator = null;

        [Test]
        public void GivenDistanceAndTimeShouldRetrunTotalFare()
        {
            invoice_Generator = new Invoice_Generator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            double fare = invoice_Generator.CalculateFare(distance, time);
            double expected = 25;

            Assert.AreEqual(expected, fare);
        }
        [Test]

        public void GivenMultipleRidesShouldReturnInvoiceSummary()
        {
            invoice_Generator = new Invoice_Generator(RideType.NORMAL);
            Ride[] rides = { new Ride(2, 5), new Ride(0.1, 1) };

            InvoiceSummary summary = invoice_Generator.CalculateFare(rides);
            InvoiceSummary expected = new InvoiceSummary(2, 30);

            Assert.AreEqual (expected, summary);
        }
    }
}