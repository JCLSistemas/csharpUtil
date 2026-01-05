using System.Collections.Generic;

namespace CSharpUtil.Motoboy.Dto
{
    /// <summary>
    /// Wrapper para deserializar JSON no formato {"Ordens": [...]} recebido do Clarion
    /// </summary>
    public class OrdemRequestWrapper
    {
        public List<OrdemServicoSyncDto> Ordens { get; set; } = new List<OrdemServicoSyncDto>();
    }
}