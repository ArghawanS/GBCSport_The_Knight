using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GBCSport_The_Knight.Models
{
    public class Country
    {
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

    }
}
