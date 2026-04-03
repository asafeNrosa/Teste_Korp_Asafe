namespace ProdutosApi.DTO;

public class ProdutoDto
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Descricao { get; set; }
    public int Saldo { get; set; }
    public DateTime DataCriacao { get; set; }
}
