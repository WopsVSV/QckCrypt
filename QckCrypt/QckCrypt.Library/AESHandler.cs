using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QckCrypt.Library
{
    /// <summary>
    /// Handles the AesManaged class
    /// </summary>
    public class AESHandler
    {
        private const int iterations = 1042;
        private byte[] salt;
        private string password;
        private Rfc2898DeriveBytes key;

        /// <summary>
        /// Changes the AES properties on password change
        /// </summary>
        public string Password {
            get { return password; }
            set {
                password = value;
                SetAesKey(password);
                CreateTransforms();
            }
        }

        /// <summary>
        /// Properties, so lovely!
        /// </summary>
        public AesManaged AES { get; private set; }
        public ICryptoTransform Encryptor { get; private set; }
        public ICryptoTransform Decryptor { get; private set; }

        /// <summary>
        /// Creates a new AesManaged object and sets its properties
        /// </summary>
        /// <param name="password">The user-given password</param>
        public AESHandler(string password)
        {
            // Predefined salt
            salt = new byte[] { 0x20, 0x14, 0x15, 0x13, 0x35, 0x22, 0x11, 0x07 };

            AES = new AesManaged();
            AES.BlockSize = AES.LegalBlockSizes[0].MaxSize;
            AES.KeySize = AES.LegalKeySizes[0].MaxSize;

            SetAesKey(password);
            CreateTransforms();
        }

        /// <summary>
        /// Changes the AES key and initialization vector
        /// </summary>
        /// <param name="password">The user-given password</param>
        private void SetAesKey(string password)
        {
            key = new Rfc2898DeriveBytes(password, salt, iterations);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Mode = CipherMode.CBC;
        }

        /// <summary>
        /// Creates both transforms
        /// </summary>
        private void CreateTransforms()
        {
            Decryptor = GetTransform(CryptorType.Decryptor);
            Encryptor = GetTransform(CryptorType.Encryptor);
        }

        /// <summary>
        /// Creates a new cryptor based on the type given
        /// </summary>
        private ICryptoTransform GetTransform(CryptorType type)
        {
            switch(type)
            {
                case CryptorType.Decryptor:
                    return AES.CreateDecryptor(AES.Key, AES.IV);
                case CryptorType.Encryptor:
                    return AES.CreateEncryptor(AES.Key, AES.IV);
                default:
                    throw new NotImplementedException("What the fuck happened here?");
            }
        }
    }
}
