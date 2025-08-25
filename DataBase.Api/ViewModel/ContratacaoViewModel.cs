namespace DataBase.Api.ViewModel
{
    public class ContratacaoViewModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int IdProposta { get; set; }
        public DateTime DataContratacao { get; set; }
    }
}