using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace LISBusiness.Managers
{
    public class TestSetupManager
    {
        DBBridge bd = new DBBridge();

        public string Id { get; set; }
        public string TestName { get; set; }
        public string ShortDesp { get; set; }
        public string Type { get; set; }
        public string Section { get; set; }
        public string SubSection { get; set; }
        public string CptCode { get; set; }
        public string IsActive { get; set; }

        public string IsDeleted { get; set; }
        public string Action { get; set; }

        public string DataTableToJSON(DataTable table)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

            foreach (DataRow row in table.Rows)
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    dict[col.ColumnName] = row[col];
                }
                list.Add(dict);
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = int.MaxValue;

            return serializer.Serialize(list);
        }

        public static List<TestSetupManager> ES_List(DataTable dt)
        {
            List<TestSetupManager> List = new List<TestSetupManager>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TestSetupManager data = new TestSetupManager();

                data.Id = dt.Rows[i]["Id"].ToString();
                data.TestName = dt.Rows[i]["TestName"].ToString();
                data.ShortDesp = dt.Rows[i]["ShortDescription"].ToString();
                data.Type = dt.Rows[i]["Type"].ToString();
                data.Section = dt.Rows[i]["Section"].ToString();
                data.SubSection = dt.Rows[i]["SubSection"].ToString();
                data.CptCode = dt.Rows[i]["CptCode"].ToString();
                data.IsActive = dt.Rows[i]["IsActive"].ToString();
                data.IsDeleted = dt.Rows[i]["IsDeleted"].ToString();
                data.Action = "<a href='#'><i class='fa fa-edit fa-lg pointer' style='color:#0080FF;' onclick='Edit(" + dt.Rows[i]["Id"] + ")' > </i></a>  <a href='#'><i class='fa fa-trash fa-lg pointer' style='color:#DF013A;'  onclick='Delete(" + dt.Rows[i]["Id"] + ")' ></i></a>";

                List.Add(data);
            }

            return List;
        }

        public DataTable ReadDT()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Mode", "ReadDT");

                return (bd.ExecuteDataset("SpTestSetup", param).Tables[0]);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int TestSetupUpdate()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@Mode", "UPDATE");
                param[1] = new SqlParameter("@Id", Id);
                param[2] = new SqlParameter("@TestName", TestName);
                param[3] = new SqlParameter("@ShortDescription", ShortDesp);
                param[4] = new SqlParameter("@Type", Type);
                param[5] = new SqlParameter("@Section", Section);
                param[6] = new SqlParameter("@SubSection", SubSection);
                param[7] = new SqlParameter("@CptCode", CptCode);
                param[8] = new SqlParameter("@IsActive", IsActive);

                bd.ExecuteNonQuery("SpTestSetup", param);

                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
