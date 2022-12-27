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



    }
}
