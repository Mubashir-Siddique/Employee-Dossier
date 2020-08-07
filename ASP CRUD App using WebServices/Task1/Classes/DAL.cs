using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Configuration;

namespace Task1.Classes
{
    public class DAL
    {
        public DataSet GetData(String spName, NameValueCollection nv)
        {
            #region Initialization

            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Task1connString"].ToString());
            string dbTyper = "";

            #endregion

            try
            {
                #region Open Connection

                //connection.ConnectionString = ConfigurationManager.ConnectionStrings;
                
                var dataSet = new DataSet();
                connection.Open();

                #endregion

                #region Get Store Procedure and Start Processing

                var command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                command.CommandText = spName;
                command.CommandTimeout = 20000;

                if (nv != null)
                {
                    #region Retreiving Data

                    for (int i = 0; i < nv.Count; i++)
                    {
                        string[] arraysplit = nv.Keys[i].Split('-');

                        if (arraysplit.Length  > 2 )
                        {
                            #region Code For Data Type Length

                            dbTyper = "SqlDbType." + arraysplit[1].ToString() + "," + arraysplit[2].ToString();

                           // command.Parameters.AddWithValue(arraysplit[0].ToString(), dbTyper).Value = nv[i].ToString();
                            if (nv[i].ToString() == "NULL")
                            {
                                command.Parameters.AddWithValue(arraysplit[0].ToString(), dbTyper).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.AddWithValue(arraysplit[0].ToString(), dbTyper).Value = nv[i].ToString();
                            }

                            #endregion
                        }
                        else
                        {
                            #region Code For Int Values

                            dbTyper = "SqlDbType." + arraysplit[1].ToString();
                            // command.Parameters.AddWithValue(arraysplit[0].ToString(), dbTyper).Value = nv[i].ToString();

                            if (nv[i].ToString() == "NULL")
                            {
                                command.Parameters.AddWithValue(arraysplit[0].ToString(), dbTyper).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.AddWithValue(arraysplit[0].ToString(), dbTyper).Value = nv[i].ToString();
                            }


                            #endregion
                        }
                    }

                    #endregion
                }

                #endregion

                #region Return DataSet

                var dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataSet);

                return dataSet;

                #endregion
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                #region Close Connection

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                #endregion
            }

        }
    }
}