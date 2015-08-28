using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Advanced_Accounting_Customer_Tracker.ViewModel 
{
    public class VMMainWindow : VMBase
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public VMMainWindow()
        {   
            OpenWindow = new Helpers.RelayCommand(Open);
            Filters = new ObservableCollection<string>();
            EveryCustomer = null;
            EveryService = null;
            Filters.Add("Customer");
            Filters.Add("Service");
            FilterIsCustomer = false;
            

            
        }
        
        #region Member Variables
        private ObservableCollection<object> _LeftList = new ObservableCollection<object>(); 
        private ObservableCollection<object> _RightList = new ObservableCollection<object>();
        private String _SelectedFilter;
        private object _SelectLeft;
        public Helpers.RelayCommand OpenWindow {get;set;}
        public ObservableCollection<String> Filters { get; set; }
        private bool _FilterIsCustomer;
        private bool _FilterIsService;
        private String _AccountingMethod;
        #endregion

        #region Properties


        /// <summary>
        /// Returns true of the filter applied from the combo box is a customer
        /// </summary>
        public bool FilterIsCustomer
        {
            get
            {
                return _FilterIsCustomer;
            }
            set
            {
                if (value != _FilterIsCustomer)
                {
                    _FilterIsCustomer = value;
                    OnPropertyChanged("FilterIsCustomer");
                }
            }
        }

        /// <summary>
        /// Returns true if the filter applied is a customer
        /// </summary>
        public bool FilterIsService
        {
            get
            {
                return _FilterIsService;
            }
            set
            {
                if (value != _FilterIsService)
                {
                    _FilterIsService = value;
                    OnPropertyChanged("FilterIsService");
                }
            }
        }

        /// <summary>
        /// The accounting mehod of the customer.
        /// Only shows when a customer filter is selected.
        /// </summary>
        public String AccountingMethod
        {
            get
            {
                return _AccountingMethod;
            }
            set
            {
                if (value != _AccountingMethod)
                {
                    _AccountingMethod = value;
                    OnPropertyChanged("AccountingMethod");
                }
            }
        }

        /// <summary>
        /// The left object selected, populates all the lists automatically
        /// </summary>
        public object SelectLeft
        {
            get
            {
                return _SelectLeft;
            }

            set
            {
                _SelectLeft = value;
                OnPropertyChanged("SelectedLeft");
                using (var db = new DataModel())
                {
                    // generate a list of services based off the customer, we know its a customer because the filter is a customer
                    if (SelectedFilter == "Customer")
                    {
                        // clear the list on the right and populate it with services
                        RightList.Clear();
                        Customer cust = (Customer)value;
                        ObservableCollection<Service> services = new ObservableCollection<Service>();

                        // populate the right list with all the services tied to that customer
                        foreach (var item in db.CustomerServiceAssociatives)
                        {
                            if (item.CustomerID == cust.Id)
                            {
                                services.Add(item.Service);
                            }
                        }

                        // populate the right list with services
                        foreach (var item in services)
                        {
                            RightList.Add(item);
                        }

                        // Apply the Accounting method of the customer to the 
                        // View Models Accounting method if we have a customer selected
                        if (cust != null)
                        {
                            AccountingMethod = cust.Accounting_Method;
                        }
                    }

                    // Show servies on the left and show which customer has them on the right
                    if (SelectedFilter == "Service") { 
                    
                        // Clear the right list
                        RightList.Clear();
                        Service serv = (Service)value;
                        ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

                        // check for each service attached to that customer
                        foreach (var item in db.CustomerServiceAssociatives)
                        {
                            if (item.ServiceID == serv.Id)
                            {
                                customers.Add(item.Customer);
                            }
                        }

                        // populate the right list with customers
                        foreach (var item in customers)
                        {
                            RightList.Add(item);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The selected filter string for setting our left list
        /// </summary>
        public String SelectedFilter
        {
            get
            {
                return _SelectedFilter;
            }
            set
            {
                    _SelectedFilter = value;
                    OnPropertyChanged("SelectedFilter");
                    LeftList.Clear();

                    OnPropertyChanged("RightList");
                    switch (_SelectedFilter)
                    {
                        case "Customer" :
                            foreach (var item in EveryCustomer)
                            {
                                LeftList.Add(item);
                            }
                            OnPropertyChanged("LeftList");
                            FilterIsCustomer = true;
                            FilterIsService = false;
                            break;

                        case "Service" :
                            foreach (var item in EveryService)
                            {
                                LeftList.Add(item);
                            }
                            FilterIsCustomer = false;
                            FilterIsService = true;
                            break;

                        default :
                            break;
                    }
            }
        }

        /// <summary>
        /// The container for all the slecteable objects in our left list
        /// </summary>
        public ObservableCollection<object> LeftList
        {
            get
            {
                return _LeftList;
            }
            set
            {
                if (value != _LeftList)
                {
                    _LeftList = value;
                    OnPropertyChanged("LeftList");
                }
            }
        }

        /// <summary>
        /// Container for all the objects determined by the SelectLeft property
        /// </summary>
        public ObservableCollection<object> RightList
        {
            get
            {
                return _RightList;
            }
            set
            {
                if (value != _RightList)
                {
                    _RightList = value;
                    OnPropertyChanged("RightList");
                }
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Updates the left, right list and the filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateFields(object sender, EventArgs e)
        {
            EveryCustomer = null;
            EveryService = null;
            SelectedFilter = _SelectedFilter;
        }

        /// <summary>
        /// Handles opening a new window based off of the parameter passed in
        /// </summary>
        /// <param name="param">A String object that tell us which window to open</param>
        public void Open(object param)
        {
            switch ((String)param)
            {
                case "AddCustomer" :
                    var addc = new View.Customer_Forms.AddCustomer();
                    addc.Show();
                    addc.Closed += new EventHandler(UpdateFields);
                    break;
                case "EditCustomer" :
                    var editc = new View.Customer_Forms.EditCustomer();
                    editc.Closed += new EventHandler(UpdateFields);
                    editc.Show();
                    break;
                case "RemoveCustomer":
                    var remc = new View.Customer_Forms.RemoveCustomer();
                    remc.Show();
                    remc.Closed += new EventHandler(UpdateFields);
                    break;
                case "AddService":
                    var adds = new View.Service_Forms.Add_Service();
                    adds.Show();
                    adds.Closed += new EventHandler(UpdateFields);
                    break;
                case "EditService":
                    var edits = new View.Service_Forms.Edit_Service();
                    edits.Show();
                    edits.Closed += new EventHandler(UpdateFields);
                    break;
                case "RemoveService":
                    var rems = new View.Service_Forms.Remove_Serivce();
                    rems.Show();
                    rems.Closed += new EventHandler(UpdateFields);
                    break;
                case "CustomerService":
                    var cs = new View.Link_Forms.Customer_Service();
                    cs.Show();
                    cs.Closed += new EventHandler(UpdateFields);
                    break;
                default:
                    return;
            }
        }
        #endregion

    }
}
