using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BasteleiApp.Models {
  class BaseModel {

    #region Fields

    #endregion //Fields

    #region Properties

    #endregion //Properties

    #region Constructors

    #endregion //Constructors

    #region Methods

    protected void CreateDbConnection() {
      string myConnectionString = "SERVER=server3.myadeska.de;" +
                            "DATABASE=bastelei_ws;" +
                            "UID=bastelei;" +
                            "PASSWORD=tYQgfpdtskEdCMLozkMf;";

      MySqlConnection connection = new MySqlConnection(myConnectionString);
      MySqlCommand command = connection.CreateCommand();
      command.CommandText = "SELECT * FROM probes";
      MySqlDataReader Reader;
      connection.Open();
      Reader = command.ExecuteReader();
      while (Reader.Read()) {
        string row = "";
        for (int i = 0; i < Reader.FieldCount; i++)
          row += Reader.GetValue(i).ToString() + ", ";
        Console.WriteLine(row);
      }
      connection.Close();
    }

    #endregion //Methods

  }
}
