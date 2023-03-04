using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceGenerator
{
    public class CabInvoiceException: Exception
    {
        public enum ExecptionType
        {
            INVALID_RIDE_TYPE,
            INVALID_DISTANCE,
            INVALID_TIME,
            INVALID_USER_ID,
            NULL_RIDES
        }

        ExecptionType type;

        public CabInvoiceException(ExecptionType type, string message) : base(message)
        {
            this.type = type;
        }

    }
}
