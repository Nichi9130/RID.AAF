using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer.Models
{
    internal class ConfigurationModel
    {
        private static RetrieveData RetrieveDataHelper = new RetrieveData();

        private DataTable configurationItems =
            RetrieveDataHelper.RetrieveAppConfigurations("A9ECBCDB-DB27-45C3-80EA-DC4971B72130");
    }
}
