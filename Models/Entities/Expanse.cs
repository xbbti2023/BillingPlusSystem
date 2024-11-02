using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcFull.Models.Entities
{

  public class Expanse
  {
    [Key]
    public int Id { get; set; }
    public required float money { get; set; }
    public  string Catagory { get; set; }
    public string? descr { get; set; }

  }
}

