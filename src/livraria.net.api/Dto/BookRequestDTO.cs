using System;
using System.ComponentModel.DataAnnotations;

namespace livraria.net.api.Dto
{
    public class BookRequestDTO
    {
        [Display(Name = "Id do Livro")]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} precisa ser fornecido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo {0} precisa ser fornecido")]
        public string Isbn { get; set; }
        [Display(Name = "Paginas")]
        [Range(1, 5000, ErrorMessage = "O campo {0} precisa ser fornecido e deve ter um valor válido entre {1} e {2}")]
        public int Pages { get; set; }
        [Display(Name = "Capitulos")]
        [Range(1, 200, ErrorMessage = "O campo {0} precisa ser fornecido e deve ter um valor válido entre {1} e {2}")]
        public int Chapters { get; set; }
        [Display(Name = "Id da Editora")]
        [Range(1, Int32.MaxValue, ErrorMessage = "O campo {0} precisa ser fornecido")]
        public int PublisherId { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "O campo {0} precisa ser fornecido")]
        [Display(Name = "Id do Autor")]
        public int AuthorId { get; set; }
    }
}
