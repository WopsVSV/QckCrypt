using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QckCrypt.Library
{
    /// <summary>
    /// Describes the type of the item added
    /// </summary>
    public enum ListItemType
    {
        Folder,
        File
    }

    /// <summary>
    /// Describes the type of the file
    /// </summary>
    public enum CryptStatus
    {
        Encrypted,
        Unencrypted,
        Error,
        Done
    }

    /// <summary>
    /// Describes the type of crypter which needs to be created
    /// </summary>
    public enum CryptorType
    {
        Encryptor,
        Decryptor
    }

    /// <summary>
    /// Describes the result of the crypting
    /// </summary>
    public enum CryptResult
    {
        Success = 1,
        IOFail = 2,
        CryptFail = 4,
        UnknownFail = 8
    }
}
