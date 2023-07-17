using Homework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homework.Controllers
{
    public class ApiController : Controller
    {
        private DemoContext _context;

        public ApiController(DemoContext context)
        {
            _context = context;
        }

        public IActionResult CheckAccount(string name)
        {
            var nameInDb = _context.Members.FirstOrDefault(m => m.Name == name);
            return Json(nameInDb);
        }

        public IActionResult Cities()
        {
            var cities = _context.Address.Select(x => x.City).Distinct();

            return Json(cities);
        }

        public IActionResult Districts(string city)
        {
            var districts = _context.Address.Where(x => x.City == city).Select(x => x.SiteId).Distinct();

            return Json(districts);
        }

        public IActionResult Roads(string district)
        {
            var roads = _context.Address.Where(x => x.SiteId == district).Select(x => x.Road).Distinct();

            return Json(roads);
        }

        //public IActionResult SelectedCitiesOrDistricts(string[] selectedArray)
        //{
        //    List<string> list = new();
        //    switch (selectedArray.Length)
        //    {
        //        case 1:
        //            list = _context.Address.Where(x => x.City == selectedArray[0]).Select(x => x.SiteId).Distinct().ToList();
        //            break;
        //        case 2:
        //            list = _context.Address.Where(x => x.SiteId == selectedArray[1]).Select(x => x.Road).Distinct().ToList();
        //            break;
        //        default:
        //            list = _context.Address.Select(x => x.City).Distinct().ToList();
        //            break;
        //    }
        //    return Json(list);
        //}

        //public IActionResult Address()
        //{
        //    var addressDict = new Dictionary<string, Dictionary<string, List<string>>>();

        //    foreach (var address in _context.Address)
        //    {
        //        if (addressDict.ContainsKey(address.City))
        //        {
        //            if (addressDict[address.City].ContainsKey(address.SiteId))
        //            {
        //                addressDict[address.City][address.SiteId].Add(address.Road);

        //            }
        //            else
        //            {
        //                addressDict[address.City].Add(address.SiteId, new List<string>() { address.Road });
        //            }
        //        }
        //        else
        //        {
        //            addressDict.Add(address.City, new Dictionary<string, List<string>> { { address.SiteId, new List<string> { address.Road } } });
        //        }
        //    }

        //    return Json(addressDict.ToArray());
        //}
    }
}
