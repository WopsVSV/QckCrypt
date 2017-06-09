using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QckCrypt.Library
{
    public static class Utility
    {
        /// <summary>
        /// Gets the data extension
        /// </summary>
        public static string GetExtension(this string fileName)
        {
            string extension;

            extension = fileName.Split('.')[fileName.Split('.').Length - 1].ToUpper();

            if (extension.Length > 3)
                extension = extension.Substring(0, 3);

            return extension;
        }

        /// <summary>
        /// Evaluates the crypt results and shows an adequate message
        /// </summary>
        public static string GetResultText(CryptResult result)
        {
            switch (result)
            {
                case CryptResult.CryptFail:
                    return "The encrypt/decrypt process has failed because of a wrong key.";
                case CryptResult.IOFail:
                    return "The encrypt/decrypt process has failed because of an IOException.\n(While writing/reading from a file)";
                case CryptResult.UnknownFail:
                    return "The encrypt/decrypt process has failed because of an unknown exception.";
            }
            return string.Empty;
        }

        /// <summary>
        /// Parses the exception given and returns a result
        /// </summary>
        public static CryptResult ParseException(Exception ex)
        {
            if (ex is System.Security.Cryptography.CryptographicException)
                return CryptResult.CryptFail;
            else if (ex is System.IO.IOException)
                return CryptResult.IOFail;
            else return CryptResult.UnknownFail;
        }

        /// <summary>
        /// Gets a random name with a specified length
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private const string ALPHANUMERICSTRING = "ABCDEFGHJKLMNOPQRSTUVXYZWabcdefghijklmnopqrstuvxyzw0123456789";
        private static Random random;
        public static string GetRandomName(int length)
        {
            if (random == null) random = new Random();

            string retVal = string.Empty;
            for (int i = 0; i < length; i++)
                retVal += ALPHANUMERICSTRING[random.Next(0, ALPHANUMERICSTRING.Length)];

            return retVal;
        }

        /// <summary>
        /// Gets a randomly-named file in the same path and with the same extension
        /// </summary>
        public static string GetEncryptedFilePath(string originalFilePath, int length)
        {
            // Limit the length to 16
            if (length > 16)
                length = 16;

            return Path.GetDirectoryName(Path.GetFullPath(originalFilePath)) + Path.DirectorySeparatorChar + GetRandomName(length) + Path.GetExtension(originalFilePath);
        }

        /// <summary>
        /// Checks if the file is crypted or not
        /// </summary>
        public static CryptStatus GetCryptStatus(string filePath)
        {
            try
            {
                using (FileStream source = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    byte[] bytes = new byte[Crypter.PREFIX.Length];
                    source.Read(bytes, 0, Crypter.PREFIX.Length);
                    if (Encoding.UTF8.GetString(bytes) == Crypter.PREFIX)
                        return CryptStatus.Encrypted;
                    else
                        return CryptStatus.Unencrypted;
                }
            }
            catch (Exception)
            {
                return CryptStatus.Error; // yes I know bad status }
            }

        }
    }
}
