using CSharpUtil.Validation;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace CSharpUtil.Services
{
    public class CodeQR
    {
        public string Generate(string content, string destinationPath)
        {
            try
            {
                AssertConsern.AssertArgumentValidateFileName(ref destinationPath, "QRCOde", ".png",
                                            "Nome do QRCode inválido!", "Geração do Código QRCode");

                //BarcodeQRCode qrcode = new BarcodeQRCode(content, 100, 100, null);

                //iTextSharp.text.Image imgQrCode = qrcode.GetImage();

                //FileStream fs = new FileStream(
                ////Image img = new Image();

                ////qrcode.CreateDrawingImage(Color.Black, Color.White);
                //img = (new Bitmap(img, new Size(800, 150)));
                //img.Save(destinationPath.Trim(), img.Jpeg);
                //return destinationPath.Trim();


                QRCodeGenerator qrcodeGenerator = new QRCodeGenerator();
                QRCodeData qrcodeData = qrcodeGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
                QRCode qrcode = new QRCode(qrcodeData);

                Image qrcodeimg = qrcode.GetGraphic(4);
                qrcodeimg.Save(destinationPath.Trim(), ImageFormat.Jpeg);               
                

                return destinationPath.Trim();
            }
            catch (Exception ex)
            {
                LogService.Add(ex.Message);
                MessageBox.Show(ex.Message, "CodeQR");
                return "";
            }
        }
    }
}
