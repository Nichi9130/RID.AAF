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
    public class BusinessLogic
    {
        AccessDataLayer DataLayerHelper = new AccessDataLayer();

        public DataTable RetrieveListOfApps()
        {
            return GetAllApplications();
        }

        private void RetrieveConfiguration(string appGuid)
        {
            //todo fill in implementation details
        }

        #region // Helper Methods
        /// <summary>
        /// GetAllApplications retrieves a datatable of application names
        /// </summary>
        /// <remarks>
        /// <para> The GetAllApplications Executes a Transact-SQL statement against the connection for AAF / DB
        /// </para></remarks>
        /// <returns>retrieves a datatable of application names</returns>
        /// <remarks> Created by TSH.Dev </remarks>
        private DataTable GetAllApplications()
        {
            return DataLayerHelper.GetDataTable(ConnectionStrings.AafDBConnectionString,
                StoredProcedures.GetApplicationDataList, CommandType.StoredProcedure, null);
        }

        /// <summary>
        /// GetAllConfiguration retrieves a datatable of application configurations
        /// </summary>
        /// <remarks>
        /// <para> The GetAllConfiguration Executes a Transact-SQL statement against the connection for AAF / DB
        /// </para></remarks>
        /// <returns>retrieves a datatable of application configurations</returns>
        /// <remarks> Created by TSH.Dev </remarks>
        public DataTable GetAllConfiguration(string appGuid)
        {
            var Paramaters = new List<SqlParameter>
            {
                new SqlParameter("@AppGuid", appGuid)
            };
            return DataLayerHelper.GetDataTable(ConnectionStrings.AafDBConnectionString,
                StoredProcedures.GetConfigurationItems, CommandType.StoredProcedure, Paramaters.ToArray());
        }
        #endregion
    }
}
