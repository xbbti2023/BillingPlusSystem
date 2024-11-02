using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspnetCoreMvcFull.Data;
using AspnetCoreMvcFull.Models.Entities;
using AspnetCoreMvcFull.Models.ViewModels;

namespace AspnetCoreMvcFull.Controllers
{
  [Route("customer")]
  public class customerController : Controller
  {
    public ApplicationDbContext DbContext { get; }

    public customerController(ApplicationDbContext dbContext)
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
      var customer = await DbContext.customers.ToListAsync();
      ViewData["subjects"] = customer;
      return View();
    }

    [HttpGet("create")]
    public async Task<IActionResult> Create()
    {
      var branch = await DbContext.catagories.ToListAsync();
      ViewData["branches"] = branch;

      var zone = await DbContext.expanses.ToListAsync();
      ViewData["zones"] = zone;

      var watch = await DbContext.watches.ToListAsync();
      ViewData["watches"] = watch;
      return View();
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromForm] customerViewModel model)
    {
      if (ModelState.IsValid)
      {
        var newcustomer = new customer()
        {
          name = model.name,
          phone = model.phone,
          email = model.email,
          branchname = model.branchname,
          zonename = model.zonename,
          watchname = model.watchname,
        };
        DbContext.customers.Add(newcustomer);
        await DbContext.SaveChangesAsync();
        return RedirectToAction("Create");
      }
      return View();
    }

    [HttpGet("Edit")]
    public async Task<IActionResult> Edit(int id)
    {
      var customer = await DbContext.customers.ToListAsync();
      ViewData["customers"] = customer;
      var zone = DbContext.customers.FirstOrDefault(x => x.Id == id);

      return View(zone);
    }

    [HttpPost("Edit")]
    public IActionResult Edit(customer model)
    {
      if (ModelState.IsValid)
      {
        var customer = DbContext.customers.FirstOrDefault(x => x.Id == model.Id);
        customer.name = model.name;
        customer.phone = model.phone;
        customer.email = model.email;
        customer.branchname = model.branchname;
        customer.zonename = model.zonename;
        customer.watchname = model.watchname;
        DbContext.SaveChanges();
        return RedirectToAction("view");
      }
      return View(model);
    }

    [HttpGet("delete")]
    public ActionResult Delete(int id)
    {
      var customer = DbContext.customers.FirstOrDefault(a => a.Id == id);
      if (customer != null)
      {
        DbContext.customers.Remove(customer);
        DbContext.SaveChanges();
      }
      return RedirectToAction("view");
    }

    // New action to fetch zones based on the selected branch
    [HttpGet("GetZonesByBranch")]
    public async Task<IActionResult> GetZonesByBranch(string branchname1)
    {
      // Fetch zones based on the branchname instead of branch ID
      var zones = await DbContext.expanses
          .Where(z => z.Catagory == branchname1) // Adjust 'BranchName' based on your model's property name
          .ToListAsync();
      return Json(zones);
    }
  }
}
