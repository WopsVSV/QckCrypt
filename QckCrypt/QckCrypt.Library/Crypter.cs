using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static QckCrypt.Library.Structs;

namespace QckCrypt.Library
{
    public class Crypter
    {
        /// <summary>
        /// For handling the settings of the encryption
        /// </summary>
        private AESHandler aesHandler;

        /// <summary>
        /// The password field updates the AES Handler password when modified
        /// </summary>
        private string password;
        public string Password {
            set {
                password = value;
                if (aesHandler.Password != password)
                    aesHandler.Password = password;
            }
        }
        public int EncryptedNameLength { get; set; } = 8;

        // The prefix is so the program detects the status of the file (encrypted/decrypted)
        public const string PREFIX = "[QCK]";

        /// <summary>
        /// Creates a new instance of the AesHandler class for usage in decryption and encryption
        /// </summary>
        public Crypter(string password)
        {
            aesHandler = new AESHandler(password);
            Password = password;
        }

        /// <summary>Decrypt a file.</summary>
        /// <param name="sourceFilename">The full path and name of the file to be decrypted.</param>
        public CryptResult DecryptFile(string sourceFilename)
        {
            DecryptInfo info = GetDecryptInfo(sourceFilename);
            string destinationFilename = GetDestinationFilename(sourceFilename, info);

            ICryptoTransform transform = aesHandler.Decryptor;
 
            using (FileStream destination = new FileStream(destinationFilename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None)) {
                try
                {
                    using (CryptoStream cryptoStream = new CryptoStream(destination, transform, CryptoStreamMode.Write)) {
                        using (FileStream source = new FileStream(sourceFilename, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                            source.Read(info.PrefixBytes, 0, info.PrefixBytes.Length);
                            source.CopyTo(cryptoStream);
                        }
                    }
                }
                catch (Exception ex) {
                    // Something went wrong, abort mission
                    destination.Close();
                    File.Delete(destinationFilename);
                    return Utility.ParseException(ex);
                }
            }

            try { File.Delete(sourceFilename); } catch (IOException) { return CryptResult.IOFail; }

            // Attemps copying the temp file to the original path
            if (!info.IsNameEncrypted)
            { 
                try { File.Delete(destinationFilename); } catch (IOException) { return CryptResult.IOFail; }
                return CopyTempToOriginal(destinationFilename, sourceFilename);
            }
          
            return CryptResult.Success;
        }

        /// <summary>Encrypt a file.</summary>
        /// <param name="sourceFilename">The full path and name of the file to be encrypted.</param>
        public CryptResult EncryptFile(string sourceFilename, bool shouldEncryptName)
        {
            string destinationFilename = GetDestinationFilename(sourceFilename, shouldEncryptName);
            byte[] prefixBytes = GetPrefixBytes(shouldEncryptName, sourceFilename);

            try
            {
                ICryptoTransform transform = aesHandler.Encryptor;

                using (FileStream destination = new FileStream(destinationFilename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None)) {

                    // Writes the prefix bytes so the program will recognise the encrypted file
                    destination.Write(prefixBytes, 0, prefixBytes.Length);

                    using (CryptoStream cryptoStream = new CryptoStream(destination, transform, CryptoStreamMode.Write)) {
                        using (FileStream source = new FileStream(sourceFilename, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                            source.CopyTo(cryptoStream);
                        }
                    }

                }

                // Remove the original file (happens in both cases)
                try { File.Delete(sourceFilename); } catch (IOException) { return CryptResult.IOFail; }

                // Attemps copying the temp file to the original path
                if (!shouldEncryptName)
                    return CopyTempToOriginal(destinationFilename, sourceFilename);

                return CryptResult.Success;
            }
            catch (Exception ex) { return Utility.ParseException(ex); }
        }

        /// <summary>
        /// Gets the prefix byte array based on whether or not the user chooses to encrypt the name
        /// </summary>
        private byte[] GetPrefixBytes(bool shouldEncryptName, string filePath)
        {
            byte[] prefixBytes;

            if (shouldEncryptName)
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                prefixBytes = Encoding.UTF8.GetBytes(
                                    string.Format("{0}[FN={1}]{2}", PREFIX, fileName.Length, fileName));
            }
            else
            {
                prefixBytes = Encoding.UTF8.GetBytes(PREFIX);
            }

            return prefixBytes;
        }

        /// <summary>
        /// Copies the temp file to the original path, if the name didn't get encrypted
        /// </summary>
        private CryptResult CopyTempToOriginal(string tempPath, string originalPath)
        {
            try
            {
                using (FileStream destination = new FileStream(originalPath, FileMode.CreateNew, FileAccess.Write, FileShare.None)) {
                    using (FileStream source = new FileStream(tempPath, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                        source.CopyTo(destination);
                    }
                }
                return CryptResult.Success;
            }
            catch { return CryptResult.IOFail; }
        }

        /// <summary>
        /// Gets the destination file path based on whether or not the user chooses to encrypt the name
        /// Gets the destination file path based on whether or not the file name was encrypted
        /// </summary>
        private string GetDestinationFilename(string sourceFile, bool shouldEncryptName)
        {
            if (shouldEncryptName) // If the name is encrypted, just write in the original directory with the random name
                return  Utility.GetEncryptedFilePath(sourceFile, EncryptedNameLength);
            else // If the name shouldn't be encrypted, write in a temp file then copy to the original path
                return Path.GetTempFileName();
        }
        private string GetDestinationFilename(string sourceFilename, DecryptInfo info)
        {
            if (info.IsNameEncrypted)
                return Path.GetDirectoryName(Path.GetFullPath(sourceFilename)) + Path.DirectorySeparatorChar + info.OriginalName + Path.GetExtension(sourceFilename);
            else
                return Path.GetTempFileName();
        }

        /// <summary>
        /// Gets the decrypt info for the specified file
        /// </summary>
        private DecryptInfo GetDecryptInfo(string sourceFilename)
        {
            byte[] testBytes = new byte[48];
            string test;
            string originalName;
            int nameLength;
            int toReadLength;

            using (FileStream source = new FileStream(sourceFilename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                source.Read(testBytes, 0, 48);
            }
            test = Encoding.UTF8.GetString(testBytes);

            if (!test.Contains("[FN=")) // Prefix data doesn't contain encrypted name information
                return new DecryptInfo(false);

            test = test.Split('[')[2].Split(']')[0].Replace("FN=", string.Empty);

            nameLength = int.Parse(test);
            toReadLength = 7 + nameLength + (PREFIX.Length - 2) + nameLength.ToString().Length;

            byte[] prefixBytes = new byte[toReadLength];
            byte[] toRead = new byte[toReadLength];
            string toReadString;
            using (FileStream source = new FileStream(sourceFilename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                source.Read(toRead, 0, toReadLength);
            }
            toReadString = Encoding.UTF8.GetString(toRead);

            originalName = toReadString.Split(']')[2];

            return new DecryptInfo(true, originalName, prefixBytes.Length);
        }
    }
}
