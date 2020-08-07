using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using Task1.Classes;

namespace Task1.Forms
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {

       

        #region Private Members

        DAL dl = new DAL();
        NameValueCollection nv = new NameValueCollection();

        #endregion



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

        public string GetAllData()
        {
            string returnString = "";
            try
            {
                #region Initialize

                var allData = new System.Data.DataSet();
                //allData.Clear();

                nv.Clear();


                #endregion


                #region Filter By Role

                //_nvCollection.Add("@CurrentUserEmployeeId-INT", (_currentUser.EmployeeId).ToString());
                //_nvCollection.Add("@CurrentUserRole-NVARCHAR", _currentUserRole);
                //_nvCollection.Add("@Level1id-int", Level1.ToString());
                //_nvCollection.Add("@Level2id-int", Level2.ToString());
                //_nvCollection.Add("@Level3id-int", Level3.ToString());
                //_nvCollection.Add("@Level4id-int", Level4.ToString());
                //_nvCollection.Add("@Level5id-int", Level5.ToString());
                //_nvCollection.Add("@Level6id-int", Level6.ToString());
                //_nvCollection.Add("@EmployeeId-int", employeeId.ToString());
                //_nvCollection.Add("@Month-int", Convert.ToString(month));
                //_nvCollection.Add("@Year-int", Convert.ToString(year));
                //_nvCollection.Add("@endmonth-int", Convert.ToString(endmonth));
                //_nvCollection.Add("@TeamID-int", TeamId.ToString());

                var data = dl.GetData("sp_GetAllUsers", null);
                returnString = data.Tables[0].ToJsonString();

            }
                #endregion


            catch (Exception exception)
            {

            }
            return returnString;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetUserByID(int employeeId)
        {
            string returnString = "";
            try
            {
                #region Initialize

                //var allData = new System.Data.DataSet();
                //allData.Clear();


                #endregion


                #region Filter By Role

                nv.Clear();
                nv.Add("@EmployeeId-int", employeeId.ToString());


                var data = dl.GetData("sp_GetUserByID", nv);
                returnString = data.Tables[0].ToJsonString();

            }
                #endregion


            catch (Exception exception)
            {

            }
            return returnString;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string DeleteUserbyID(int employeeId)
        {
            string returnString = "";
            try
            {
                #region Initialize

                //var allData = new System.Data.DataSet();
                //allData.Clear();


                #endregion


                #region Filter By Role

                nv.Clear();
                nv.Add("@EmployeeId-int", employeeId.ToString());


                var data = dl.GetData("sp_DeleteUserByID", nv);
                returnString = data.Tables[0].ToJsonString();

            }
                #endregion


            catch (Exception exception)
            {

            }
            return returnString;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string InsertData(string employeeName, string empAddress, string empEmail, string empImage)
        {
            string returnString = "";
            try
            {
                #region Initialize

                //var allData = new System.Data.DataSet();
                //allData.Clear();


                #endregion


                #region Filter By Role

                nv.Clear();
                nv.Add("@EmployeeName-text", employeeName.ToString());
                nv.Add("@EmpAddress-text", empAddress.ToString());
                nv.Add("@EmpEmail-text", empEmail.ToString());
                nv.Add("@EmpImage-text", empImage.ToString());


                var data = dl.GetData("sp_InsertData", nv);
                returnString = data.Tables[0].ToJsonString();

            }
                #endregion


            catch (Exception exception)
            {

            }
            return returnString;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string UpdateData(int employeeId, string employeeName, string empAddress, string empEmail)
        {
            string returnString = "";
            try
            {
                #region Initialize

                //var allData = new System.Data.DataSet();
                //allData.Clear();


                #endregion


                #region Filter By Role

                nv.Clear();
                nv.Add("@EmployeeId-int", employeeId.ToString());
                nv.Add("@EmployeeName-text", employeeName.ToString());
                nv.Add("@EmpAddress-text", empAddress.ToString());
                nv.Add("@EmpEmail-text", empEmail.ToString());



                var data = dl.GetData("sp_UpdateData", nv);
                returnString = data.Tables[0].ToJsonString();

            }
                #endregion


            catch (Exception exception)
            {

            }
            return returnString;
        }
    }
}
