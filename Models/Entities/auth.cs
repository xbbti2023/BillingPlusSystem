using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcFull.Models.Entities
{
  public class auth
  {
    [Key]
    public int Id { get; set; }
    public required string username { get; set; }
    public required string phone { get; set; }
    public required string email { get; set; }
    public required string password { get; set; }

  }
}
