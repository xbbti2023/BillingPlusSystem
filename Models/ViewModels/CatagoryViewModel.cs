using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcFull.Models.ViewModels
{
  public class CatagoryViewModel
  {
    [Required(ErrorMessage = "The Catagory Name is required")]
    [DisplayName("Catagory")]
    public required string cata { get; set; }

    public string? descr { get; set; }
  }
}
