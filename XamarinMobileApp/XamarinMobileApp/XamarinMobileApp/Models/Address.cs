using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinMobileApp.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string AddressComplement { get; set; }
        public string CEP { get; set; }

    }
}
