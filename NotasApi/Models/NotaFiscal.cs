namespace NotasApi.Models;

public class NotaFiscal
{
    public int Id { get; set; }
    public int NumSequencial { get; set; }
    public string Status { get; set; } = "Aberta";
    public DateTime DataCriacao { get; set; } = DateTime.Now;

    public ICollection<NotaProduto> Produtos { get; set; } = new List<NotaProduto>();
}
