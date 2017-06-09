using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QckCrypt.Library
{
    public class Structs
    {
        /// <summary>
        /// Used to define the decryption info, needed in the DecryptFile method
        /// </summary>
        public struct DecryptInfo
        {
            public bool IsNameEncrypted { get; private set; }
            public string OriginalName { get; private set; }
            public byte[] PrefixBytes { get; set; } // Use this as the scapegoat for reading the prefix bytes :(

            /// <summary>
            /// Creates a new DecryptInfo with the specified properties
            /// </summary>
            public DecryptInfo(bool isNameEncrypted, string originalName, int prefixBytesLength)
            {
                IsNameEncrypted = isNameEncrypted;
                OriginalName = originalName;
                PrefixBytes = new byte[prefixBytesLength];
            }
            public DecryptInfo(bool isNameEncrypted)
            {
                IsNameEncrypted = isNameEncrypted;
                OriginalName = string.Empty;
                PrefixBytes = new byte[0];
            }
        }
    }
}
