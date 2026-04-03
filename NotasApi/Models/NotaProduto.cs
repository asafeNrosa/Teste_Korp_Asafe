namespace NotasApi.Models;

public class NotaProduto
{
    public int Id { get; set; }
    public int NotaId { get; set; }
    public string ProdutoCodigo { get; set; } = string.Empty;
    public int Quantidade { get; set; }

    public NotaFiscal Nota { get; set; }
}
