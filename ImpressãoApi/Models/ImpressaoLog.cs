namespace ImpressaoApi.Models;

public class ImpressaoLog
{
    public int Id { get; set; }
    public int NotaId { get; set; }
    public DateTime DataImpressao { get; set; }= DateTime.Now;
    public string Status { get; set; } = "Sucesso";
    public string? MensagemErro { get; set; }
}
