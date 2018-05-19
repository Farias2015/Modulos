using System.ComponentModel.DataAnnotations;

namespace Modulos.IO.Services.Api.ViewModels
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {

        }

        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Favor informar a Razão Social")]
        [MinLength(2, ErrorMessage = "Razão Social deve possuir no mínimo 2 caracteres")]
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }

    }
}
