using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public class StoredProcedures
   {
       public const string CreateExecutionLog = "CreateExecutionLog";
       public const string InsertGeneralLog = "InsertGeneralLog";
       public const string InsertExceptionLog = "InsertExceptionLog";
       public const string GetConfigurationItems = "GetConfigurationItems";
       public const string InsertConfigurationItems = "InsertConfigurationItems";
       public const string UpdateConfigurationItems = "UpdateConfigurationItems";
       public const string DeleteConfigurationItems = "DeleteConfigurationItems";
       public const string SelectGeneralLog = "SelectGeneralLog";
       public const string GetApplicationDataList = "GetApplicationDataList";
       public const string GetApplicationDataListWithStatistics = "GetApplicationDataListWithStatistics";
       public const string CreateApplication = "CreateApplication";
       public const string DeleteApplication = "DeleteApplication";
       public const string GetExecutionLog = "GetExecutionLog";
       public const string SelectExceptionLog = "SelectExceptionLog";
       public const string UpdateApplicationNames = "UpdateApplicationName";
       public const string LogsPurger = "LogsPurger";
       public const string InsertApplicationConfigurations = "InsertApplicationConfigurations";

       // Autorization
       public const string GetAllSystems = "GetAllSystems";
       public const string GetPrivlegesByUser = "GetPrivlegesByUser";
       public const string GetRolePrivlegesByUser = "GetRolePrivlegesByUser";
       public const string GetActiveUsers = "GetActiveUsers";
       public const string GetAllActiveRoles = "GetAllActiveRoles";
       public const string GetPrivlegesByRole = "GetPrivlegesByRole";
       public const string AssignUserPrivilegesBySystem = "AssignUserPrivilegesBySystem";
       public const string AssignPrivlegesToRole = "AssignPrivlegesToRole";
       public const string GetActivePrivilegesBySystem = "GetActivePrivilegesBySystem";
       public const string GetRolePrivilegeList = "GetRolePrivilegeList";
       public const string SetLastLoginDateTime = "SetLastLoginDateTime";
       public const string GetPrivilegesForRoleSet = "GetPrivilegesForRoleSet";

       // Exceptions
       public const string GetExceptionSummary = "GetExceptionSummary";
   }
}
