using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcFull.Models.ViewModels
{
  public class zoneViewModel
  {
    [Required(ErrorMessage = "The zone Name is required")]
    [DisplayName("zone name")]
    public required string zonename { get; set; }

    [Required(ErrorMessage = "The branch Name is required")]
    [DisplayName("branch name")]
    public required string branchname { get; set; }

    [Required(ErrorMessage = "The rate is required")]
    [DisplayName("rate")]
    public required float rate { get; set; }
  }
}
