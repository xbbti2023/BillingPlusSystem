using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcFull.Models.Entities
{

  public class zone
  {
    [Key]
    public int Id { get; set; }
    public required string zonename { get; set; }
    public required string branchname { get; set; }
    public required float rate { get; set; }

  }
}

