 using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceGenerator
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> userRides = null;

        public RideRepository() 
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        public void AddRide(string userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                if (!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userId, list);
                }
            }
            catch (CabInvoiceException)
            {

                throw new CabInvoiceException(CabInvoiceException.ExecptionType.NULL_RIDES, "Rides Are Null");
            }
        }

        public Ride[] GetRides(string userId)
        {
            try
            {
                return this.userRides[userId].ToArray();

            }catch(CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExecptionType.INVALID_USER_ID, "Invalid User Id");
            }
        }
    }
}
