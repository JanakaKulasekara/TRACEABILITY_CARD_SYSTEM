using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Configuration;
using System.IO;


namespace TRACEABILITY_CARD_SYSTEM.Database
{
    public static class Dataaccess
    {
        /// Returns the results of a SQL Query in the form of a DataTable
        public static DataTable SQLSelect(SqlCommand cmdSQLQuery)
        {
            //Get connection string
            string conConnectionString = ConfigurationManager.ConnectionStrings["ConnStringdsiinventory"].ConnectionString;
            
            using (SqlConnection SQLDatabaseConnection = new SqlConnection(conConnectionString)) 
            {
                DataSet dsPageInfo = new DataSet();
                try
                {

                    //Perform Command
                    cmdSQLQuery.Connection = SQLDatabaseConnection;
                    
                    SqlDataAdapter daPageInfo = new SqlDataAdapter(cmdSQLQuery);
                    SQLDatabaseConnection.Open();
                    daPageInfo.Fill(dsPageInfo);

                }

                catch (Exception ex)
                {
                    throw ex;
                }


                finally
                {
                    SQLDatabaseConnection.Close();
                    SQLDatabaseConnection.Dispose();
                    
                }
                return dsPageInfo.Tables[0];
            }
            
        }

        /// Executes a SQL Command
        public static void ExecuteSQLCommand(SqlCommand CommandToExecute)
        {
            //get connection sring
            string conConnectionString = ConfigurationManager.ConnectionStrings["ConnStringdsiinventory"].ConnectionString;
            
            
            using (SqlConnection SQLDatabaseConnection = new SqlConnection(conConnectionString))
            {


                //int retval;

                try
                {
                    //execute command
                    CommandToExecute.Connection = SQLDatabaseConnection;
                    SQLDatabaseConnection.Open();
                    CommandToExecute.ExecuteNonQuery();

                }

                catch (Exception ex)
                {
                    throw ex;

                }

                finally
                {
                    SQLDatabaseConnection.Close();
                    SQLDatabaseConnection.Dispose();
                }

                //return retval;
            }
            
        }



    }
}
