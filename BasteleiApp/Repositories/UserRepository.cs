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

    public void RegisterUser(string pName, string pSurname, string pMail, string pPassword) {
      User newUser = new User {
        name = pName,
        surname = pSurname,
        mailadress = pMail,
        password = pPassword       
      };
      BasteleiContext.User.Add(newUser);
    }
  }
}
