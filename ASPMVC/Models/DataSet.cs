using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace ASPMVC.Models
{
    public static class dataSet
    {
        public static List<VehicleInsurance> Quotes { get; set; }
        public static Home Default { get; set; }
        public static SelectionClass Filter { get; set; }
        public static List<IdConsumer> cosumerCollection { get; set; }
        public static List<IdVehicle> vehicleCollection { get; set; }
        public static List<IdCoverage> coverageCollection { get; set; }




        //ID, state; ID make; ID FormerInsureance
        public static void getDataSet()
        {
            using (StreamReader r = new StreamReader(System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/auto.leads.json")))
            {
                string json = r.ReadToEnd();
                List<VehicleInsurance> VehicleInsuranceSet = JsonConvert.DeserializeObject<List<VehicleInsurance>>(json);

                cosumerCollection = VehicleInsuranceSet.Select(x => new IdConsumer { Id = x.Id, Consumer = x.consumer }).ToList<IdConsumer>();
                var st = cosumerCollection.Select(s => s.Consumer.State).Where(x => x != "").Distinct().OrderBy(x => x).ToList<string>();

                var veCollection0 = VehicleInsuranceSet.Select(x => new IdVehicleList { Id = x.Id, Vehicles = x.vehicle }).ToList<IdVehicleList>();
                vehicleCollection = new List<IdVehicle>();
                foreach (IdVehicleList t in veCollection0)
                {
                    foreach (Vehicle v in t.Vehicles)
                    {
                        vehicleCollection.Add(new IdVehicle { Id = t.Id, Vehicle = v });
                    }
                }
                var mk = vehicleCollection.Select(x => x.Vehicle.Make).Where(x => x != "").Distinct().OrderBy(x => x).ToList<string>();

                coverageCollection = VehicleInsuranceSet.Select(x => new IdCoverage { Id = x.Id, Coverage = x.coverage }).ToList<IdCoverage>();
                var fi = coverageCollection.Select(s => s.Coverage.Former_insurer).Where(x => x != "").Distinct().OrderBy(x => x).ToList<string>();

                List<int> ids = VehicleInsuranceSet.Select(x => x.Id).OrderBy(x => x).ToList<int>();
                Filter = new SelectionClass { State = st, Make = mk, FormerInsurance = fi };
                Default = new Home { ID = ids, PageCount = ids.Count, FilterSelect = Filter };
                Quotes = VehicleInsuranceSet;
            }
        }
    }


    public class IdConsumer
    {
        public int Id { get; set; }
        public Consumer Consumer { get; set; }
    }

    public class IdVehicleList
    {
        public int Id { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }

    public class IdVehicle
    {
        public int Id { get; set; }
        public Vehicle Vehicle { get; set; }
    }

    public class IdCoverage
    {
        public int Id { get; set; }
        public Coverage Coverage { get; set; }
    }
}