using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace DataLayer
{
    /// <summary>
    /// AccessDataLayer handels the interactions with the database - TSH.Dev
    /// </summary>
    public class AccessDataLayer
    {
        public string LoggerPath = Environment.CurrentDirectory + @"\Logger.txt";

        #region // ExecuteQuery method
        /// <summary>
        /// Public void ReturnRowsStoredProcedure method Execute the read query.
        /// </summary>
        /// <remarks>
        /// <para> The ReturnRowsStoredProcedure is a generic ExecuteQuery method used to Execute a Transact-SQL statement against the connection for AAF / DB </para></remarks>
        /// <param name="connectionString"></param>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        /// <returns>results of query in a reader </returns>
        /// <remarks> Created by TSH.Dev </remarks>

        public List<string> ExecuteQuery(string connectionString, string storedProcedure,
            params SqlParameter[] parameters)
        {
            var queryResults = new List<string>();
            try
            {
                var sqlConnection1 = new SqlConnection(connectionString);
                var cmd = new SqlCommand
                {
                    CommandText = storedProcedure,
                    CommandType = CommandType.StoredProcedure,
                    Connection = sqlConnection1,
                    CommandTimeout = 3000
                };
                if (parameters != null)
                {
                    cmd.Parameters.AddRange((Array)parameters);
                }
                sqlConnection1.Open();
                var reader = cmd.ExecuteReader();

                // Data is accessable through the DataReader object here - TSH.Dev
                while (reader.Read())
                {
                    queryResults.Add(reader["RoleName"].ToString());
                }
                cmd.Parameters.Clear();
                sqlConnection1.Close();
            }
            catch (Exception db)
            {

                throw new Exception(db.Message, db);
            }
            return queryResults;
        }
        #endregion

        #region //EcecuteNonQueryWithParams method

        public int ExecuteNonQueryWithParams(string connectionStrings, string storedProcedures, CommandType commandType,
            params SqlParameter[] parameters)
        {
            int rowsAffected;
            using (var conn = new SqlConnection(connectionStrings))
            {
                using (var command = new SqlCommand(storedProcedures, conn) { CommandType = commandType })
                {
                    command.Parameters.AddRange((Array)parameters);
                    if (parameters != null)
                    {
                        command.Parameters.AddRange((Array)parameters);
                    }
                    try
                    {
                        conn.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception db)
                    {
                        throw new Exception(db.Message, db);
                    }
                    finally
                    {
                        command.Parameters.Clear();
                    }
                }
            }
            return rowsAffected;
        }
        #endregion

        #region //ExecuteNonQuery Method

        public int ExecuteNonQuery(string connectionString, string nonQuery, CommandType commandType)
        {
            int rowsAffected;
            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(nonQuery, conn) { CommandType = commandType })
                {
                    command.CommandTimeout = 30000;

                    try
                    {
                        conn.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception db)
                    {

                        throw new Exception(db.Message, db);
                    }
                }
            }
            return rowsAffected;
        }

        #endregion

         #region
        /// <summary>
        /// Public DataTable GetDataTable method Executes the query, and returns a datable when the execution is succesful.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The GetDataTable is a generic ExecuteQuery method used to Execute a Transact-SQL statement against the connection for AAF / DB
        /// </para>
        /// </remarks>
        /// <param name="connectionString"></param>
        /// <param name="query"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns>dataTable (returns the result of stored procedure executed)</returns>
        /// <remarks> Created by TSH.Dev </remarks>
        public DataTable GetDataTable(string connectionString, string query, CommandType commandType,
            params SqlParameter[] parameters)
        {
            var queryResult = new DataTable();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand(query, conn) {CommandType = commandType})
                    {
                        command.CommandTimeout = 3000;

                        if (parameters != null)
                        {
                            command.Parameters.AddRange((Array) parameters);
                        }
                        conn.Open();
                        queryResult.Load(command.ExecuteReader());
                        command.Parameters.Clear();
                    }  
                }
                return queryResult;
            }
            catch (Exception db)
            {
                
                throw new Exception(db.Message, db);
            }
        }

        #endregion
     }
   }
