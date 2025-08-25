using DataBase.Api.Entities;
using DataBase.Api.Interfaces;

namespace DataBase.Api.Repositories
{
    public class PropostaRepository : IPropostaRepository
    {
        private readonly AppDbContext _context;

        public PropostaRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Proposta> BuscarListaPropostas()
        {
            var result = _context.Proposta.ToList();
            return result;
        }

        public Proposta? BuscarProposta(int id)
        {
            var result = _context.Proposta.Find(id);
            return result;
        }

        public void AdicionarProposta(Proposta proposta)
        {
            var result = _context.Proposta.Add(proposta);
            _context.SaveChanges();
        }

        public void AlterarNome(Proposta proposta)
        {
            var propostaDb = _context.Proposta.Find(proposta.Id);
            propostaDb.Nome = proposta.Nome;
            _context.SaveChanges();
        }

        public void AlterarStatus(Proposta proposta)
        {
            var propostaDb = _context.Proposta.Find(proposta.Id);
            propostaDb.Status = proposta.Status;
            _context.SaveChanges();
        }

        public void DeletarProposta(int id)
        {
            var propostaDb = _context.Proposta.Find(id);
            _context.Remove(propostaDb);
            _context.SaveChanges();
        }
    }
}