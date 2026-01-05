using System;
using System.Collections.Generic;

namespace CSharpUtil.Motoboy.Dto
{
    /// <summary>
    /// DTO para sincronização de dados de Usuário na API VivaMoto.
    /// Permite criar ou atualizar usuários com vinculação a uma ou mais empresas.
    /// </summary>
    public class UsuarioSyncDto
    {
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;
        public List<Guid> EmpresaIds { get; set; } = new List<Guid>();
    }
}
