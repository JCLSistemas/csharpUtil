using System;

namespace CSharpUtil.Motoboy.Dto
{
    /// <summary>
    /// DTO para sincronização de Ordem de Serviço com a API VivaMoto.
    /// Contém todos os dados necessários para criar ou atualizar uma ordem de serviço,
    /// incluindo informações financeiras, tempos de execução e status.
    /// Status: 0=Pendente, 1=EmAndamento, 2=EmEntrega, 3=Entregue, 4=Cancelada, 5=Retornada
    /// </summary>
    public class OrdemServicoSyncDto
    {
        public Guid Id { get; set; }
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
        public string HoraInicial { get; set; } = string.Empty; // TimeSpan como string "HH:mm:ss"
        public DateTime? DataFinal { get; set; }
        public string HoraFinal { get; set; } = string.Empty;

        // Tempos (TimeSpan como string "HH:mm:ss")
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

        // Status: usar valor inteiro do enum ou string
        // 0=Pendente, 1=EmAndamento, 2=EmEntrega, 3=Entregue, 4=Cancelada, 5=Retornada
        public int Status { get; set; }
    }
}
