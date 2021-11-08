using System;
using System.Collections.Generic;
using System.Text;

namespace CountryApp.Models
{
    class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Language { get; set; }
        public string Currency { get; set; }
    }
}
