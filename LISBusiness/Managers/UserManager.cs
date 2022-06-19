using LISCommon.Constant;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISBusiness.Managers
{
    public class UserManager
    {
        public string Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }
        public string DepartmentCode { get; set; }
        public string Password { get; set; }

        public string PhoneNo { get; set; }
        public string Cnic { get; set; }
        public int Gender { get; set; }
        public int UserType { get; set; }
        public string IsActive { get; set; }
        public string IsDeleted { get; set; }
        public string Action { get; set; }

        public string AllowAuth { get; set; }



        DBBridge bd = new DBBridge();

        public static List<UserManager> ES_List(DataTable dt)
        {
           
            List<UserManager> List = new List<UserManager>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UserManager data = new UserManager();
                data.Id = dt.Rows[i]["Id"].ToString();
                data.FirstName = dt.Rows[i]["FirstName"].ToString() + " " + dt.Rows[i]["LastName"].ToString();
                data.UserName = dt.Rows[i]["UserName"].ToString();
                data.Email = dt.Rows[i]["Email"].ToString();
                data.PhoneNo = dt.Rows[i]["PhoneNo"].ToString();
                data.IsActive = dt.Rows[i]["IsActive"].ToString();
                data.Action = "<a href='#'> <i class='las la-pen text-secondary font-16'  onclick='Edit(" + dt.Rows[i]["Id"] + ")' ></i></a>  <a href='#'><i class='las la-trash-alt text-secondary font-16'  onclick='Delete(" + dt.Rows[i]["Id"] + ")' ></i></a>  ";
      

                List.Add(data);
            }

            return List;
        }


        public int UserRegistration()
        {

            try
            {

                SqlParameter[] param = new SqlParameter[14];
                param[0] = new SqlParameter("@Mode", "Update");
                param[1] = new SqlParameter("@Id", Id);
                param[2] = new SqlParameter("@FirstName", FirstName);
                param[3] = new SqlParameter("@LastName", LastName);
                param[4] = new SqlParameter("@UserName", UserName);
                param[5] = new SqlParameter("@Email", Email);
                param[6] = new SqlParameter("@DeptCode", DepartmentCode);
                param[7] = new SqlParameter("@PhoneNo", PhoneNo);
                param[8] = new SqlParameter("@Gender", Gender);
                param[9] = new SqlParameter("@Cnic", Cnic);
                param[10] = new SqlParameter("@UserType", UserType);
                param[11] = new SqlParameter("@AllowAuth", AllowAuth);
                param[12] = new SqlParameter("@IsActive", IsActive);
                param[13] = new SqlParameter("@IsDeleted", IsDeleted);


                bd.ExecuteDataset("SpUserProfile", param);
                return 1;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetUserProfileList()
        {
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Mode", "ReadDT");

                return (bd.ExecuteDataset("SpUserProfile", param).Tables[0]);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public DataTable GetUserProfile()
        {

            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Mode", "READ");
                param[1] = new SqlParameter("@Id", Id);

                return (bd.ExecuteDataset("SpUserProfile", param).Tables[0]);

            }
            catch (Exception)
            {

                throw;
            }

        }


        public int DeleteUser()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];


                param[0] = new SqlParameter("@MODE", "DELETE");
                param[1] = new SqlParameter("@Id", Id);
                bd.ExecuteDataset("SpUserProfile", param);
                return (1);

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
