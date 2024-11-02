using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspnetCoreMvcFull.Data;
using AspnetCoreMvcFull.Models.Entities;
using AspnetCoreMvcFull.Models.ViewModels;

namespace AspnetCoreMvcFull.Controllers
{
  [Route("zone")]
  public class ExpanseController : Controller
  {
    public ApplicationDbContext DbContext { get; }

    public ExpanseController(ApplicationDbContext dbContext)
    {
      DbContext = dbContext;
    }




    [HttpGet("")]
    public IActionResult Index()
    {
      return View();
    }
    [HttpGet("view")]
    public async Task<IActionResult> view()
    {
      var zone = await DbContext.expanses.ToListAsync();
      ViewData["subjects"] = zone;
      return View();
    }

    [HttpGet("create")]
    public async Task<IActionResult> Create()
    {
      var branch = await DbContext.catagories.ToListAsync();
      ViewData["branches"] = branch;
      return View();
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromForm] ExpanseViewModel model)
    {

      if (ModelState.IsValid)
      {
        var newzone = new Expanse()
        {
          money = model.money,
          Catagory = model.catagory,
          descr = model.descr
        };
        DbContext.expanses.Add(newzone);
        DbContext.SaveChanges();
        return RedirectToAction("Create");
      }
      return View();

    }
    [HttpGet("Edit")]
    public async Task<IActionResult> Edit(int id)

    {
      var branch = await DbContext.catagories.ToListAsync();
      ViewData["branches"] = branch;
      var zone = DbContext.expanses.FirstOrDefault(x => x.Id == id);

      return View(zone);
    }
    [HttpPost("Edit")]
    public IActionResult Edit(Expanse model)
    {
      if (ModelState.IsValid)
      {
        var zone = DbContext.expanses.FirstOrDefault(x => x.Id == model.Id);
        zone.money = model.money;
        zone.Catagory = model.Catagory;
        zone.descr= model.descr;
        DbContext.SaveChanges();
        return RedirectToAction("view");
      }
      return View(model);
    }
    [HttpGet("delete")]
    public ActionResult Delete(int id)
    {
      var zone = DbContext.expanses.FirstOrDefault(a => a.Id == id);
      if (zone != null)
      {

        DbContext.expanses.Remove(zone);
        DbContext.SaveChanges();
      }

      return RedirectToAction("view");
    }
  }
}
