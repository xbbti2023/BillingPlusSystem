using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AspnetCoreMvcFull.Models.ViewModels
{
  public class authViewModel
  {
    [Required(ErrorMessage = "The UserName is required")]
    [DisplayName("username")]
    public required string username { get; set; }
    [Required(ErrorMessage = "The Phone is required")]
    [DisplayName("phone")]
    public required string phone { get; set; }
    [Required(ErrorMessage = "The email is required")]
    [DisplayName("email")]
    public required string email { get; set; }
    [Required(ErrorMessage = "The password is required")]
    [DisplayName("password")]
    public required string password { get; set; }
  }
}
