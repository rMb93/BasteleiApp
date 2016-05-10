using System;
using BasteleiApp.ViewModels;
using NUnit.Framework;

namespace BasteleiApp.Test {
  [TestFixture]
  class TestPasswordEncryption {
    [Test]
    public void CheckEncryption() {
      string mail1 = "Willi@Wühler.com";
      string password1 = "13375P34K";
      string mail2 = "Horst@HaXX0r.com";
      string password2 = "CycaBliat99";
      bool result;
      var test1 = Tools.EncryptPassword(mail1, password1);
      var test2 = Tools.EncryptPassword(mail2, password2);
      result = Tools.PasswordsMatch(test1, test1);
      Assert.AreEqual(true, result);
      result = Tools.PasswordsMatch(test1, test2);
      Assert.AreEqual(false, result);
    }
  }
}
