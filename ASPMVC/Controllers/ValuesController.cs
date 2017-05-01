using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ASPMVC.Models;

namespace ASPMVC.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get(string page)
        {
            int pageSize = Constant.pageSize;
            int no = int.Parse(page);
            Home tempData = new Home { ID = dataSet.Default.ID, PageCount = dataSet.Default.PageCount, FilterSelect = dataSet.Default.FilterSelect };
            tempData = new Home { ID = tempData.ID.OrderBy(x => x).Skip((no - 1) * pageSize).Take(pageSize).ToList(), PageCount = (tempData.PageCount / pageSize) + (tempData.PageCount % pageSize > 0 ? 1 : 0), FilterSelect = tempData.FilterSelect };
            return Ok(tempData);
        }

        public IHttpActionResult Get(string state, string make, string insurer)
        {
            int pageSize = Constant.pageSize;
            Home tempData = new Home { ID = dataSet.Default.ID, PageCount = dataSet.Default.PageCount, FilterSelect = dataSet.Default.FilterSelect };
            tempData = FilterClass.GetData(tempData, state, make, insurer, pageSize);
            if(tempData != null)
                tempData = new Home { ID = tempData.ID.OrderBy(x => x).Take(pageSize).ToList(), PageCount = (tempData.PageCount / pageSize) + (tempData.PageCount % pageSize > 0 ? 1 : 0), FilterSelect = tempData.FilterSelect };
            return Ok(tempData);
        }

        public IHttpActionResult Get(string id, string type)
        {
            int Id = int.Parse(id);
            switch(type)
            {
                case "consumer":
                    return Ok(dataSet.cosumerCollection.Where(x => x.Id == Id).Select(s => s.Consumer).First<Consumer>());
                case "vehicle":
                    return Ok(dataSet.vehicleCollection.Where(x => x.Id == Id).Select(s => s.Vehicle).ToList<Vehicle>());
                case "coverage":
                    return Ok(dataSet.coverageCollection.Where(x => x.Id == Id).Select(s => s.Coverage).First<Coverage>());
                default:
                    return null;
            }
        }
    }
}
