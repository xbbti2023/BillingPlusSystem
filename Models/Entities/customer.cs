using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcFull.Models.Entities
{

  public class customer
  {
    [Key]
    public int Id { get; set; }
    public required string name { get; set; }
    public required string phone { get; set; }
    public required string email { get; set; }
    public required string branchname { get; set; }
    public required string zonename { get; set; }
    public required string watchname { get; set; }
  }
}
