using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcFull.Models.ViewModels
{
    public class watchtViewModel
    {
        [Required(ErrorMessage ="The Watch Name is required")]
        [DisplayName("watch name")]
        public required string watchname { get; set; }

        public string? descr { get; set; }
    }
}
