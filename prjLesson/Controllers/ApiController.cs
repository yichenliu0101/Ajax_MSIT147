using Microsoft.AspNetCore.Mvc;
using prjLesson.Models;
using System.Text;

namespace prjLesson.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;
        private readonly IWebHostEnvironment _host;

        public ApiController(DemoContext context, IWebHostEnvironment host){
            _context = context;
            _host = host;
        }

        public IActionResult Index()
        {
            return Content("Hello Ajax");
            //return Content("<h2>Hello Content</h2>", "text/html");
            //return Content("<h2>Hello Content 好好好</h2>", "text/html", Encoding.UTF8);

            //return Content("Index", "application/msword");
        }

        public IActionResult AjaxEvent(string userName)
        {
            if(string.IsNullOrEmpty(userName))
            {
                userName = "Guest";
            }

            System.Threading.Thread.Sleep(5000);
            return Content("Hello " +  userName);
        }

        [HttpPost]
        public IActionResult Register(Members member, IFormFile photo) 
        {
            string result = "未上傳檔案";
            if (photo != null)
            {
                string photoName = Path.GetFileNameWithoutExtension(photo.FileName) + Guid.NewGuid().GetHashCode() + Path.GetExtension(photo.FileName);
                result = Path.Combine(_host.WebRootPath, "uploads", photoName);
                using (var fileStream = new FileStream(result, FileMode.Create))
                {
                    photo.CopyTo(fileStream);
                }

                byte[]? imgByte = null;
                using(var memoryStream = new MemoryStream())
                {
                    photo.CopyTo(memoryStream);
                    imgByte = memoryStream.ToArray();
                }

                //加入資料庫
                member.FileName = photoName;
                member.FileData = imgByte;
                _context.Members.Add(member);
                _context.SaveChanges();
            }

            return Content(result);
            //return Content($"Hello {member.Name}");
        }

        public IActionResult GetImage(int id = 1)
        {
            Members? member = _context.Members.Find(id);
            byte[]? imgByte = null;
            if(member != null)
            {
                imgByte = member.FileData;
            }

            return File(imgByte, "image/jpeg");
        }

        public IActionResult Cities()
        {
            var cities = _context.Address.Select(x => x.City).Distinct();

            return Json(cities);
        }

        public IActionResult Districts(string city) 
        {
            var districts = _context.Address.Where(x=> x.City == city).Select(x=> x.SiteId).Distinct();

            return Json(districts);
        }

        public IActionResult Roads(string district) 
        {
            var roads = _context.Address.Where(x=>x.SiteId == district).Select(x=>x.Road).Distinct();

            return Json(roads);
        }

        public IActionResult Address()
        {
            var addressDict = new Dictionary<object, Dictionary<object, List<object>>>();
            
            foreach(var address in _context.Address)
            {
                if (addressDict.ContainsKey(address.City))
                {
                    if (addressDict[address.City].ContainsKey(address.SiteId))
                    {
                        addressDict[address.City][address.SiteId].Add(address.Road);
                        
                    }
                    else
                    {
                        addressDict[address.City].Add(address.SiteId, new List<object>() { address.Road});
                    }
                }
                else
                {
                    addressDict.Add(address.City, new Dictionary<object, List<object>> { { address.SiteId, new List<object> { address.Road} } });
                }
            }

            return Json(addressDict.ToArray());
        }

        //public IActionResult Addresss()
        //{
        //    var addressList = new List<string>();
        //    foreach (var address in _context.Address)
        //    {
        //        if (addressList.Contains(address.City))
        //        {
        //            if(addressList.Contains)
        //        }
        //    }
        //}
    }
}
