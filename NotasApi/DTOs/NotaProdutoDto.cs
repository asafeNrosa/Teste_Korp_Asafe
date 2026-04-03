namespace NotasApi.DTOs;

public class NotaProdutoDto
{
    public int Id { get; set; }
    public int NotaId { get; set; }
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
}
