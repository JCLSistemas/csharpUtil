using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using CSharpUtil.Validation;
using iTextSharp.text.pdf;
using Image = System.Drawing.Image;

namespace CSharpUtil.Services
{
    public class CodeInter25
    {
        public string Generate(string text, string destinationPath)
        {
            try
            {
                AssertConsern.AssertArgumentValidateFileName(ref destinationPath, "CodeI25", ".jpg",
                "Nome do Codigo de barras invalido!", "Geração do Codigo de Barras CodeInter25");
                string pathImage = destinationPath.Trim();
                BarcodeInter25 codeI25 = new BarcodeInter25
                {
                    Extended = true,
                    //GenerateChecksum = true,
                    ChecksumText = true,
                    BarHeight = 70,
                    Size = 100,
                    Baseline = 10,
                    Code = text
                };
                Image img = codeI25.CreateDrawingImage(Color.White, Color.Black);
                img = (new Bitmap(img, new Size(800, 100)));
                img.Save(pathImage.Trim(), ImageFormat.Jpeg);
                return pathImage.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Code Inter 2&5");
                return "";
            }
           
        }
    }
}
