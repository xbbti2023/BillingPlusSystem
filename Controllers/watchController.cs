using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspnetCoreMvcFull.Data;
using AspnetCoreMvcFull.Models.Entities;
using AspnetCoreMvcFull.Models.ViewModels;

namespace AspnetCoreMvcFull.Controllers
{
  [Route("watch")]
  public class WatchController : Controller
  {
    public ApplicationDbContext DbContext { get; }

    public WatchController(ApplicationDbContext dbContext)
    {
      DbContext = dbContext;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
      return View();
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost("create")]
    public IActionResult Create([FromForm] watchtViewModel model)
    {
      if (ModelState.IsValid)
      {
        var newwatch = new watch()
        {
          watchname = model.watchname,
          descr = model.descr
        };
        DbContext.watches.Add(newwatch);
        DbContext.SaveChanges();
        return View();
      }
      return View();
    }
  }
}
