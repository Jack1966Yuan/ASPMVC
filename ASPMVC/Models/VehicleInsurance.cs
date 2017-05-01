using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPMVC.Models
{
    public class VehicleInsurance
    {
        public int Id;
        public Consumer consumer { get; set; }
        public List<Vehicle> vehicle { get; set; }
        public Coverage coverage { get; set; }
    }
}