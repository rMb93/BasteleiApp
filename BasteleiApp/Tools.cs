using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Security.Cryptography;

namespace BasteleiApp {
  public static class Tools {

    #region Methods

    public static string EncryptPassword(string mail, string password) {
      string tmpPassword = mail.ToLower() + password;
      //Convert the password string into an Array of bytes.
      UTF8Encoding textConverter = new UTF8Encoding();
      byte[] passBytes = textConverter.GetBytes(tmpPassword);
      byte[] hashed = new MD5CryptoServiceProvider().ComputeHash(passBytes);      
      return Convert.ToBase64String(hashed);
    }
    
    public static bool PasswordsMatch(string psswd1, string psswd2) {
      byte[] bpsw1 = Convert.FromBase64String(psswd1);
      byte[] bpsw2 = Convert.FromBase64String(psswd2);
      try {
        for (int i = 0; i < bpsw1.Length; i++) {
          if (bpsw1[i] != bpsw2[i])
            return false;
        }
        return true;
      }
      catch (IndexOutOfRangeException) {
        return false;
      }
    }

    #endregion //Methods

  }
}
