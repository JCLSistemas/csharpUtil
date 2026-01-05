using System;

namespace CSharpUtil.Motoboy.Dto
{
    /// <summary>
    /// DTO de resposta para autenticação de usuário na API VivaMoto.
    /// Contém informações sobre o sucesso da operação, token JWT e mensagens.
    /// </summary>
    public class LoginResponseDto
    {
        public bool Sucesso { get; set; }
        public string Token { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;
    }
}
