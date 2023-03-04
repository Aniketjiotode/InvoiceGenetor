using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceGenerator
{
    public class InvoiceSummary
    {
        private int NumberOfRides;
        private double totalFare;
        private double averageFare;

        public InvoiceSummary(int numberOfRides,double totaleFare)
        {
                this.NumberOfRides = numberOfRides;
                this.totalFare= totaleFare;
                this.averageFare= totaleFare/this.NumberOfRides;
        }

        public override bool Equals(object obj)
        {
           if (obj == null) return false;
           if(!(obj is InvoiceSummary)) return false;
           InvoiceSummary inputedObject= (InvoiceSummary)obj;
            return this.NumberOfRides==inputedObject.NumberOfRides && this.totalFare==inputedObject.totalFare && this.averageFare==inputedObject.averageFare;
        }
        public override int GetHashCode()
        {
            return this.NumberOfRides.GetHashCode()^this.totalFare.GetHashCode()^this.averageFare.GetHashCode();
s        }
    }
}
