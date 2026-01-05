# Sistema de Logging VivaMoto API

## Descrição

Sistema de logging detalhado implementado no `VivaMotoApiService` para debug e diagnóstico de problemas com a API.

## Funcionalidades

### 1. Logging Automático
- Grava logs na pasta `\Log` dentro do diretório da DLL
- Três tipos de arquivos de log:
  - **VivaMoto_Debug_YYYYMMDD.log** - Logs gerais de debug
  - **VivaMoto_HTTP_YYYYMMDD.log** - Detalhes completos de todas as requisições HTTP

### 2. Informações Registradas

Para cada requisição HTTP, o sistema registra:
- **Request Headers** (incluindo Content-Type, Authorization)
- **Request Body** (JSON completo enviado)
- **Response Status** (código HTTP e mensagem)
- **Response Headers** (incluindo Content-Type do servidor)
- **Response Body** (resposta completa do servidor)

## Como Usar

### Ativando o Debug

```clarion
! No seu código Clarion, após criar a instância:
api &= NEW VivaMotoApiService('https://vivamoto.onrender.com')

! Ativar debug (1 = ativo, 0 = inativo)
api.ConfigurarDebug(1)

! Fazer login
resultado = api.Login('seu@email.com', 'senha')

! Enviar ordem
resultado = api.EnviarOrdem(jsonOrdem)

! Desativar debug quando não precisar mais
api.ConfigurarDebug(0)
```

### Localizando os Arquivos de Log

Os arquivos de log são salvos em:
```
[Pasta da DLL]\Log\VivaMoto_Debug_20241215.log
[Pasta da DLL]\Log\VivaMoto_HTTP_20241215.log
```

Exemplo: Se sua DLL está em `C:\Sistema\bin\`, os logs estarão em:
```
C:\Sistema\bin\Log\VivaMoto_Debug_20241215.log
C:\Sistema\bin\Log\VivaMoto_HTTP_20241215.log
```

## Exemplo de Log HTTP

```
[2024-12-15 14:30:45.123] ========== HTTP REQUEST ==========
[2024-12-15 14:30:45.123] POST https://vivamoto.onrender.com/api/v1/sync/ordens
[2024-12-15 14:30:45.123] --- Request Headers ---
[2024-12-15 14:30:45.123] Accept: application/json
[2024-12-15 14:30:45.123] Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
[2024-12-15 14:30:45.123] --- Request Body ---
[2024-12-15 14:30:45.123] {"Ordens":[{"NumeroOrdem":"12345","Cliente":"ACME Corp",...}]}
[2024-12-15 14:30:45.123] --- Response Status ---
[2024-12-15 14:30:45.123] 400 (Bad Request)
[2024-12-15 14:30:45.123] --- Response Headers ---
[2024-12-15 14:30:45.123] Content-Type: application/json; charset=utf-8
[2024-12-15 14:30:45.123] Date: Sun, 15 Dec 2024 17:30:45 GMT
[2024-12-15 14:30:45.123] --- Response Body ---
[2024-12-15 14:30:45.123] {"Sucesso":false,"Mensagem":"Campo obrigatório ausente","Erros":["O campo 'DataCriacao' é obrigatório"]}
[2024-12-15 14:30:45.123] ==================================
```

## Verificando o Content-Type

Para verificar se o `Content-Type: application/json; charset=utf-8` está sendo enviado corretamente:

1. Ative o debug: `api.ConfigurarDebug(1)`
2. Execute a operação que está dando erro 400
3. Abra o arquivo `VivaMoto_HTTP_YYYYMMDD.log`
4. Procure pela seção "Request Headers"
5. Verifique se aparece: `Content-Type: application/json; charset=utf-8`

## Dicas de Diagnóstico

### Erro 400 (Bad Request)
1. Ative o debug
2. Compare o JSON enviado (Request Body) com o formato esperado pela API
3. Verifique no Response Body qual campo está causando o erro
4. Confira se todos os campos obrigatórios estão presentes

### Erro 401 (Unauthorized)
1. Verifique se o Login foi executado com sucesso
2. Confira se o header `Authorization: Bearer [token]` está presente

### Erro 500 (Internal Server Error)
1. Verifique o Response Body para detalhes do erro do servidor
2. Contate o suporte da API com o log completo

## Importante

?? **Desative o debug em produção** após resolver os problemas, pois:
- Grava informações sensíveis (tokens, dados de clientes)
- Pode ocupar muito espaço em disco com alto volume de requisições
- Pode impactar performance em ambientes com muitas operações

## Limpeza de Logs

Os logs são salvos por dia. Você pode:
- Deletar manualmente arquivos antigos da pasta `\Log`
- Criar rotina automática para limpar logs com mais de X dias
