using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcFull.Models.ViewModels
{
  public class customerViewModel
  {
    [Required(ErrorMessage = "The Name is required")]
    [DisplayName("Name")]
    public required string name { get; set; }

    [Required(ErrorMessage = "The Phone is required")]
    [DisplayName("Phone")]
    public required string phone { get; set; }

    [Required(ErrorMessage = "The Email is required")]
    [DisplayName("Email")]
    public required string email { get; set; }

    [Required(ErrorMessage = "The branch Name is required")]
    [DisplayName("branch name")]
    public required string branchname { get; set; }

    [Required(ErrorMessage = "The zone Name is required")]
    [DisplayName("Zone name")]
    public required string zonename { get; set; }

    [Required(ErrorMessage = "The Watch Name is required")]
    [DisplayName("Watch name")]
    public required string watchname { get; set; }
  }
}
