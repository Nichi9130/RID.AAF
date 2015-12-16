using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class CreateApps
    {
        private AccessDataLayer _dataLayerHelperObj = new AccessDataLayer();
        public const string ConnectionString = @"FillinConnectionString";

        #region // CreateApp

        /// <summary>
        /// CreateApp creates a new application 
        /// </summary>
        /// <param name="appName">Name of application</param>
        /// <param name="description">Description of application</param>
        /// <param name="user">User name that created the application</param>
        /// /// <remarks>
        /// <para> CreateApp creates a new application with values returned from AAF /DB
        /// </para></remarks>
        /// <remarks> Created by TSH.Dev </remarks>
        public void CreateApp(string appName, string description, string user)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", appName),
                new SqlParameter("@Description", description),
                new SqlParameter("@User", user)
            };

            _dataLayerHelperObj.ExecuteNonQueryWithParams(ConnectionStrings.AafDBConnectionString,
                StoredProcedures.CreateApplication, CommandType.StoredProcedure, parameters.ToArray());

        }

        #region // Review this code with DJ - TSH.Dev

        //var commandText = "[DBO].[CreateApplication]";

        //using (var conn = new SqlConnection(ConnectionString))
        //{
        //    using (var command = new SqlCommand(commandText, conn) { CommandType = CommandType.StoredProcedure })
        //    {
        //        command.Parameters.Add("@Name", SqlDbType.VarChar).Value = appName;
        //        command.Parameters.Add("@Description", SqlDbType.VarChar).Value = description;
        //        command.Parameters.Add("@User", SqlDbType.VarChar).Value = user;
        //        conn.Open();
        //        command.ExecuteNonQuery();
        //        conn.Close();
        //        command.Parameters.Clear();

        #endregion


        #endregion

        #region // AddAppConfiguration

        public void AddAppConfiguration(string appConfiguration)
        {
            var commandConfig = "[DBO].[InsertApplicationConfigurations]";

            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand(commandConfig, conn) {CommandType = CommandType.StoredProcedure})
                {
                    
                }
            }

        }

        #endregion


    }
}
      