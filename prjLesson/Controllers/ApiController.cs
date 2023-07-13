using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace prjLesson.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            //return Content("Hello Content");
            //return Content("<h2>Hello Content</h2>", "text/html");
            return Content("<h2>Hello Content 好好好</h2>", "text/html", Encoding.UTF8);

            //return Content("Index", "application/msword");
        }
    }
}
