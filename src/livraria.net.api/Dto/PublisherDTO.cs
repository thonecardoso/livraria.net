using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace livraria.net.api.Dto
{
    public class PublisherDTO
    {
        [Display(Name = "Id da Editora")]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} precisa ser fornecido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string Name { get; set; }
        [Display(Name = "Código")]
        [Required(ErrorMessage = "O campo {0} precisa ser fornecido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string Code { get; set; }
        [Display(Name = "Data de fundação")]
        [Required(ErrorMessage = "O campo {0} precisa ser fornecido")]
        [DataType(DataType.Date)]
        public DateTime? FundationDate { get; set; }
    }
}
