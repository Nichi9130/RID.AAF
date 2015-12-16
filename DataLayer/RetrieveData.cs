using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public class RetrieveData
    {
       private readonly AccessDataLayer _ad1 = new AccessDataLayer();

       /// <summary>
       /// Public List RetrieveListOfApps method Executes the query, and return list of apps names when the execution is successful
       /// </summary>
       /// <remarks>
       /// <para> The RetrieveListOfApps is a generic ExecuteQuery method used to execute a Transact-SQL statement against the connection for AAF / DB</para>
       /// </remarks>
       /// <returns>list of application names</returns>
       /// <remarks> Created by TSH.Dev </remarks>
       public List<DataRow> RetrieveListOfApps()
       {
           var listOfApps = _ad1.GetDataTable(ConnectionStrings.AafDBConnectionString,
               StoredProcedures.GetApplicationDataList, CommandType.StoredProcedure);

           List<DataRow> list = listOfApps.AsEnumerable().ToList();

           return list;
       }


       /// <summary>
       /// Public List RetrieveAppConfigurations method Executes the query, and returns a datatable of an apps configurations when the execution is successful.
       /// </summary>
       /// <remarks>
       /// <para>The RetrieveAppConfigurations method is an ExecuteQuery method used to execute a Transact-SQL statement against the connection for AAF / DB
       /// </para></remarks>
       /// <param name="appGuid"></param>
       /// <returns>datatable of apps configurations</returns>
       /// <remarks> Created by TSH.Dev </remarks>
       public DataTable RetrieveAppConfigurations(string appGuid)
       {
           var configurationItems = _ad1.GetDataTable(ConnectionStrings.AafDBConnectionString,
               StoredProcedures.GetConfigurationItems, CommandType.StoredProcedure);

           return configurationItems;
       }
    }
}
