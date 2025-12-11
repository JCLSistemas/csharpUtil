using System;
using System.IO;
using System.Windows.Forms;

namespace CSharpUtil.Validation
{
    public class AssertConsern
    {
        private static string _prefixCaption = "Utilities - ";
        public static bool AssertArgumentIsNullorEmpty(object object1, string message, string caption)
        {
            if (object1 == null || string.IsNullOrEmpty(object1.ToString()))
            {
                MessageBox.Show(message, string.Concat(_prefixCaption, caption), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        public static bool AssertArgumentIsNullorEmpty(object[] object1, string message, string caption)
        {
            if (string.IsNullOrEmpty(object1.ToString()))
            {
                MessageBox.Show(message, string.Concat(_prefixCaption, caption), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        public static bool AssertArgumentValidateFileName(ref string fileName, string prefix, string extension, string message,
            string caption)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                MessageBox.Show(message, string.Concat(_prefixCaption, caption), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (fileName.IndexOfAny(Path.GetInvalidPathChars()) > 0)
            {
                MessageBox.Show(message, string.Concat(_prefixCaption, caption), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

           if (!Path.HasExtension(fileName)) fileName = fileName + @"\";
            
            string newFileName = Path.GetFileName(fileName);

            if (string.IsNullOrEmpty(newFileName))
            {
                newFileName = string.Concat(prefix,"-",DateTime.Now.ToString("yyyyMMdd-HHmmss-fff"), extension);
                fileName = string.Concat(fileName.Trim(), newFileName.Trim());
            }

            string newDirectoryName = string.Concat(Path.GetDirectoryName(fileName), @"\");
            if (!Directory.Exists(newDirectoryName)) Directory.CreateDirectory(newDirectoryName);
           
            return true;
        }
    }
}