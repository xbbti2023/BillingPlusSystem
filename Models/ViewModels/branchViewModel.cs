using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcFull.Models.ViewModels
{
  public class branchViewModel
  {
    [Required(ErrorMessage = "The Watch Name is required")]
    [DisplayName("branch name")]
    public required string branchname { get; set; }

    public string? descr { get; set; }
  }
}
