using System.Collections.Generic;

namespace CSharpUtil.Motoboy.Dto
{
    /// <summary>
    /// Wrapper para deserialização de JSON de empresas vindos do Clarion
    /// no formato {"Empresas": [...]}
    /// </summary>
    public class EmpresaRequestWrapper
    {
        public List<EmpresaSyncDto> Empresas { get; set; }
    }
}