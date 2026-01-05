using System;
using System.Collections.Generic;

namespace CSharpUtil.VivaMoto
{
    /// <summary>
    /// DTO público para envio de dados de Empresa pelos clientes da API.
    /// </summary>
    public class EmpresaClientDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public DateTime? DataUltimaOS { get; set; }
    }

    /// <summary>
    /// DTO público para envio de dados de Ordem de Serviço pelos clientes da API.
    /// </summary>
    public class OrdemServicoClientDto
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public DateTime? DataEmissao { get; set; }
        public int EmpresaId { get; set; }
        public string EmpresaNome { get; set; } = string.Empty;
        public string SolicitanteNome { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Ramal { get; set; } = string.Empty;
        public string EnderecoEntrega { get; set; } = string.Empty;
        public int? MotoboyId { get; set; }
        public string MotoboyNome { get; set; } = string.Empty;

        // Datas e Horários
        public string HoraInicial { get; set; } = string.Empty;
        public DateTime? DataFinal { get; set; }
        public string HoraFinal { get; set; } = string.Empty;

        // Tempos
        public string TempoTotal { get; set; } = string.Empty;
        public string TempoMinimo { get; set; } = string.Empty;
        public string TempoExecucao { get; set; } = string.Empty;
        public string HorasServico { get; set; } = string.Empty;
        public string HorasExtras { get; set; } = string.Empty;
        public string HorasAdicional { get; set; } = string.Empty;
        public string HorasEspera { get; set; } = string.Empty;

        // Quantidades
        public decimal? QuantidadeKm { get; set; }
        public decimal? QuantidadePontos { get; set; }
        public decimal? QuantidadePontosAdicionais { get; set; }

        // Valores Unitários
        public decimal? ValorHora { get; set; }
        public decimal? ValorExtra { get; set; }
        public decimal? ValorHoraEspera { get; set; }
        public decimal? ValorViagem { get; set; }
        public decimal? ValorPonto { get; set; }
        public decimal? ValorAdicional { get; set; }
        public decimal? ValorKm { get; set; }

        // Totais
        public decimal? TotalHoras { get; set; }
        public decimal? TotalHorasEspera { get; set; }
        public decimal? TotalExtras { get; set; }
        public decimal? TotalKm { get; set; }
        public decimal? TotalPontos { get; set; }
        public decimal? ValorDesconto { get; set; }
        public decimal? ValorTotal { get; set; }

        // Faturamento
        public string CondicaoFaturamento { get; set; } = string.Empty;
        public int? PrazoPagamento { get; set; }
        public int? NumeroFatura { get; set; }
        public DateTime? DataFaturamento { get; set; }
        public DateTime? DataVencimento { get; set; }

        // Sistema
        public string Usuario { get; set; } = string.Empty;
        public DateTime? DataAtualizacao { get; set; }
        public int Status { get; set; }
    }

    /// <summary>
    /// DTO público para atualização de status de Ordem de Serviço.
    /// </summary>
    public class StatusUpdateClientDto
    {
        public string IdOs { get; set; } = string.Empty;
        public string EmpresaId { get; set; } = string.Empty;
        public string NovoStatus { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
    }

    /// <summary>
    /// DTO público para envio de dados de Usuário pelos clientes da API.
    /// </summary>
    public class UsuarioClientDto
    {
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;
        public List<int> EmpresaIds { get; set; } = new List<int>();
    }
}
