using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspnetCoreMvcFull.Data;
using AspnetCoreMvcFull.Models.Entities;
using AspnetCoreMvcFull.Models.ViewModels;

namespace AspnetCoreMvcFull.Controllers
{
  [Route("catagory")]
  public class CatagoryController : Controller
  {
    public ApplicationDbContext DbContext { get; }

    public CatagoryController(ApplicationDbContext dbContext)
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
      var branch = await DbContext.catagories.ToListAsync();
      ViewData["subjects"] = branch;
      return View();
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost("create")]
    public IActionResult Create([FromForm] CatagoryViewModel model)
    {
      if (ModelState.IsValid)
      {
        // Check if watchname already exists
        bool branchExists = DbContext.catagories.Any(w => w.cata == model.cata);
        if (branchExists)
        {
          ModelState.AddModelError("cata", "Category already exists. Please choose a different name.");
          return View(model);
        }

        var newbranch = new Catagory()
        {
          cata = model.cata,
          descr = model.descr
        };
        DbContext.catagories.Add(newbranch);
        DbContext.SaveChanges();
        return RedirectToAction("create");
      }
      return View(model);
    }
    [HttpGet("Edit")]
    public IActionResult Edit(int id)
    {
      var branch = DbContext.catagories.FirstOrDefault(x => x.Id == id);

      return View(branch);
    }
    [HttpPost("Edit")]
    public IActionResult Edit(Catagory model)
    {
      if (ModelState.IsValid)
      {
        var branch = DbContext.catagories.FirstOrDefault(x => x.Id == model.Id);
        branch.cata = model.cata;
        branch.descr = model.descr;
        DbContext.SaveChanges();
        return RedirectToAction("view");
      }
      return View(model);
    }
    [HttpGet("delete")]
    public ActionResult Delete(int id)
    {
      var branch = DbContext.catagories.FirstOrDefault(a => a.Id == id);
      if (branch != null)
      {

        DbContext.catagories.Remove(branch);
        DbContext.SaveChanges();
      }

      return RedirectToAction("view");
    }
  }
}

