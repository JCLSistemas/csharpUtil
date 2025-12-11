using System;
using iTextSharp.text.pdf;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using CSharpUtil.Validation;

namespace CSharpUtil.Services
{
    public class Code128
    {
        public string Generate(string code, string destinationPath)
        {
            try
            {
                AssertConsern.AssertArgumentValidateFileName(ref destinationPath, "Code128", ".jpg",
                         "Nome do Codigo de barras invalido!", "Geração do Codigo de Barras Code128");

                string pathImage = destinationPath;
                Barcode128 code128 = new Barcode128
                {
                    Extended = true,
                    CodeType = Barcode.CODE128_RAW,
                    ChecksumText = true,
                    StartStopText = false,
                    GenerateChecksum = true,
                    BarHeight = 100,
                    Size = 200,
                    Baseline = 20,
                    Code = Barcode128.GetRawText(code, true, Barcode128.Barcode128CodeSet.C)
                };

                Image img = code128.CreateDrawingImage(Color.Black, Color.White);
                img = (new Bitmap(img, new Size(800, 150)));
                img.Save(pathImage.Trim(), ImageFormat.Jpeg);
                return pathImage.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Code128");
                return "";
            }
        }
    }
}
