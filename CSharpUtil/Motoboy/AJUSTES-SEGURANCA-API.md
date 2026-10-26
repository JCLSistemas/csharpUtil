# Apontamentos de Segurança e Compatibilidade: DLL .NET x API Portal Expresso Boys

Este documento apresenta a especificação técnica atualizada da integração entre a DLL .NET (`VivaMotoApiService.cs` / `CSharpUtil.cs`) e a API REST do portal PHP (`motoboy-client`).

---

## 1. Sumário das Alterações Realizadas

A DLL .NET foi atualizada para integrar nativamente com a segurança do novo portal PHP:
1. **Chave de Integração no Login (`MtbLogin`):**
   * O método de login agora recebe diretamente a chave de integração `X-Sync-Key`.
   * Ao ser chamado, o `MtbLogin` realiza um *probe* autenticado na API (`POST api/sync/empresas` com `{"empresas":[]}`).
   * Se a chave for válida e a API responder `HTTP 200`, o login retorna `1` e define `EstaConectado = true`.
   * Se a chave for inválida (`HTTP 401`) ou se a URL/servidor estiver offline, o login retorna `0` e preenche `_ultimoErro`.
2. **Endurecimento de Transporte (TLS 1.2 e TLS 1.3):**
   * Desativação de protocolos legados (TLS 1.0 e 1.1) em conformidade com o RFC 8996.
3. **Resolução de URLs e Subpastas:**
   * URLs base tratadas com barra final (`baseUrl.TrimEnd('/') + "/"`) e endpoints sem barra inicial (`api/sync/ordens`), suportando subpastas sem descartar o caminho base no `HttpClient`.
4. **Envelopamento Automático de Lotes JSON:**
   * A DLL detecta se o payload recebido do Clarion começa com array `[...]` e envelopa automaticamente com a chave contêiner esperada (`ordens`, `empresas`, `usuarios`, `updates`).
5. **Detecção de Erros Parciais da API:**
   * A API PHP responde `HTTP 200` mesmo quando há itens com erro no lote. A DLL agora faz o parsing do JSON, avalia `totalErros > 0` e preenche a mensagem de erro caso algum registro falhe.
6. **Higienização de Logs:**
   * Máscara automática aplicada a `X-Sync-Key: [REDACTED]` e campos de senha antes da gravação no `LogService`.
7. **Eliminação de Dependências de UI:**
   * Removido `using System.Windows;` e qualquer chamada modal a `MessageBox.Show()`.

---

## 2. Declarações e Uso no Clarion 5.5

No Clarion, as funções exportadas pela `CSharpUtil.dll` podem ser declaradas da seguinte forma:

```clarion
  MODULE('CSharpUtil.dll')
    ! Inicialização da URL Base
    MtbInicializarAPI(*CSTRING urlBase),PASCAL,RAW,NAME('MtbInicializarAPI')
    MtbInicializarAPIComChave(*CSTRING urlBase, *CSTRING chaveSync),PASCAL,RAW,NAME('MtbInicializarAPIComChave')
    
    ! Configuração e Login com a Chave X-Sync-Key
    ! A função MtbLogin aceita a chave como primeiro parâmetro (mantendo compatibilidade com protótipos de 2 parâmetros)
    MtbLogin(*CSTRING chaveSync, *CSTRING usuario),SIGNED,PASCAL,RAW,NAME('MtbLogin')
    ! Ou versão com apenas 1 parâmetro:
    MtbLoginChave(*CSTRING chaveSync),SIGNED,PASCAL,RAW,NAME('MtbLoginChave')
    MtbConfigurarChave(*CSTRING chaveSync),PASCAL,RAW,NAME('MtbConfigurarChave')

    ! Envio de Dados
    MtbEnviarOS(*CSTRING jsonOrdem),SIGNED,PASCAL,RAW,NAME('MtbEnviarOS')
    MtbEnviarOSLote(*CSTRING jsonOrdens),SIGNED,PASCAL,RAW,NAME('MtbEnviarOSLote')
    MtbAtualizarStatus(*CSTRING jsonStatus),SIGNED,PASCAL,RAW,NAME('MtbAtualizarStatus')
    MtbEnviarEmpresa(*CSTRING jsonEmpresa),SIGNED,PASCAL,RAW,NAME('MtbEnviarEmpresa')
    MtbEnviarUsuario(*CSTRING jsonUsuario),SIGNED,PASCAL,RAW,NAME('MtbEnviarUsuario')

    ! Utilitários e Diagnósticos
    MtbObterUltimoErro(),*CSTRING,PASCAL,RAW,NAME('MtbObterUltimoErro')
    MtbObterUltimaResposta(),*CSTRING,PASCAL,RAW,NAME('MtbObterUltimaResposta')
    MtbEstaConectado(),SIGNED,PASCAL,RAW,NAME('MtbEstaConectado')
    MtbJsonEscape(*CSTRING texto),*CSTRING,PASCAL,RAW,NAME('MtbJsonEscape')
    MtbFinalizar(),PASCAL,RAW,NAME('MtbFinalizar')
  END
```

---

## 3. Fluxo de Execução no Clarion 5.5

```clarion
LocalUrl     CSTRING(255)
LocalChave   CSTRING(255)
LocalJson    CSTRING(65000)
LocalRetorno SIGNED

  CODE
  LocalUrl   = 'https://portal.expressoboys.com.br'
  LocalChave = 'c6a1b89f28d844e19572e8fa39109485f82a1701'  ! Chave X-Sync-Key configurada no servidor

  ! 1. Inicializa o serviço com a URL Base
  MtbInicializarAPI(LocalUrl)

  ! 2. Executa o Login passando a chave X-Sync-Key
  ! A DLL testa a conexão e a validade da chave contra a API web
  IF MtbLogin(LocalChave, '') = 1
     ! 3. Prepara o JSON (pode ser array direto ou envelopado)
     LocalJson = '[{{"numero": 101, "empresaId": "empresa-1", "valorTotal": 35.50}]'

     ! 4. Envia o lote
     LocalRetorno = MtbEnviarOSLote(LocalJson)

     IF LocalRetorno = 1
        MESSAGE('Sincronização concluída com 100% de sucesso!')
     ELSE
        MESSAGE('Erro no processamento do lote: ' & MtbObterUltimoErro(), 'Atenção', ICON:Exclamation)
     END
  ELSE
     MESSAGE('Falha ao autenticar na API: ' & MtbObterUltimoErro(), 'Erro de Conexão', ICON:Hand)
  END

  ! 5. Finaliza e libera recursos
  MtbFinalizar()
```

---

## 4. O que acontece dentro do `MtbLogin` na DLL .NET

```
Clarion: MtbLogin(LocalChave, '')
   │
   ├─► 1. DLL injeta o header no HttpClient:
   │      X-Sync-Key: "c6a1b89f28d844e19572e8fa39109485f82a1701"
   │
   ├─► 2. DLL envia uma sonda (probe) para a API:
   │      POST https://portal.expressoboys.com.br/api/sync/empresas
   │      Body: {"empresas":[]}
   │
   ├─► 3. API PHP valida a chave:
   │      - Se a chave for idêntica à do servidor: retorna HTTP 200 {"sucesso": true, "totalProcessados": 0}
   │      - Se for incorreta: retorna HTTP 401 {"sucesso": false, "mensagem": "Chave de integração inválida."}
   │
   └─► 4. Resposta para o Clarion:
          - HTTP 200: Login retorna 1 (Sucesso)
          - HTTP 401 ou erro de rede: Login retorna 0 (Falha) e armazena detalhe em MtbObterUltimoErro()
```

---

## 5. Homologação e Conclusão

* A solução foi compilada com sucesso em Release (`CSharpUtil.dll` de 32 bits para compatibilidade com o Clarion 5.5).
* Ambas as aplicações (**Viva Moto** e **Expresso Boys**) passam a utilizar o mesmo padrão unificado, seguro e sem dependência de tokens temporários.
