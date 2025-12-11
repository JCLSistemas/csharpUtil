using System;
using System.Runtime.InteropServices;
using CSharpUtil.Services;
using CSharpUtil.VivaMoto;


namespace CSharpUtil
{
    internal static class CSharpUtil
    {
        [DllExport("ExportPdf", CallingConvention = CallingConvention.StdCall)]
        public static string ExportPdf(string imagesPath, string destinationPath, string password)
        {

            return Pdf.Generate(imagesPath.Trim(), destinationPath.Trim(), password.Trim());
        }

        [DllExport("ExportExcel", CallingConvention = CallingConvention.StdCall)]
        public static string ExportExcel(string fileTxtPath, string destinationPath, string reportName, int excelOpen)
        {
            return new Excel().Generate(fileTxtPath.Trim(), destinationPath.Trim(), reportName.Trim(), excelOpen);
        }

        [DllExport("SendEmail", CallingConvention = CallingConvention.StdCall)]
        public static bool SendEmail(string fromName, string from, string to, string cc, string bcc, string subject,
                                     string body, string attachments, string user, string password, string smtpHost,
                                     int port, int autentication, int enableSsl, int useDefaultCredentials)
        {
            var result = new EmailKit().Send(fromName, from, to, cc, bcc, subject, body, attachments,
                                       user, password, smtpHost, port, autentication, enableSsl, useDefaultCredentials);
            return result;
        }

        [DllExport("NewGuid", CallingConvention = CallingConvention.StdCall)]
        public static string NewGuid()
        {
            return General.NewGuid();
        }

        [DllExport("TextToUtf8", CallingConvention = CallingConvention.StdCall)]
        public static string TextToUtf8(string text)
        {
            return General.TextToUtf8(text);
        }

        [DllExport("Utf8ToText", CallingConvention = CallingConvention.StdCall)]
        public static string Utf8ToText(string text)
        {
            return General.Utf8ToText(text);
        }

        [DllExport("Code128", CallingConvention = CallingConvention.StdCall)]
        public static string Code128(string text, string destinationPath)
        {
            return new Code128().Generate(text, destinationPath);
        }

        [DllExport("CodeInter25", CallingConvention = CallingConvention.StdCall)]
        public static string CodeInter25(string barcode, string destinationPath)
        {
            return new CodeInter25().Generate(barcode, destinationPath);
        }

        [DllExport("QRCode", CallingConvention = CallingConvention.StdCall)]
        public static string CodeQR(string code, string destinationPath)
        {
            return new CodeQR().Generate(code, destinationPath);
        }

        [DllExport("DirectoryExists", CallingConvention = CallingConvention.StdCall)]
        public static bool DirectoryExists(string directoryPath)
        {
            return DosFiles.DirectoryExists(directoryPath);
        }

        [DllExport("DirectoryCreate", CallingConvention = CallingConvention.StdCall)]
        public static bool DirectoryCreate(string directoryPath)
        {
            return DosFiles.DirectoryCreate(directoryPath);
        }

        [DllExport("DirectoryDelete", CallingConvention = CallingConvention.StdCall)]
        public static bool DirectoryDelete(string directoryPath, int recursive)
        {
            return DosFiles.DirectoryDelete(directoryPath, recursive);
        }

        [DllExport("GetFiles", CallingConvention = CallingConvention.StdCall)]
        public static string GetFiles(string topDirectoryPath, string FileToSearch, int allSubDirectories)
        {
            return DosFiles.GetFiles(topDirectoryPath, FileToSearch, allSubDirectories);
        }

        [DllExport("FileExists", CallingConvention = CallingConvention.StdCall)]
        public static bool FileExists(string filePath)
        {
            return DosFiles.FileExists(filePath);
        }

        [DllExport("FileDelete", CallingConvention = CallingConvention.StdCall)]
        public static bool FileDelete(string filePath)
        {
            return DosFiles.FileDelete(filePath);
        }
        [DllExport("GetDirectory", CallingConvention = CallingConvention.StdCall)]
        public static string GetDirectory(string filePath)
        {
            return DosFiles.GetDirectory(filePath);
        }
        [DllExport("GetFileName", CallingConvention = CallingConvention.StdCall)]
        public static string GetFileName(string filePath)
        {
            return DosFiles.GetFileName(filePath);
        }

        [DllExport("ViaCepGetAddressByCep", CallingConvention = CallingConvention.StdCall)]
        public static string ViaCepGetAddressByCep(string CEP)
        {
            return ViaCep.GetAddressbyCep(CEP);
        }

        [DllExport("ViaCepGetCepByAddress", CallingConvention = CallingConvention.StdCall)]
        public static string ViaCepGetCepByAddress(string UF, string Cidade, string Endereco)
        {
            return ViaCep.GetCepByAddress(UF, Cidade, Endereco);
        }

        [DllExport("ConsultarCNPJ", CallingConvention = CallingConvention.StdCall)]
        public static string ConsultarCNPJ(string cnpj)
        {
            return ReceitaWS.ConsultarCNPJ(cnpj);
        }
        [DllExport("ConsultarIBPTProdutos", CallingConvention = CallingConvention.StdCall)]
        public static string ConsultarIBPTProdutos(string _token, string _cnpj, string _NCM, string _uf, string _ex, string _codigoInterno, string _descricaoItem, string _unidadeMedida, string _valor, string _gtin)
        {
            return DeOlhonoImpostoWs.ConsultarIBPTProdutos(_token, _cnpj, _NCM, _uf, _ex, _codigoInterno, _descricaoItem, _unidadeMedida, _valor, _gtin);
        }


        // VivaMoto API Service export
        private static VivaMotoApiService _client;

        [DllExport("MtbInicializarAPI", CallingConvention = CallingConvention.StdCall)]
        public static void MtbInicializarAPI([MarshalAs(UnmanagedType.LPStr)] string urlBase)
        {
            _client = new VivaMotoApiService(urlBase);
        }

        [DllExport("MtbLogin", CallingConvention = CallingConvention.StdCall)]
        public static bool MtbLogin(string usuario, string senha)
        {
            if (_client == null) return false;
            return _client.Login(usuario, senha);
        }

        [DllExport("MtbEnviarOS", CallingConvention = CallingConvention.StdCall)]
        public static bool MtbEnviarOrdem(string jsonOrdem)
        {
            if (_client == null) return false;
            return _client.EnviarOrdem(jsonOrdem);
        }

        [DllExport("MtbEnviarOSLote", CallingConvention = CallingConvention.StdCall)]
        public static int MtbEnviarOrdensLote(string jsonOrdens)
        {
            if (_client == null) return -1;
            return _client.EnviarOrdensLote(jsonOrdens);
        }

        [DllExport("MtbAtualizarStatus", CallingConvention = CallingConvention.StdCall)]
        public static bool MtbAtualizarStatus(string jsonStatus)
        {
            if (_client == null) return false;
            return _client.AtualizarStatus(jsonStatus);
        }

        [DllExport("MtbEnviarEmpresa", CallingConvention = CallingConvention.StdCall)]
        public static bool MtbEnviarEmpresa(string jsonEmpresa)
        {
            if (_client == null) return false;
            return _client.EnviarEmpresa(jsonEmpresa);
        }

        [DllExport("MtbEnviarUsuario", CallingConvention = CallingConvention.StdCall)]
        public static bool MtbEnviarUsuario(string jsonUsuario)
        {
            if (_client == null) return false;
            return _client.EnviarUsuario(jsonUsuario);
        }

        [DllExport("MtbObterUltimoErro", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static string MtbObterUltimoErro()
        {
            if (_client == null) return "Cliente não inicializado";
            return _client.ObterUltimoErro();
        }

        [DllExport("MtbObterToken", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static string MtbObterToken()
        {
            if (_client == null) return "";
            return _client.AuthToken;
        }

        [DllExport("MtbEstaConectado", CallingConvention = CallingConvention.StdCall)]
        public static bool MtbEstaConectado()
        {
            if (_client == null) return false;
            return _client.EstaConectado;
        }

        [DllExport("MtbFinalizar", CallingConvention = CallingConvention.StdCall)]
        public static void MtbFinalizar()
        {
            if (_client != null)
            {
                _client.Finalizar();
                _client = null;
            }
        }
    }
}