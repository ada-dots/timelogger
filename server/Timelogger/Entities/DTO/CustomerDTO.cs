using System;
using System.Collections.Generic;
using System.Text;

namespace Timelogger.Entities.DTO
{
    public class CustomerDTO
    {
        public int CustomerId { get; internal set; }
        public string CustomerName { get; internal set; }
        public string CustomerInfo { get; internal set; }
    }
}
