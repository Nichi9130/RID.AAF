using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using BusinessLayer;
using BusinessLayer.Models;

namespace NICHI.RID.AAF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _appGuid;
        private DataTable _result;
        private bool isAutenticated;
        private List<DataRow> _listOfConfigDataRows;
        private readonly ClientWorker _clientWorker = new ClientWorker();
        private readonly BusinessLogic _bizLogicHelper = new BusinessLogic();
        private readonly PopulateTreeHierarchyWithConfigurationNodes _configHierrarchy = new PopulateTreeHierarchyWithConfigurationNodes();
        private readonly ApplicationConfigurationModel _app = new ApplicationConfigurationModel();
        private readonly List<ApplicationConfigurationModel> _hydrateConfigurationModels = new List<ApplicationConfigurationModel>();

        public XElement HierarchicalData { get; set; }
        private HierarchyItem _hierarchyItem { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AppNamesListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
