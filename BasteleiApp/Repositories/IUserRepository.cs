using BasteleiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasteleiApp.Repositories {
  interface IUserRepository : IRepository<User>{

    void AddUser(string name, string surname, string mail, string password);

    string GetPassword(string name);

    string GetName(string mail);

    int GetUserRights(string mail);

    bool MailExists(string mail);
  }
}
