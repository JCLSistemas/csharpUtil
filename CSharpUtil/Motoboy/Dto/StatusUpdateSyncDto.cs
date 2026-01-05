namespace CSharpUtil.Motoboy.Dto
{
    /// <summary>
    /// DTO para atualização de status de Ordem de Serviço na API VivaMoto.
    /// Permite alterar o status de uma ordem identificada por ID e Empresa.
    /// </summary>
    public class StatusUpdateSyncDto
    {
        public string IdOs { get; set; } = string.Empty;
        public string EmpresaId { get; set; } = string.Empty;
        public string NovoStatus { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
    }
}
