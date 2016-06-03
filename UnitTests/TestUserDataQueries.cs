using System;
using BasteleiApp.ViewModels;
using NUnit.Framework;
using BasteleiApp.Repositories;
using BasteleiApp.Models;

namespace BasteleiApp.Test {
  [TestFixture]
  class TestUserDataQueries {

    private string _name = "test";
    private string _surname = "tester";
    private string _mail = "test@tester.com";
    private string _password = "tester";

    private RegisterUserViewModel InstatiateRegisterUserVM() {
      RegisterUserViewModel registerUserVM = new RegisterUserViewModel();
      registerUserVM.Name = _name;
      registerUserVM.Surname = _surname;
      registerUserVM.MailAdress = _mail;
      registerUserVM.PasswordOne = _password;
      return registerUserVM;
    }

    [Test]
    public void CheckGetUserName() {
      var unitOfWork = new UnitOfWork(new bastelei_ws());
      string name = unitOfWork.Users.GetName(_mail);

      Assert.AreEqual(name, _name);
    }

    [Test]
    public void CheckGetPassword() {
      var unitOfWork = new UnitOfWork(new bastelei_ws());
      string psw = unitOfWork.Users.GetPassword(_mail);

      Assert.AreEqual(psw, Tools.EncryptPassword(_mail,_password));
    }
  }
}
