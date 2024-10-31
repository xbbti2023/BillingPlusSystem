using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspnetCoreMvcFull.Data;
using AspnetCoreMvcFull.Models.Entities;
using AspnetCoreMvcFull.Models.ViewModels;

namespace AspnetCoreMvcFull.Controllers
{
  [Route("zone")]
  public class zoneController : Controller
  {
    public ApplicationDbContext DbContext { get; }

    public zoneController(ApplicationDbContext dbContext)
    {
      DbContext = dbContext;
    }


    [HttpGet("")]
    public IActionResult Index()
    {
      return View();
    }
    [HttpGet("zone")]
    public async Task<IActionResult> view()
    {
      var zone = await DbContext.zones.ToListAsync();
      ViewData["subjects"] = zone;
      return View();
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost("create")]
    public IActionResult Create([FromForm] zoneViewModel model)
    {
      if (ModelState.IsValid)
      {
        var newzone = new zone()
        {
          zonename = model.zonename,
          branchname = model.branchname,
          rate = model.rate
        };
        DbContext.zones.Add(newzone);
        DbContext.SaveChanges();
        return View();
      }
      return View();

    }
    [HttpPost("Edit")]
    public IActionResult Edit(int id)
    {
      var zone = DbContext.zones.FirstOrDefault(x => x.Id == id);

      return View(zone);
    }
    [HttpPost("Edit")]
    public IActionResult Edit(zone model)
    {
      if (ModelState.IsValid)
      {
        var zone = DbContext.zones.FirstOrDefault(x => x.Id == model.Id);
        zone.zonename = model.zonename;
        zone.branchname = model.branchname;
        zone.rate= model.rate;
        DbContext.SaveChanges();
        return View();
      }
      return View(model);
    }
    [HttpGet("delete/{id}")]
    public ActionResult Delete(int id)
    {
      var zone = DbContext.zones.FirstOrDefault(a => a.Id == id);
      if (zone != null)
      {

        DbContext.zones.Remove(zone);
        DbContext.SaveChanges();
      }

      return RedirectToAction("view");
    }
  }
}
