using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace InvoiceGenerator
{
    public class Invoice_Generator
    {
       RideType rideType;
        private RideRepository rideRepository;

        private readonly double Minimum_Cost_Per_Km;
        private readonly int Cost_Per_Time;
        private readonly double Minimum_Fare;

        public Invoice_Generator(RideType rideType)
        {
            this.rideType = rideType;
            this.rideRepository= new RideRepository();
            try
            {
                if (rideType.Equals(RideType.PERMIUM))
                {
                    this.Minimum_Cost_Per_Km= 15;
                    this.Cost_Per_Time= 1;
                    this.Minimum_Fare= 20;
                }
                else if(rideType.Equals(RideType.NORMAL))
                {
                    this.Minimum_Cost_Per_Km = 10;
                    this.Cost_Per_Time = 1;
                    this.Minimum_Fare = 5;
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExecptionType.INVALID_RIDE_TYPE, "Invalid Ride Type");
            }
        }
        public double CalculateFare(double distance, int time)
        {
            double totalFare=0;
            try
            {
                totalFare = (distance * Minimum_Cost_Per_Km) + (time * Cost_Per_Time);
            }
            catch (CabInvoiceException)
            {
                if (rideType.Equals(null))
                {
                    throw new CabInvoiceException(CabInvoiceException.ExecptionType.INVALID_RIDE_TYPE, "Invalid Ride Type");
                }
                if(distance<=0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExecptionType.INVALID_DISTANCE, "Invalid Distance");

                }if(time<=0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExecptionType.INVALID_TIME, "Invalid Time");
                }
            }
                return Math.Max(totalFare, Minimum_Fare);
        }

        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            try
            {
                foreach (Ride ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);
                }
            }
            catch(CabInvoiceException)
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExecptionType.NULL_RIDES,"Invalid Rides");
                }
            }
            return new InvoiceSummary(rides.Length, totalFare);
        }

        public void AddRides(String userId, Ride[] rides)
        {
            try
            {
                rideRepository.AddRide(userId, rides);
            }
            catch (CabInvoiceException)
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExecptionType.NULL_RIDES, "Invalid null Rides");
                }
            }
        }

        public InvoiceSummary GetInvoiceSummary(String userId)
        {
            try
            {
                return this.CalculateFare(rideRepository.GetRides(userId));
            }
            catch(CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExecptionType.INVALID_USER_ID, "Invalid User ID");
            }
        }
    }
}
