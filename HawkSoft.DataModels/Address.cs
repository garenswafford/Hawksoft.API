using System;
using System.Collections.Generic;
using System.Text;

namespace HawkSoft.DataModels
{
    public class Address
    {
        public Guid Id { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
