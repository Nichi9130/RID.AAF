using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using BusinessLayer;
using DataLayer;

namespace NICHI.RID.AAF
{
    public class ClientWorker
    {
        private readonly AccessDataLayer _dataLayerHelperObj = new AccessDataLayer();

        private CreateApps _applicationHelper = new CreateApps();

        public bool VerifyUser(string stringToEvaluate)
        {
            #region // local method variables

            var errorMessage = "Unable to locate user : ";

            // executing sproc returning datatable
            var result = _dataLayerHelperObj.GetDataTable(ConnectionStrings.AafDBConnectionString,
                StoredProcedures.GetActiveUsers, CommandType.StoredProcedure);

            // instance to call conversion method
            var testUser = new Users();

            // signal success or fail of evaluation
            bool foundUser = false;

            //variable to hold result of conversion from DataTable to -2->  Generic List
            var convertedList = testUser.ConvertSingleColumnDataTable<string>(result);

            #endregion
            #region // conversion logic
            for (int i = 0; i < convertedList.Count; i++)
            {
                foreach (var dataRow in convertedList)
                {
                    if (stringToEvaluate == (string)dataRow[0])
                    {
                        foundUser = true;
                    }
                }
            }
            if (foundUser != true)
            {
                MessageBox.Show(string.Format("{0}{1}", errorMessage, stringToEvaluate));
            }
            return foundUser;
            #endregion
        }

        public void CreateApplication(string applicationName, string description, string user )
        {
            _applicationHelper.CreateApp( applicationName, description, user );
            //todo implement logic to create an application here d[-!-]b
        }

        public void CreateApplicationConfiguration(string appGuid, string parentId, string configName, string configValue, string user )
        {
            _applicationHelper.SetAppConfiguration( appGuid, parentId, configName, configValue, user );
            //todo implement logic for creating new configurations here d[-!-]b
        }

        public void DeleteApplication(string appGuid, string user )
        {
            _applicationHelper.DeleteApplication( appGuid, user );
            //todo implement logic for deleting an application here d[-!-]b
        }

        public void UpdateConfiguration(string id, string appGuid, string parentId, string configName,
            string configValue, string user)
        {
            _applicationHelper.UpdateConfiguration( id, appGuid, parentId, configName, configValue, user);
            //todo implement logic to update application configurations here d[-!-]b
        }

        public IEnumerable<string> GetApplicationNames()
        {
            var dataSource = new RetrieveData();

            return (from DataRow row in dataSource.RetrieveListOfApps() select row["Name"].ToString()).ToList();
        } 
    }
}
