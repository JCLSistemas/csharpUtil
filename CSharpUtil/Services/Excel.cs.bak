using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OfficeOpenXml;

namespace CSharpUtil.Services
{
    public class Excel
    {
        private string _destinationPath;
        private string _filePath;
        private string _reportName;

        public string Generate(string filePath, string destinationPath, string reportName, int excelOpen)
        {
            try
            {
                if (!string.IsNullOrEmpty(Path.GetFileName(filePath)))
                {
                    if (Path.GetInvalidPathChars()
                            .Any(character => Path.GetFileName(filePath).Contains(character.ToString())) ||
                        Path.GetInvalidPathChars()
                            .Any(character => Path.GetFullPath(filePath).Contains(character.ToString())))
                    {
                        return "Existem caracteres inválidos no path do arquivo, verifique e tente novamente.";
                    }
                }
                if (!string.IsNullOrEmpty(Path.GetFileName(filePath)) && !File.Exists(filePath))
                {
                    return "Arquivo não encontrado, Verifique o caminho do arquivo e tente novamente.";
                }
                if (Path.HasExtension(destinationPath))
                {
                    var extension = Path.GetExtension(destinationPath);
                    destinationPath = destinationPath.Replace(extension, "");
                }
                _reportName = reportName;
                _filePath = filePath;
                _destinationPath = string.Concat(destinationPath, "_", DateTime.Now.ToString("yyyy-MM-dd-hh;mm;ss"), ".xlsx");

                if (ExcelGenerate() == false)
                {
                    throw new Exception("Não foi possivel gerar a planilha excel, verifique o erro e tente novamente.");
                }

                if (excelOpen == 1)
                {
                    var startInfo = new ProcessStartInfo { FileName = "Excel.exe", Arguments = string.Concat(Chr(34), _destinationPath, Chr(34)) };
                    MessageBox.Show(_destinationPath);
                    Process.Start(startInfo);
                }
                return _destinationPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        private bool ExcelGenerate()
        {
            try
            {
                var package = new ExcelPackage(new FileInfo(_destinationPath));
                var sheet = package.Workbook.Worksheets.Add(_reportName);

                //Create the format object to describe the text file
                var format = new ExcelTextFormat
                {
                    Delimiter = '\t', //Tab
                    SkipLinesBeginning = 0,
                    SkipLinesEnd = 0,
                    Encoding = Encoding.ASCII,
                    //Use your choice of Culture
                    Culture = new CultureInfo("pt-BR") { NumberFormat = { NumberDecimalSeparator = "," } } //Decimal is comma 
                };

                //Now read the file into the sheet.
                //sheet.Cells["A1"].LoadFromText(new FileInfo(_filePath), format);
                sheet.Cells["A1"].LoadFromText(new FileInfo(_filePath), format);

                package.Save();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        private string Chr(int codigo)
        {
            var chr = (char)codigo;
            return chr.ToString();
        }
    }
}