using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PopulateTreeHierarchyWithConfigurationNodes
    {

        private BusinessLogic _businessLogic = new BusinessLogic();
        private DataTable _configurationTable;

        private int _nodeId;
        private string _nodeValue;

        public void CreateHierarchyData(string appGuid)
        {
            // todo implement details
        }

        public TreeNode[] CreateTreeNodes()
        {
            // todo implement details         
        }

        private TreeNode[] RecurseRows(DataRow[] rows)
        {
            // todo implement details
        }

        private bool FindNode(TreeNode node)
        {
            // todo implement details
        }
    }
}
