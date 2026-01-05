using System.Collections.Generic;

namespace CSharpUtil.Motoboy.Dto
{
    /// <summary>
    /// DTO de resposta para operações de sincronização na API VivaMoto.
    /// Fornece estatísticas sobre processamento em lote e lista de erros.
    /// </summary>
    public class SyncResponseDto
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public int TotalProcessados { get; set; }
        public int TotalSucesso { get; set; }
        public int TotalErros { get; set; }
        public List<string> Erros { get; set; } = new List<string>();
    }
}
