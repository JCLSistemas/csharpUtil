using System;

namespace CSharpUtil.Motoboy.Dto
{
    /// <summary>
    /// DTO para sincronização de dados de Empresa na API VivaMoto.
    /// Contém informações básicas cadastrais da empresa cliente.
    /// </summary>
    public class EmpresaSyncDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public DateTime? DataUltimaOS { get; set; } = null;
    }
}
