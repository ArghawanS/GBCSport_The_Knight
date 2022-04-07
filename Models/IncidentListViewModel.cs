using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSport_The_Knight.Models
{
    public class IncidentListViewModel
    {
        private List<Incident> incidents {get; set;}
        private string filter;
        public List<Incident> Incidents {get => incidents; set => incidents = value;}
        public string Filter {get => filter; set => filter = value;}

    }
}
