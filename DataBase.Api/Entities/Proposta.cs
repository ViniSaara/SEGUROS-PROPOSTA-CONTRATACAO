namespace DataBase.Api.Entities
{
    public class Proposta
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Status { get; set; }
        public List<Contratacao> Contratacoes { get; set; }
    }
}