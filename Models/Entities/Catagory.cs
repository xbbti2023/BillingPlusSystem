using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcFull.Models.Entities
{

  public class Catagory
  {
    [Key]
    public int Id { get; set; }
    public required string cata { get; set; }
    public string? descr { get; set; }
  }
}
