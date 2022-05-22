using System.ComponentModel.DataAnnotations;

namespace livraria.net.api.Dto
{
    public class AuthorDTO
    {
        [Display(Name = "Id do Autor")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome precisa ser fornecido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string Name { get; set; }
        [Range(1, 120, ErrorMessage = "O campo {0} precisa estar entre {1} e {2}")]
        [Display(Name = "Idade do Autor")]
        public int Age { get; set; }
    }
}
