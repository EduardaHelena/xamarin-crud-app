using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinMobileApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }

    }
}
