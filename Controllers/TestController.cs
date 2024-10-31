using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreMvcFull.Controllers
{
  public class TestController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
