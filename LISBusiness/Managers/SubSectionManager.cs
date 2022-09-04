using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISBusiness.Managers
{
    public class SubSectionManager
    {
        DBBridge bd = new DBBridge();
        public string Action { get; set; }
        public string Id { get; set; }

        public string Section { get; set; }
        public string SubSection { get; set; }
        public string ParameterType { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }

        public string IsDeleted { get; set; }

        public static List<SubSectionManager> ES_List(DataTable dt)
        {
            List<SubSectionManager> List = new List<SubSectionManager>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SubSectionManager data = new SubSectionManager();
                data.Id = dt.Rows[i]["Id"].ToString();
                data.Section = dt.Rows[i]["Section"].ToString();
                data.SubSection = dt.Rows[i]["SubSection"].ToString();
                data.ParameterType = dt.Rows[i]["ParameterType"].ToString();
                data.Description = dt.Rows[i]["Description"].ToString();
                data.IsActive = dt.Rows[i]["IsActive"].ToString();
                data.Action = "<a href='#'><i class='fa fa-edit fa-lg pointer' style='color:#0080FF;' onclick='Edit(" + dt.Rows[i]["Id"] + ")' > </i></a>  <a href='#'><i class='fa fa-trash fa-lg pointer' style='color:#DF013A;'  onclick='Delete(" + dt.Rows[i]["Id"] + ")' ></i></a>";

                List.Add(data);
            }

            return List;
        }
        public DataTable AllRead()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@MODE", "READDT");
                return (bd.ExecuteDataset("SpSubSection", param).Tables[0]);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
