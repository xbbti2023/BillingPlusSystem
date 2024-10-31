using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcFull.Models.Entities
{

  public class branch
  {
    [Key]
    public int Id { get; set; }
    public required string branchname { get; set; }
    public string? descr { get; set; }
  }
}
