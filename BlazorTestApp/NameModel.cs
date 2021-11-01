using System.ComponentModel.DataAnnotations;

namespace BlazorTestApp
{
    public class NameModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "You nead at least 3 letters!")]
        public string Name { get; set; }
    }
}
