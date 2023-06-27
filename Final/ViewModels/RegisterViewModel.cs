using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = " O Nome e obrigatorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = " O Email e obrigatorio")]
        [EmailAddress(ErrorMessage = " O E-mail e invalido")]
        public string Email { get; set; }
    }
}
