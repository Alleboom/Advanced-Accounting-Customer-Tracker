using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Advanced_Accounting_Customer_Tracker.View.Service_Forms
{
    /// <summary>
    /// Interaction logic for Add_Service.xaml
    /// </summary>
    public partial class Add_Service : Window
    {
        public Add_Service()
        {
            InitializeComponent();
            var vm = new ViewModel.Service_View_Models.Add_Service_View_Model();
            this.DataContext = vm;
            if (vm.CloseAction == null)
            {
                vm.CloseAction = new Action(() => this.Close());
            }
        }
    }
}
