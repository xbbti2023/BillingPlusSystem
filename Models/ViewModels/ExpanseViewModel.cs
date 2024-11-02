using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcFull.Models.ViewModels
{
  public class ExpanseViewModel
  {
    [Required(ErrorMessage = "The zone Name is required")]
    [DisplayName("zone name")]
    public required float money { get; set; }

    [Required(ErrorMessage = "The catagory is required")]
    [DisplayName("catagory")]
    public  string catagory { get; set; }

    public string? descr { get; set; }
  }
}
