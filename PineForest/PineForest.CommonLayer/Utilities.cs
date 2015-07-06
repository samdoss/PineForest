using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace PineForest.CommonLayer
{
  [Serializable()]
  public class Utilities
  {
    #region Encrypt and Decrypt

    public string EncryptText(string strText)
    {
      return Encrypt(strText, "&%#@?,:*");
    }
    public string DecryptText(string strText)
    {
      return Decrypt(strText, "&%#@?,:*");
    }

    //The function used to encrypt the text
    private static string Encrypt(string strText, string strEncrKey)
    {
      byte[] byKey = { };
      byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };

      try
      {
        byKey = System.Text.Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));

        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        byte[] inputByteArray = Encoding.UTF8.GetBytes(strText);
        MemoryStream ms = new MemoryStream();
        CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
        cs.Write(inputByteArray, 0, inputByteArray.Length);
        cs.FlushFinalBlock();
        return Convert.ToBase64String(ms.ToArray());
      }

      catch (Exception ex)
      {
        return ex.Message;
      }

    }

    //The function used to decrypt the text
    private static string Decrypt(string strText, string sDecrKey)
    {
      byte[] byKey = { };
      byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
      byte[] inputByteArray = new byte[strText.Length + 1];

      try
      {
        byKey = System.Text.Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 8));
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        inputByteArray = Convert.FromBase64String(strText);
        MemoryStream ms = new MemoryStream();
        CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);

        cs.Write(inputByteArray, 0, inputByteArray.Length);
        cs.FlushFinalBlock();
        System.Text.Encoding encoding = System.Text.Encoding.UTF8;

        return encoding.GetString(ms.ToArray());
      }

      catch (Exception ex)
      {
        return ex.Message;
      }

    }

    #endregion
  }
}

