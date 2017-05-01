using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPMVC.Models
{
    public class Home
    {
        public List<int> ID { get; set; }
        public int PageCount { get; set; }
        public SelectionClass FilterSelect { get; set; }
    }
}