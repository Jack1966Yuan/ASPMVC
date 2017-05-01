using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPMVC.Models
{
    public class FilterClass
    {
        public string State { get; set; }
        public string Make { get; set; }
        public string FormerInsurer { get; set; }


        public static Home GetData(Home data, string state, string make, string formerInsurer, int pageSize)
        {
            List<int> Ids = null;

            if (state != null)
            {
                var temp = dataSet.cosumerCollection.Where(x => x.Consumer.State == state);
                Ids = temp.Select(x => x.Id).ToList<int>();
            }

            if (make != null)
            {
                var temp = dataSet.vehicleCollection.Where(x => x.Vehicle.Make == make);
                if (Ids != null)
                {
                    Ids = Dups(Ids, temp.Select(x => x.Id).ToList<int>());
                }
                else
                    Ids = temp.Select(x => x.Id).ToList<int>();
            }

            if (formerInsurer != null)
            {
                var temp = dataSet.coverageCollection.Where(x => x.Coverage.Former_insurer == formerInsurer);

                if (Ids != null)
                {
                    Ids = Dups(Ids, temp.Select(x => x.Id).ToList<int>());
                }
                else
                {
                    Ids = temp.Select(x => x.Id).ToList<int>();
                }
            }

            if (Ids == null)
            {
                if (state == null && make == null && formerInsurer == null)
                    return data;
                else
                    return null;
            }
            else
            {
                Ids = Dups(data.ID, Ids);
                return new Home { ID = Ids, PageCount = Ids.Count / pageSize + 1, FilterSelect = data.FilterSelect };
            }
        }

        private static List<int> Dups(List<int> a, List<int> b)
        {
            List<int> ret = new List<int>();

            foreach (int x in b)
            {
                if (a.Contains(x))
                {
                    ret.Add(x);
                }
            }
            return ret;
        }

    }
}