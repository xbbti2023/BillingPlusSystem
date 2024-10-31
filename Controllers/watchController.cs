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
    [HttpGet("view")]
    public async Task<IActionResult> view()
    {
      var watch = await DbContext.watches.ToListAsync();
      ViewData["subjects"] = watch;
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
        return RedirectToAction("view");
      }
      return View();
    }
    [HttpPost("Edit")]
    public IActionResult Edit(int id)
    {
      var watch = DbContext.watches.FirstOrDefault(x => x.Id == id);

      return View(watch);
    }
    [HttpPost("Edit")]
    public IActionResult Edit(watch model)
    {
      if (ModelState.IsValid)
      {
        var watch = DbContext.watches.FirstOrDefault(x => x.Id == model.Id);
        watch.watchname = model.watchname;
        watch.descr = model.descr;
        DbContext.SaveChanges();
        return View() ;
      }
      return View(model);
    }
    [HttpGet("delete/{id}")]
    public ActionResult Delete(int id)
    {
      var watch = DbContext.watches.FirstOrDefault(a => a.Id == id);
      if (watch != null)
      {

        DbContext.watches.Remove(watch);
        DbContext.SaveChanges();
      }

      return RedirectToAction("view");
    }
  }
}
