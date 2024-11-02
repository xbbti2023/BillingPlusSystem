using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspnetCoreMvcFull.Data;
using AspnetCoreMvcFull.Models.Entities;
using AspnetCoreMvcFull.Models.ViewModels;

namespace AspnetCoreMvcFull.Controllers
{
  [Route("auth")]
  public class AuthController : Controller
  {
    public ApplicationDbContext DbContext { get; }

    public AuthController(ApplicationDbContext dbContext)
    {
      DbContext = dbContext;
    }

    public IActionResult ForgotPasswordBasic()
    {
      return View();
    }

    [HttpGet("LoginBasic")]
    public IActionResult LoginBasic()
    {
      return View();
    }

    [HttpPost("LoginBasic")]
    public IActionResult LoginBasic([FromForm] authViewModel model)
    {
      if (ModelState.IsValid)
      {
        var user = DbContext.auths
            .FirstOrDefault(a => a.username == model.username && a.password == model.password);

        if (user == null)
        {
          // Authentication successful, redirect to a secure area.
          return RedirectToAction("Dashboard", "Index");
        }

        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
      }

      return View(model);
    }

    [HttpGet("RegisterBasic")]
    public IActionResult RegisterBasic()
    {
      return View();
    }

    [HttpPost("RegisterBasic")]
    public IActionResult RegisterBasic([FromForm] authViewModel model)
    {
      if (ModelState.IsValid)
      {
        var newbranch = new auth()
        {
          username = model.username,
          phone = model.phone,
          email = model.email,
          password = model.password,
        };

        DbContext.auths.Add(newbranch);
        DbContext.SaveChanges();
        return RedirectToAction("LoginBasic");
      }
      return View(model);
    }
  }
}
