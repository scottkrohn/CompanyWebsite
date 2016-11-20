using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.Script.Serialization;

namespace CompanyWebsite.Controllers {
	public class HomeController : Controller {

		public ActionResult Index() {
			return View();
		}

		public ActionResult EmployeeQuery() {
			return View();
		}

		public ActionResult SalesQuery() {
			return View();
		}

		public ActionResult SalesUpdate() {
			return View();
		}

		public ActionResult EmployeeUpdate() {
			return View();
		}

		[HttpGet]
		public JsonResult SelectQuery(string query) {
			DataTable dt = Models.DatabaseAccess.SelectQuery(query);
			List<Dictionary<string, string>> rows = new List<Dictionary<string, string>>();
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			Dictionary<string, string> row;
			foreach(DataRow drow in dt.Rows) {
				row = new Dictionary<string, string>();
				foreach(DataColumn dcol in dt.Columns) {
					row.Add(dcol.ColumnName, drow[dcol].ToString());
				}
				rows.Add(row);
			}
			return Json(serializer.Serialize(rows), JsonRequestBehavior.AllowGet);
		}

        [HttpPost]
        public JsonResult InsertQuery(string query) {
            bool result = false;
            if(Models.DatabaseAccess.InsertQuery(query)) {
                result = true;
            }
            return Json(new {result=result});
        }

        [HttpPost]
        public JsonResult DeleteQuery(string query)
        {
            bool result = false;
            if(Models.DatabaseAccess.DeleteQuery(query)){
                result = true;
            }
            return Json(new {result=result});
        }
	}
}