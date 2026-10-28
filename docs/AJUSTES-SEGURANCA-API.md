# Apontamentos de Segurança e Compatibilidade: DLL .NET x API Portal Expresso Boys

Este documento apresenta a especificação técnica atualizada da integração entre a DLL .NET (`VivaMotoApiService.cs` / `CSharpUtil.cs`) e a API REST do portal PHP (`motoboy-client`), com foco na arquitetura de autenticação via **`X-Sync-Key`** e compatibilidade com o **Clarion 5.5**.

---

## 1. Sumário das Alterações Realizadas na DLL .NET

A DLL .NET foi refatorada e simplificada para integrar nativamente com a segurança do novo portal PHP:

1. **Unificação da Inicialização (`MtbInicializarAPI`):**
   * O método `MtbInicializarAPI` agora recebe diretamente os dois parâmetros essenciais: `urlBase` e `chaveSync`.
   * O método redundante `MtbInicializarAPIComChave` foi **excluído**.
   * Ao inicializar, a DLL configura o `BaseAddress`, timeout e já injeta o cabeçalho padrão `X-Sync-Key`.

2. **Simplificação e Validação do Login (`MtbLogin`):**
   * O método `MtbLogin` recebe **apenas 1 parâmetro**: `chaveSync`.
   * O método legado de 2 parâmetros `(chaveSync, usuario)` e o método auxiliar `MtbLoginChave` foram **excluídos**.
   * Ao ser chamado, o `MtbLogin` realiza uma sonda (*probe*) autenticada na API (`POST api/sync/empresas` com `{"empresas":[]}`).
   * Se a chave for válida e a API responder `HTTP 200`, o login retorna `1` e define `EstaConectado = true`.
   * Se a chave for inválida (`HTTP 401`) ou se o servidor/rede falhar, retorna `0` e preenche `_ultimoErro`.
   * **Fallback Inteligente:** Caso `MtbLogin` seja chamado com string vazia (`""`), ele utiliza automaticamente a `chaveSync` já configurada no `MtbInicializarAPI`.

3. **Endurecimento de Transporte (TLS 1.2 e TLS 1.3):**
   * Desativação de protocolos legados (SSL 3.0, TLS 1.0 e 1.1) em conformidade com o RFC 8996.

4. **Resolução de URLs e Subpastas:**
   * URLs base tratadas com barra final (`baseUrl.TrimEnd('/') + "/"`) e endpoints sem barra inicial (`api/sync/ordens`), suportando subpastas sem descartar o caminho base no `HttpClient`.

5. **Envelopamento Automático de Lotes JSON:**
   * A DLL detecta se o payload recebido do Clarion começa com array `[...]` e envelopa automaticamente com a chave contêiner esperada (`ordens`, `empresas`, `usuarios`, `updates`).

6. **Detecção de Erros Parciais da API:**
   * A API PHP pode responder `HTTP 200` mesmo quando há itens com erro no lote. A DLL agora faz o parsing do JSON, avalia `totalErros > 0` e preenche a mensagem de erro detalhada em `MtbObterUltimoErro()`.

7. **Higienização de Logs:**
   * Máscara automática aplicada a `X-Sync-Key: [REDACTED]` e campos de senha antes da gravação no `LogService`.

8. **Eliminação de Dependências de UI:**
   * Removido `using System.Windows;` e qualquer chamada modal a `MessageBox.Show()`, garantindo operação headless segura em serviços ou rotinas em lote.

---

## 2. Tabela de De-Para (Métodos Exportados)

| Método Legado / Anterior | Novo Método Unificado | Parâmetros | Observação |
| :--- | :--- | :--- | :--- |
| `MtbInicializarAPI(urlBase)`<br>`MtbInicializarAPIComChave(url, chave)` | **`MtbInicializarAPI`** | `(string urlBase, string chaveSync)` | Unificado em um único método. `MtbInicializarAPIComChave` foi removido. |
| `MtbLogin(chaveSync, usuario)`<br>`MtbLoginChave(chaveSync)` | **`MtbLogin`** | `(string chaveSync)` | Assinatura simplificada para 1 parâmetro. `MtbLoginChave` foi removido. |
| `MtbConfigurarChave(chaveSync)` | **`MtbConfigurarChave`** | `(string chaveSync)` | Mantido para atualização dinâmica da chave sem recriar o cliente. |
| `MtbFinalizar()` | **`MtbFinalizar`** | `()` | Mantido para liberar recursos do `HttpClient`. |

---

## 3. Declarações no Clarion 5.5 (`MODULE`)

No Clarion (seja no `Global Map`, em arquivo `.INC` ou na seção `Inside Global Map`), utilize as seguintes declarações com convenção `PASCAL,RAW`:

```clarion
  MODULE('CSharpUtil.dll')
    ! 1. Inicialização única da API (URL Base + Chave X-Sync-Key)
    MtbInicializarAPI(*CSTRING urlBase, *CSTRING chaveSync),PASCAL,RAW,NAME('MtbInicializarAPI')
    
    ! 2. Probe e validação da chave na API (Assinatura com 1 parâmetro)
    MtbLogin(*CSTRING chaveSync),SIGNED,PASCAL,RAW,NAME('MtbLogin')
    
    ! 3. Configuração dinâmica da chave (se necessário)
    MtbConfigurarChave(*CSTRING chaveSync),PASCAL,RAW,NAME('MtbConfigurarChave')

    ! 4. Envio e sincronização de dados
    MtbEnviarOS(*CSTRING jsonOrdem),SIGNED,PASCAL,RAW,NAME('MtbEnviarOS')
    MtbEnviarOSLote(*CSTRING jsonOrdens),SIGNED,PASCAL,RAW,NAME('MtbEnviarOSLote')
    MtbAtualizarStatus(*CSTRING jsonStatus),SIGNED,PASCAL,RAW,NAME('MtbAtualizarStatus')
    MtbEnviarEmpresa(*CSTRING jsonEmpresa),SIGNED,PASCAL,RAW,NAME('MtbEnviarEmpresa')
    MtbEnviarUsuario(*CSTRING jsonUsuario),SIGNED,PASCAL,RAW,NAME('MtbEnviarUsuario')

    ! 5. Diagnósticos e encerramento
    MtbObterUltimoErro(),*CSTRING,PASCAL,RAW,NAME('MtbObterUltimoErro')
    MtbObterUltimaResposta(),*CSTRING,PASCAL,RAW,NAME('MtbObterUltimaResposta')
    MtbObterToken(),*CSTRING,PASCAL,RAW,NAME('MtbObterToken')
    MtbEstaConectado(),SIGNED,PASCAL,RAW,NAME('MtbEstaConectado')
    MtbJsonEscape(*CSTRING texto),*CSTRING,PASCAL,RAW,NAME('MtbJsonEscape')
    MtbFinalizar(),PASCAL,RAW,NAME('MtbFinalizar')
  END
```

> [!WARNING]
> Remova do seu projeto Clarion qualquer menção aos métodos obsoletos `MtbInicializarAPIComChave` e `MtbLoginChave`. Deixar métodos inexistentes no `MODULE` causará erro de resolução de símbolos em tempo de execução ao carregar a DLL.

---

## 4. Implementação Padrão no Clarion: Procedure `fWB::Login`

Abaixo está a implementação recomendada para a rotina de login/inicialização no Clarion 5.5, já incluindo proteções contra GPF com `OMITTED` e validação defensiva da URL:

```clarion
                     MEMBER('SCELIB.clw')                  ! This is a MEMBER module

fWB::Login           FUNCTION (<?STRING pChaveSync>, <?STRING pUrlBase>) ! Declare Procedure
!---- Variables ----!
_msgErro    STRING(255)
_urlBase    CSTRING(255)
_chaveSync  CSTRING(255)
  CODE                                                     ! Begin processed code
 !---- 1. Extração segura dos parâmetros opcionais (anti-GPF) ----!
 IF NOT OMITTED(pChaveSync)
    _chaveSync = CLIP(pChaveSync)
 END

 IF NOT OMITTED(pUrlBase)
    _urlBase = CLIP(pUrlBase)
 END

 !---- Fallback: se não informado por parâmetro, lê direto do registro de FWEMPR ----!
 IF _chaveSync = '' THEN
    _chaveSync = CLIP(FWEMPR:X_Sync_Key)
 END
 IF _urlBase = '' THEN
    _urlBase = CLIP(FWEMPR:webSyncUrlBase)
 END

 !---- 2. Validação dos campos obrigatórios ----!
 IF _urlBase = '' THEN
    MESSAGE('A URL base da API não foi informada nas configurações de integração.', |
            'Configuração da API', ICON:EXCLAMATION)
    RETURN(FALSE)
 END

 ! Defensivo: garante protocolo na URL para o HttpClient do .NET
 IF UPPER(_urlBase[1 : 4]) <> 'HTTP' THEN
    _urlBase = 'https://' & _urlBase
 END

 IF _chaveSync = '' THEN
    MESSAGE('A chave de integração (X-Sync-Key) não foi informada.', |
            'Autenticação da API', ICON:EXCLAMATION)
    RETURN(FALSE)
 END

 !---- 3. Inicializa o cliente HTTP com URL e Chave X-Sync-Key ----!
 MtbInicializarAPI(_urlBase, _chaveSync)
 _msgErro = MtbObterUltimoErro()
 IF CLIP(_msgErro) <> '' THEN
    MESSAGE(CLIP(_msgErro), 'Inicialização da API', ICON:CROSS)
    RETURN(FALSE)
 END

 !---- 4. Executa a sonda (probe) na API para validar a chave ----!
 IF MtbLogin(_chaveSync) = 0 THEN
    _msgErro = MtbObterUltimoErro()
    IF CLIP(_msgErro) = '' THEN
       _msgErro = 'Falha ao autenticar na API. Verifique a URL e a chave X-Sync-Key configurada.'
    END
    MESSAGE(CLIP(_msgErro), 'Conexão com a API Web', ICON:CROSS)
    RETURN(FALSE)
 END

 RETURN(TRUE)
```

---

## 5. Fluxo de Execução Completo (Clarion -> DLL -> API)

```
[Clarion 5.5]
   │
   ├─► 1. MtbInicializarAPI(urlBase, chaveSync)
   │      │
   │      └─► [.NET] Instancia HttpClient:
   │                 - BaseAddress: "https://portal.expressoboys.com.br/"
   │                 - DefaultHeader: X-Sync-Key: "c6a1b89f28d844e1..."
   │                 - TLS 1.2 / TLS 1.3 ativo
   │
   ├─► 2. MtbLogin(chaveSync)
   │      │
   │      ├─► [.NET] Executa Sonda (Probe):
   │      │          POST https://portal.expressoboys.com.br/api/sync/empresas
   │      │          Header: X-Sync-Key: "c6a1b89f28d844e1..."
   │      │          Body: {"empresas":[]}
   │      │
   │      ├─► [API PHP] Valida a chave:
   │      │          - Chave correta: HTTP 200 {"sucesso": true, "totalProcessados": 0}
   │      │          - Chave inválida: HTTP 401 {"sucesso": false, "mensagem": "..."}
   │      │
   │      └─► [.NET -> Clarion]:
   │                 - Sucesso (HTTP 200): Retorna 1 (EstaConectado = true)
   │                 - Falha (HTTP 401 / offline): Retorna 0 e preenche MtbObterUltimoErro()
   │
   ├─► 3. MtbEnviarOSLote(jsonOrdens)
   │      │
   │      └─► [.NET] POST api/sync/ordens com envelopamento automático e validação de totalErros
   │
   └─► 4. MtbFinalizar()
          │
          └─► [.NET] Libera o HttpClient e zera instâncias
```

---

## 6. Homologação e Conclusão

* A DLL `CSharpUtil.dll` é compilada como **binário Win32 de 32 bits (`x86`)** via `DllExport` com convenção de chamada `StdCall`, perfeitamente compatível com a convenção `PASCAL,RAW` do **Clarion 5.5**.
* O novo modelo elimina complexidades de tokens de sessão temporários, simplifica a inicialização em uma única chamada (`MtbInicializarAPI`) e assegura a validação imediata da conectividade via probe de `MtbLogin`.
