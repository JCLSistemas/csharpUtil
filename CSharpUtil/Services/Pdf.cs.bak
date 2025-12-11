using CSharpUtil.Validation;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Image = iTextSharp.text.Image;


namespace CSharpUtil.Services
{
    public static class Pdf
    {
        public static string Generate(string imagesPath, string destinationPath, int landscape, int pdfOpen)
        {
            try
            {
                if (!AssertConsern.AssertArgumentIsNullorEmpty(imagesPath,
                    "informe os arquivos das imagens para geração do pdf", "Geração do PDF"))
                {
                    return null;
                }

                if (!AssertConsern.AssertArgumentValidateFileName(ref destinationPath, "PDF", ".PDF",
                    "O nome do arquívo é inválido! Modifique o nome do arquivo e tente novamente!", "Geração de PDF"))
                {
                    return null;
                }

                var pathImages = imagesPath.Split(';').ToArray();
                using (var pdfFile = new FileStream(destinationPath, FileMode.Create, FileAccess.ReadWrite))
                {
                    using (var pdfDocument = new Document(Image.GetInstance(pathImages.FirstOrDefault())))
                    {
                        using (PdfWriter.GetInstance(pdfDocument, pdfFile))
                        {
                            pdfDocument.Open();
                            foreach (var pathImage in pathImages)
                            {
                                if (!File.Exists(pathImage.Trim())) continue;
                                pdfDocument.NewPage();
                                Image image = Image.GetInstance(pathImage);
                                image.SetAbsolutePosition(0, 0);
                                pdfDocument.Add(image);
                            }
                            pdfDocument.Close();
                            //OpenDocument(destinationPath, pdfOpen);
                            return destinationPath;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Geração PDF");
                return "";
            }
        }

        private static void OpenDocument(string destinationPath, int pdfOpen)
        {
            if (pdfOpen == 1) Process.Start(destinationPath);
        }
    }
}