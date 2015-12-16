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
        private readonly AccessDataLayer _dataLayerHelperObj = new AccessDataLayer();

        //todo fill in connection string once DB is configured
        public const string ConnectionString = @"FillinConnectionString"; 

        #region // CreateApp

        /// <summary>
        /// CreateApp creates a new application 
        /// </summary>
        /// <param name="appName">Name of application</param>
        /// <param name="description">Description of application</param>
        /// <param name="user">User name that created the application</param>
        /// <remarks>
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

        #region // Review this code with S8FTG - TSH.Dev

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

        /// <summary>
        /// AddAppConfiguration adds configurations for an application
        /// </summary>
        /// <param name="appConfiguration">variable for the application name</param>
        /// <remarks>
        /// <para> AddAppConfiguration adds configurations for selected application
        /// </para></remarks>
        /// <remarks> Created by TSH.Dev </remarks>
      
        public void AddAppConfiguration(string appConfiguration)
        {
            const string commandConfig = "[DBO].[InsertApplicationConfigurations]";

            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand(commandConfig, conn) {CommandType = CommandType.StoredProcedure})
                {
                    command.Parameters.Add("@ApplicationName", SqlDbType.VarChar).Value = "Test1";
                    command.Parameters.Add("@AppGuid", SqlDbType.UniqueIdentifier).Value =
                        "B73014E1-21731-4015-AB65-BF0A1C442130";
                    command.Parameters.Add("@Description", SqlDbType.VarChar).Value = "Test3";
                    command.Parameters.Add("@LastModifiedBy", SqlDbType.VarChar).Value = "Test4";
                    command.Parameters.Add("@LastModifiedDateTime", SqlDbType.DateTime).Value = "";
                 // command.Parmeters.Add("@ConfigurationTable", SqlDbType.UniqueIdentifier).Value = "Test5" review with DJ
                    conn.Open();
                    command.ExecuteNonQuery();  
                    conn.Close();
                    command.Parameters.Clear();
                }
            }

        }

        #endregion

        #region // SetAppConfiguration
        /// <summary>
        /// Add configuration for an application
        /// </summary>
        /// <param name="appGuid">variable for the application guid</param>
        /// <param name="parentId">variable for the parentId</param>
        /// <param name="configName">variable for the application name</param>
        /// <param name="configValue">variable for the application config value</param>
        /// <param name="user"></param>
        /// <remarks>
        /// <para> Add configuration / update configuration values in AAF /  DB
        /// </para></remarks>
        /// <remarks> Created by TSH.Dev </remarks>
        public void SetAppConfiguration(string appGuid, string parentId, string configName, string configValue,
            string user)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@AppGuid", appGuid),
                new SqlParameter("@ParentId", parentId),
                new SqlParameter("@Name", configName),
                new SqlParameter("@Value", configValue),
                new SqlParameter("@User", user)
            };
            _dataLayerHelperObj.ExecuteNonQueryWithParams(ConnectionStrings.AafDBConnectionString,
                StoredProcedures.InsertConfigurationItems, CommandType.StoredProcedure, parameters.ToArray());
        }

        #region // Review this code with S8FTG - TSH.Dev
        //var commandSetConfig = "[DBO].[InsertConfigurationItems]";
        //using (var conn = new SqlConnection(ConnectionString))
        //{
        //    using (var command = new SqlCommand(commandSetConfig, conn) { CommandType = CommandType.StoredProcedure })
        //    {
        //        command.Parameters.Add("@AppGuid", SqlDbType.VarChar).Value = "B73014E1-21731-4015-AB65-BF0A1C442130";
        //        command.Parameters.Add("@ParentId", SqlDbType.VarChar).Value = 123456789;
        //        command.Parameters.Add("@Name", SqlDbType.VarChar).Value = "TestB";
        //        command.Parameters.Add("@Name", SqlDbType.VarChar).Value = "TestC";
        //        command.Parameters.Add("@ParentId", SqlDbType.VarChar).Value = 0;
        //        command.Parameters.Add("@Name", SqlDbType.VarChar).Value = "TestD";
        //        conn.Open();
        //        command.ExecuteNonQuery();
        //        conn.Close();
        //        command.Parameters.Clear();
        //    }
        //}
        #endregion

        #endregion

        #region // DeleteApplication

        /// <summary>
        /// DeleteApplication deletes selectd application
        /// </summary>
        /// <param name="deleteApplication">sproc variable for deleting application</param>
        /// <param name="user">variable stores validated userId that deleted application</param>
        public void DeleteApplication(string deleteApplication, string user)
        {
            var parameter = new List<SqlParameter>
            {
                new SqlParameter("@AppGuid", deleteApplication),
                new SqlParameter("@User", user)
            };
            _dataLayerHelperObj.ExecuteNonQueryWithParams(ConnectionStrings.AafDBConnectionString,
                StoredProcedures.DeleteApplication, CommandType.StoredProcedure, parameter.ToArray());
        }

        #region // Review this code with S8FTG - TSH.Dev
        //var commandDeleteApplication = "[DBO].[DeleteApplication]";

        //using (var conn = new SqlConnection(ConnectionString))
        //{
        //    using (var command = new SqlCommand(commandDeleteApplication, conn) {CommandType = CommandType.StoredProcedure})
        //    {
        //        command.Parameters.Add("@AppGuid", SqlDbType.VarChar).Value = "B&0314E1-2173-4015-AB65-BF0A1C446A54";
        //        command.Parameters.Add("@User", SqlDbType.VarChar).Value = user;
        //        conn.Open();
        //        command.ExecuteNonQuery();
        //        conn.Close();
        //        command.Parameters.Clear();
        //    }
        //}
        #endregion

        #endregion

        #region // UpdateConfiguration
        /// <summary>
        /// Updates application configurationItems
        /// </summary>
        /// <remarks>
        /// <para> Updates application configurations in AAF / DB with modified values
        /// </para></remarks>
        /// <param name="id">variable contains value of application Id</param>
        /// <param name="appGuid">variable contains value of appGuid</param>
        /// <param name="parentId">variable contains value config ParentId</param>
        /// <param name="configName">variable contains name of configuration</param>
        /// <param name="configValue">variable contains configuration value of application</param>
        /// <param name="user">variable contains ActiveDirectory user Id</param>
        /// /// <remarks> Created by TSH.Dev </remarks>
        public void UpdateConfiguration(string id, string appGuid, string parentId, string configName,
            string configValue, string user)
        {
            var parameter = new List<SqlParameter>
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@AppGuid", appGuid),
                new SqlParameter("@ParentId", parentId),
                new SqlParameter("@Name", configName),
                new SqlParameter("@Value", configValue),
                new SqlParameter("@User", user)
            };
            _dataLayerHelperObj.ExecuteNonQueryWithParams(ConnectionStrings.AafDBConnectionString,
                StoredProcedures.UpdateConfigurationItems, CommandType.StoredProcedure, parameter.ToArray());
        }

        #region // Review this code with S8FTG - TSH.Dev

        //var commandUpdateApplication = "[DBO].[UpdateConfigurationItems]";

        //using (var conn = new SqlConnection(ConnectionString))
        //{
        //    using (var command = new SqlCommand(commandUpdateApplication, conn) {CommandType = CommandType.StoredProcedure})
        //    {
        //       command.Parameters.Add("@Id", 143);
        //       command.Parameters.Add("@AppGuid", SqlDbType.VarChar).Value = "C1401364-790B-4A66-8464-EC540A427812";
        //       command.Parameters.Add("@ParentId", SqlDbType.VarChar).Value = 141;
        //       command.Parameters.Add("@Name", SqlDbType.VarChar).Value = "ActiveDirectoryAppName";
        //       command.Parameters.Add("@Value", SqlDbType.VarChar).Value = "ActiveDirectory";
        //       command.Parameters.Add("@User", SqlDbType.VarChar).Value = "u406721";
        //       conn.Open();
        //       command.ExecuteNonQuery(); 
        //       conn.Close();
        //       command.Parameters.Clear();
        //    }
        //}
        #endregion

        #endregion

    }
}
      