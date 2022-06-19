using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISBusiness.Managers
{
    public class CustomSetupManager
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

        public static List<CustomSetupManager> ES_List(DataTable dt)
        {

            List<CustomSetupManager> List = new List<CustomSetupManager>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomSetupManager data = new CustomSetupManager();
                data.Id = dt.Rows[i]["Id"].ToString();
                data.Description = dt.Rows[i]["Description"].ToString();
                data.MasterId = dt.Rows[i]["MasterId"].ToString();
                data.IsActive = dt.Rows[i]["IsActive"].ToString();
                data.Action = "<a href='#'><i class='fa fa-edit fa-lg pointer' style='color:#0080FF;' onclick='Edit(" + dt.Rows[i]["Id"] + ")' > </i></a>  <a href='#'><i class='fa fa-trash fa-lg pointer' style='color:#DF013A;'  onclick='Delete(" + dt.Rows[i]["Id"] + ")' ></i></a>";

                List.Add(data);
            }

            return List;
        }


        public DataTable CustomSetupRead()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];


                param[0] = new SqlParameter("@MODE", "Read1");
                //param[1] = new SqlParameter("@Id", Id);

                return (bd.ExecuteDataset("SpCustomSetup", param).Tables[0]);

            }
            catch (Exception)
            {
                throw;
            }

        }


        public DataTable SetupPreLoad(string Id)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];


                param[0] = new SqlParameter("@MODE", "ReadSetupPreLoad");
                param[1] = new SqlParameter("@MasterId", Id);

                return (bd.ExecuteDataset("SpCustomSetup", param).Tables[0]);

            }
            catch (Exception)
            {
                throw;
            }

        }


        public DataTable CustomTableRead()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@MODE", "ReadCustomTable");
                param[1] = new SqlParameter("@Id", Id);

                return (bd.ExecuteDataset("SpCustomSetup", param).Tables[0]);

            }
            catch (Exception)
            {
                throw;
            }

        }


        public int CustomSetupUpdate()
        {

            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@Mode", "UPDATE");
                param[1] = new SqlParameter("@Id", Id);
                param[2] = new SqlParameter("@Description", Description);
                param[3] = new SqlParameter("@MasterId", MasterId);
                param[4] = new SqlParameter("@IsActive", IsActive);
                //param[5] = new SqlParameter("@IsDeleted", Convert.ToBoolean(IsDeleted));


                bd.ExecuteNonQuery("SpCustomSetup", param);
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable CustomRead(int Id)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@MODE", "ReadDt");
                param[1] = new SqlParameter("@Id", Id);

                return (bd.ExecuteDataset("SpCustomSetup", param).Tables[0]);

            }
            catch (Exception)
            {
                throw;
            }

        }

        public int DeleteCustomSetup()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];


                param[0] = new SqlParameter("@MODE", "DELETE");
                param[1] = new SqlParameter("@Id", Id);
                bd.ExecuteDataset("SpCustomSetup", param);
                return (1);

            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}
