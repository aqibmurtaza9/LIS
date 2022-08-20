using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISBusiness.Managers
{
    public class LabRequestManager
    {
        public string MRNo { get; set; }
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string MobileNumber { get; set; }
        public string Age { get; set; }
        public string MartialStatus { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string IsActive { get; set; }
        public string Action { get; set; }


        //master
        public string MId { get; set; } 

        public string MrNo { get; set; }

        public string Status { get; set; }
        public string CollectionDateTime { get; set; }
        public string CollectionUser { get; set; }
        public string TestCode { get; set; }
        public string TubeCode { get; set; }
        public string IRSType { get; set; }
        public string UrgentType { get; set; }
        public string SpecialInstruction { get; set; }
        //  public string GroupCode { get; set; }
        // public string Counter { get; set; }
        public string ReportingDate { get; set; }
        public string IsDeleted { get; set; }

        DBBridge bd = new DBBridge();


        public int LabRequestDetail()
        {
            try
            {

                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@Mode", "UPDATE");
                param[1] = new SqlParameter("@MrNo", MrNo);
                param[2] = new SqlParameter("@Status", Status);
                //param[3] = new SqlParameter("@CollectionDateTime", CollectionDateTime);
                //  param[3] = new SqlParameter("@CollectionUser", CollectionUser);

                param[3] = new SqlParameter("@TestCode", TestCode);
                param[4] = new SqlParameter("@IRSType", IRSType);
                param[5] = new SqlParameter("@UrgentType", UrgentType);
                //  param[9] = new SqlParameter("@SpecialInstruction", SpecialInstruction);
                // param[16] = new SqlParameter("@GroupCode", GroupCode);
                // param[17] = new SqlParameter("@Counter", Counter);
                // param[10] = new SqlParameter("@ReportingDate", ReportingDate);

                bd.ExecuteNonQuery("SpLabRequestDetail", param);

                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}
