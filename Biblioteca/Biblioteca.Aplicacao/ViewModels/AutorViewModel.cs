using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Aplicacao.ViewModels
{
    public class AutorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do autor é obrigatório")]
        [StringLength(100)]
        public string Nome { get; set; }
    }
}
