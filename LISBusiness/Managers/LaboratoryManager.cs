using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISBusiness.Managers
{
    public class LaboratoryManager
    {
        public string Id { get; set; }

        public string GuId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string MasterId { get; set; }

        public string IsActive { get; set; }

        public string IsDeleted { get; set; }
        public string Action { get; set; }

        DBBridge bd = new DBBridge();


        public int LaboratorySetupUpdate()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@Mode", "UPDATE");
                param[1] = new SqlParameter("@Id", Id);
                param[2] = new SqlParameter("@Name", Name);
                param[3] = new SqlParameter("@Description", Description);
                param[4] = new SqlParameter("@IsActive", IsActive);
                bd.ExecuteNonQuery("SpLaboratorySetup", param);
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable LaboratorySetupRead()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@MODE", "ReadDT");
                return (bd.ExecuteDataset("SpLaboratorySetup", param).Tables[0]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<LaboratoryManager> LS_List(DataTable dt)
        {

            List<LaboratoryManager> List = new List<LaboratoryManager>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LaboratoryManager data = new LaboratoryManager();
                data.Id = dt.Rows[i]["Id"].ToString();
                data.Name = dt.Rows[i]["Name"].ToString();
                data.Description = dt.Rows[i]["Description"].ToString();
                data.IsActive = dt.Rows[i]["IsActive"].ToString();
                data.Action = "<a href='#'><i class='fa fa-edit fa-lg pointer' style='color:#0080FF;' onclick='Edit(" + dt.Rows[i]["Id"] + ")' > </i></a>  <a href='#'><i class='fa fa-trash fa-lg pointer' style='color:#DF013A;'  onclick='Delete(" + dt.Rows[i]["Id"] + ")' ></i></a>";
                List.Add(data);
            }

            return List;
        }

        public DataTable LaboratoryRead()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@MODE", "Read1");
                param[1] = new SqlParameter("@Id", Id);
                return (bd.ExecuteDataset("SpLaboratorySetup", param).Tables[0]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int DeleteLabSetup()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@MODE", "DELETE");
                param[1] = new SqlParameter("@Id", Id);
                bd.ExecuteDataset("SpLaboratorySetup", param);
                return (1);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
