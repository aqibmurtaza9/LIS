using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISBusiness.Managers
{
    public class ParameterSetupManager
    {
        public string Id { get; set; }

        public string GuId { get; set; }

        public string TestCode { get; set; }

        public string ParameterName { get; set; }

        public string ParameterType { get; set; }

        public string Unit { get; set; }

        public string Range { get; set; }

        public string IsActive { get; set; }

        public string Action { get; set; }

        DBBridge bd = new DBBridge();

        public int ParameterSetupUpdateManager()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@Mode", "UPDATE");
                param[1] = new SqlParameter("@Id", Id);
                param[2] = new SqlParameter("@TestCode", TestCode);
                param[3] = new SqlParameter("@ParameterName", ParameterName);
                param[4] = new SqlParameter("@ParameterType", ParameterType);
                param[5] = new SqlParameter("@Unit", Unit);
                param[6] = new SqlParameter("@Range", Range);
                param[7] = new SqlParameter("@IsActive", IsActive);
                bd.ExecuteNonQuery("SpParameterSetup", param);
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ParameterSetupReadCls()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@MODE", "ReadDt");
                return (bd.ExecuteDataset("SpParameterSetup", param).Tables[0]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ParameterSetupManager> PS_List(DataTable dt)
        {
            List<ParameterSetupManager> List = new List<ParameterSetupManager>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ParameterSetupManager data = new ParameterSetupManager();
                data.Id = dt.Rows[i]["Id"].ToString();
                data.TestCode = dt.Rows[i]["TestCode"].ToString();
                data.ParameterName = dt.Rows[i]["ParameterName"].ToString();
                data.ParameterType = dt.Rows[i]["ParameterType"].ToString();
                data.Unit = dt.Rows[i]["Unit"].ToString();
                data.Range = dt.Rows[i]["Range"].ToString();
                data.IsActive = dt.Rows[i]["IsActive"].ToString();
                data.Action = "<a href='#'><i class='fa fa-edit fa-lg pointer' style='color:#0080FF;' onclick='Edit(" + dt.Rows[i]["Id"] + ")' > </i></a>  <a href='#'><i class='fa fa-trash fa-lg pointer' style='color:#DF013A;'  onclick='Delete(" + dt.Rows[i]["Id"] + ")' ></i></a>";

                List.Add(data);
            }
            return List;
        }

        public DataTable ParameterReadById(int Id)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@MODE", "ReadView");
                param[1] = new SqlParameter("@Id", Id);

                return (bd.ExecuteDataset("SpParameterSetup", param).Tables[0]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int DeleteParameter()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@MODE", "DELETE");
                param[1] = new SqlParameter("@Id", Id);
                bd.ExecuteDataset("SpParameterSetup", param);
                return (1);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
