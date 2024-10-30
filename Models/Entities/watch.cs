using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcFull.Models.Entities
{

  public class watch
  {
    [Key]
    public int Id { get; set; }
    public required string watchname { get; set; }
    public string? descr { get; set; }
  }
}
