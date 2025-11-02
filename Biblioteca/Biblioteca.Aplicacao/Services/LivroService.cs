using Biblioteca.Aplicacao.Interfaces;
using Biblioteca.Aplicacao.ViewModels;
using Biblioteca.Dominio.Entities;
using Biblioteca.Dominio.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Aplicacao.Services
{
    public class LivroService : ILivroService
    {
        private readonly IGenericRepository<Livro> _livroRepo;
        private readonly IGenericRepository<Autor> _autorRepo;

        public LivroService(IGenericRepository<Livro> livroRepo, IGenericRepository<Autor> autorRepo)
        {
            _livroRepo = livroRepo;
            _autorRepo = autorRepo;
        }

        public async Task Adicionar(LivroViewModel vm)
        {
            var livro = new Livro
            {
                Titulo = vm.Titulo,
                Genero = vm.Genero,
                AnoPublicacao = vm.AnoPublicacao,
                AutorId = vm.AutorId
            };

            await _livroRepo.AddAsync(livro);
        }

        public async Task Atualizar(LivroViewModel vm)
        {
            var livro = new Livro
            {
                Id = vm.Id,
                Titulo = vm.Titulo,
                Genero = vm.Genero,
                AnoPublicacao = vm.AnoPublicacao,
                AutorId = vm.AutorId
            };
            await _livroRepo.UpdateAsync(livro);
        }

        public async Task Excluir(int id) => await _livroRepo.DeleteAsync(id);

        public async Task<IEnumerable<LivroViewModel>> ObterTodos()
        {
            var livros = await _livroRepo.GetAllAsync();
            var autores = (await _autorRepo.GetAllAsync()).ToDictionary(a => a.Id, a => a.Nome);

            return livros.Select(l => new LivroViewModel
            {
                Id = l.Id,
                Titulo = l.Titulo,
                Genero = l.Genero,
                AnoPublicacao = l.AnoPublicacao,
                AutorId = l.AutorId,
                AutorNome = autores.ContainsKey(l.AutorId) ? autores[l.AutorId] : string.Empty
            });
        }

        public async Task<LivroViewModel?> ObterPorId(int id)
        {
            var l = await _livroRepo.GetByIdAsync(id);
            if (l == null) return null;
            var autor = await _autorRepo.GetByIdAsync(l.AutorId);
            return new LivroViewModel
            {
                Id = l.Id,
                Titulo = l.Titulo,
                Genero = l.Genero,
                AnoPublicacao = l.AnoPublicacao,
                AutorId = l.AutorId,
                AutorNome = autor?.Nome ?? string.Empty
            };
        }
    }
}
