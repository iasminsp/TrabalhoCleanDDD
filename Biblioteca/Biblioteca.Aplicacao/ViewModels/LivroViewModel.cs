using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Aplicacao.ViewModels
{
    public class LivroViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        [StringLength(150)]
        public string Titulo { get; set; }

        [StringLength(60)]
        public string Genero { get; set; }

        [Range(0, 2100)]
        public int AnoPublicacao { get; set; }

        [Required(ErrorMessage = "Autor é obrigatório")]
        public int AutorId { get; set; }

        public string AutorNome { get; set; }
    }
}
