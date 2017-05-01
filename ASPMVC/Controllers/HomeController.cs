using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPMVC.Models;

namespace ASPMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            int pageSize = 5;

            if (dataSet.Default == null)
            {
                dataSet.getDataSet();
            }
            Home tempData = new Home { ID = dataSet.Default.ID, PageCount = dataSet.Default.PageCount, FilterSelect = dataSet.Default.FilterSelect };

            tempData = new Home { ID = tempData.ID.OrderBy(x => x).Take(pageSize).ToList(), PageCount = (tempData.PageCount / pageSize) + (tempData.PageCount % pageSize > 0 ? 1 : 0) , FilterSelect = tempData.FilterSelect };

            return View(tempData);
        }
    }
}
