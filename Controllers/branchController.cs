using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspnetCoreMvcFull.Data;
using AspnetCoreMvcFull.Models.Entities;
using AspnetCoreMvcFull.Models.ViewModels;

namespace AspnetCoreMvcFull.Controllers
{
  [Route("branch")]
  public class branchController : Controller
  {
    public ApplicationDbContext DbContext { get; }

    public branchController(ApplicationDbContext dbContext)
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
      var branch = await DbContext.branches.ToListAsync();
      ViewData["subjects"] = branch;
      return View();
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost("create")]
    public IActionResult Create([FromForm] branchViewModel model)
    {
      if (ModelState.IsValid)
      {
        var newbranch = new branch()
        {
          branchname = model.branchname,
          descr = model.descr
        };
        DbContext.branches.Add(newbranch);
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
        return View();
      }
      return View(model);
    }
    [HttpGet("delete/{id}")]
    public ActionResult Delete(int id)
    {
      var branch = DbContext.branches.FirstOrDefault(a => a.Id == id);
      if (branch != null)
      {

        DbContext.branches.Remove(branch);
        DbContext.SaveChanges();
      }

      return RedirectToAction("view");
    }
  }
}

