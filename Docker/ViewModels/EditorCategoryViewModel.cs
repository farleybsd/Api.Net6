using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class EditorCategoryViewModel
    {
        [Required(ErrorMessage =" O nome e obrigatorio")]
        [StringLength(40,MinimumLength =3,ErrorMessage ="Esse campo deve conter entre 3 e 40 caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = " O Slug e obrigatorio")]
        public string Slug { get; set; }
    }
}
