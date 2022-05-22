using livraria.net.core.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace livraria.net.api.Dto
{
    public class UserDTO
    {
        [Display(Name = "Id do Usuário")]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} precisa ser fornecido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string Name { get; set; }
        [Range(1, 120, ErrorMessage = "O campo {0} precisa estar entre {1} e {2}")]
        [Display(Name = "Idade do Usuário")]
        public int Age { get; set; }
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "O campo e-mail precisa ser fornecido")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        [EmailAddress(ErrorMessage = "Um e-mail válido deve ser informado")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Um e-mail válido deve ser informado")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo {0} precisa ser fornecido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string Username { get; set; }
        [Required(ErrorMessage = "O campo {0} precisa ser fornecido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string Password { get; set; }
        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "O campo {0} precisa ser fornecido")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Birthdate { get; set; }
    }
}
