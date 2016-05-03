using BasteleiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BasteleiApp.Repositories {
  class UserRepository : Repository<User>, IUserRepository {

    public bastelei_ws BasteleiContext
    {
      get
      {
        return Context as bastelei_ws;
      }
    }

    public UserRepository(DbContext context) : base(context) {

    }

    public void AddUser(string pName, string pSurname, string pMail, string pPassword) {
      User newUser = new User {
        name = pName,
        surname = pSurname,
        mailadress = pMail,
        password = pPassword,
        privilege = 1       
      };
      BasteleiContext.User.Add(newUser);
    }

    public string GetPassword(string mail) {
      var query = from u in BasteleiContext.User
                  where u.mailadress == mail
                  select u.password;
      return query.First<string>();
    }

    public string GetName (string mail) {
      var query = from u in BasteleiContext.User
                  where u.mailadress == mail
                  select u.name;
      return query.First<string>();
    }

    public bool MailExists(string mail) {
      var query = from u in BasteleiContext.User
                  where u.mailadress == mail
                  select u.mailadress;
      if(query.Any()) {
        return true;
      }
      return false;
    }
  }
}
