using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace CompanyWebsite.Models {
	public class DatabaseAccess {

		public static DataTable SelectQuery(string query) {
			string connString = ConfigurationManager.ConnectionStrings["mysqlconnection"].ConnectionString;
			using(MySqlConnection conn = new MySqlConnection(connString)) {
				using(MySqlCommand cmd = new MySqlCommand(query)) {
					using(MySqlDataAdapter adapter = new MySqlDataAdapter()) {
						cmd.Connection = conn;
						adapter.SelectCommand = cmd;
						DataTable dt = new DataTable();
						adapter.Fill(dt);
						return dt;
					}
				}
			}
		}

	}
}