using BasteleiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasteleiApp.Repositories {
  interface IUserRepository : IRepository<User>{

    void RegisterUser(string name, string surname, string mail, string password);
  }
}
