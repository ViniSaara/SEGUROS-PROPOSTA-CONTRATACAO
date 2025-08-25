using DataBase.Api.Entities;
using DataBase.Api.Interfaces;

namespace DataBase.Api.Repositories
{
    public class ContratacaoRepository : IContratacaoRepository
    {
        private readonly AppDbContext _context;

        public ContratacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Contratacao> BuscarListaContratacoes()
        {
            var result = _context.Contratacao.ToList();
            return result;
        }

        public Contratacao? BuscarContratacao(int id)
        {
            var result = _context.Contratacao.Find(id);
            return result;
        }

        public List<Contratacao> BuscarContratacaoPorIdProposta(int idProposta)
        {
            var result = _context.Contratacao.Where(q => q.IdProposta == idProposta).ToList();
            return result;
        }

        public void AdicionarContratacao(Contratacao contratacao)
        {
            var result = _context.Contratacao.Add(contratacao);
            _context.SaveChanges();
        }

        public void AlterarNome(Contratacao contratacao)
        {
            var contratacaoDb = _context.Contratacao.Find(contratacao.Id);
            contratacaoDb.Nome = contratacao.Nome;
            _context.SaveChanges();
        }
        public void DeletarContratacao(int id)
        {
            var contratacaoDb = _context.Contratacao.Find(id);
            _context.Remove(contratacaoDb);
            _context.SaveChanges();
        }
    }
}