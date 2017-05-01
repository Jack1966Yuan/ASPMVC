using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPMVC.Models
{
    public class Coverage
    {
        public string Months_insured { get; set; }
        public string Has_coverage { get; set; }
        public string Type { get; set; }
        public string Bodilyinjury_person { get; set; }
        public string Bodilyinjury_accident { get; set; }
        public string Deductible { get; set; }
        public string Propertydamage { get; set; }
        public string Expiration_date { get; set; }
        public string Expiration_days_remaining { get; set; }
        public string DtgExpirationDate { get; set; }
        public string Former_insurer { get; set; }
    }
}