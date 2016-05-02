using System;
using BasteleiApp.ViewModels;
using NUnit.Framework;
using BasteleiApp.Repositories;
using BasteleiApp.Models;

namespace BasteleiApp.Test {
  [TestFixture]
  class TestUserDataQueries {

    private string _name = "Peter";
    private string _surname = "Wackel";
    private string _mail = "Peter@Wackel.com";
    private string _password = "PeterWackelt123";

    private RegisterUserViewModel InstatiateRegisterUserVM() {
      RegisterUserViewModel registerUserVM = new RegisterUserViewModel();
      registerUserVM.Name = _name;
      registerUserVM.Surname = _surname;
      registerUserVM.MailAdress = _mail;
      registerUserVM.Password = _password;
      return registerUserVM;
    }

    [Test]
    public void CheckGetUserName() {
      RegisterUserViewModel registerUserVM = InstatiateRegisterUserVM();
      registerUserVM.Register();

      var unitOfWork = new UnitOfWork(new bastelei_ws());
      string name = unitOfWork.Users.GetName(_mail);

      Assert.AreEqual(name, _name);
    }

    [Test]
    public void CheckGetPassword() {
      RegisterUserViewModel registerUserVM = InstatiateRegisterUserVM();
      registerUserVM.Register();

      var unitOfWork = new UnitOfWork(new bastelei_ws());
      string psw = unitOfWork.Users.GetPassword(_mail);

      Assert.AreEqual(psw, _password);
    }
  }
}
