namespace DataBase.Api.Entities
{
    public class Contratacao
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int IdProposta { get; set; }
        public DateTime DataContratacao { get; set; }
        public Proposta? Proposta { get; set; }
    }
}