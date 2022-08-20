using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISBusiness.Managers
{
    public class PatientManager
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Age { get; set; }
        public string MartialStatus { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string IsActive { get; set; }
        public string Action { get; set; }
       

        DBBridge bd = new DBBridge();

        public int PatientClassUbdate()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[10];
                param[0] = new SqlParameter("@Mode", "UPDATE");
                param[1] = new SqlParameter("@ID", Id);
                param[2] = new SqlParameter("@FirstName", FirstName);
                param[3] = new SqlParameter("@LastName", LastName);
                param[4] = new SqlParameter("@Email", Email);
                param[5] = new SqlParameter("@MobileNo", MobileNo);
                param[6] = new SqlParameter("@Gender", Gender);
                param[7] = new SqlParameter("@MartialStatus", MartialStatus);
                param[8] = new SqlParameter("@Address", Address);
                param[9] = new SqlParameter("@Age", Age);

                bd.ExecuteNonQuery("SpPatientRegistration", param);
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<PatientManager> ES_List(DataTable dt)
        {
            List<PatientManager> List = new List<PatientManager>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PatientManager data = new PatientManager();
                data.Id = dt.Rows[i]["ID"].ToString();
                data.FirstName = dt.Rows[i]["FirstName"].ToString();
                data.LastName = dt.Rows[i]["LastName"].ToString();
                data.MobileNo = dt.Rows[i]["MobileNo"].ToString();
                data.Age = dt.Rows[i]["Age"].ToString();
                data.Email = dt.Rows[i]["Email"].ToString();
                data.Address = dt.Rows[i]["Address"].ToString();
                data.IsActive = dt.Rows[i]["IsActive"].ToString();
                data.Action = "<a href='#'><i class='fa fa-edit fa-lg pointer' style='color:#0080FF;' onclick='Edit(" + dt.Rows[i]["Id"] + ")' > </i></a>  <a href='#'><i class='fa fa-trash fa-lg pointer' style='color:#DF013A;'  onclick='Delete(" + dt.Rows[i]["Id"] + ")' ></i></a>";

                List.Add(data);
            }
            return List;
        }

        public DataTable PatientListRead()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@MODE", "ReadDT");
                return (bd.ExecuteDataset("SpPatientRegistration", param).Tables[0]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ClsPatientRead()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@MODE", "Read");
                param[1] = new SqlParameter("@ID", Id);

                return (bd.ExecuteDataset("SpPatientRegistration", param).Tables[0]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int DeletePatientById()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@MODE", "Delete");
                param[1] = new SqlParameter("@Id", Id);
                bd.ExecuteDataset("SpPatientRegistration", param);
                return (1);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
