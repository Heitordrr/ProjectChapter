using ChapterUC17.Contexts;
using ChapterUC17.Models;

namespace ChapterUC17.Repositories
{
    public class LivroRepository
    {
        private readonly Sqlcontext _context;
        public LivroRepository(Sqlcontext context)
        {
            _context = context;

        }

        public List<Livro> Listar()
        {
            return _context.Livros.ToList();
        }

        public Livro BuscarPorId(int id)
        {
            return _context.Livros.Find(id);
        }

        public void Cadastro(Livro l)
        {
            _context.Livros.Add(l);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Livro l = _context.Livros.Find(id);
            _context.Livros.Remove(l);
            _context.SaveChanges();
        }

        public void Alterar(int id, Livro l)
        {
            Livro livroBuscado = _context.Livros.Find(id);

            if(livroBuscado != null)
            {
                livroBuscado.Titulo = l.Titulo;
                livroBuscado.QUantidadePaginas = l.QUantidadePaginas;
                livroBuscado.Disponivel = l.Disponivel;
                _context.Livros.Update(livroBuscado);
                _context.SaveChanges();


            }
        }

        //internal object? BuscarPorId(object id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
