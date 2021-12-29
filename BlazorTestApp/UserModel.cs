using System.ComponentModel.DataAnnotations;

namespace BlazorTestApp
{
    public class UserModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "You need at least 3 letters!")]
        public string Name { get; set; }

        [Required]
        [Range(typeof(bool), "true", "true",
        ErrorMessage = "You need to be ready!")]
        public bool IsReady { get; set; }
    }
}
