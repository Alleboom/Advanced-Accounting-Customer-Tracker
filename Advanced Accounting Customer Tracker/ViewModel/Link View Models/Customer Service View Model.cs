using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Accounting_Customer_Tracker.ViewModel.Link_View_Models
{
    public class Customer_Service_View_Model : VMBase
    {

        #region members
        private ObservableCollection<Service> _CustomerServicesList;
        private ObservableCollection<Service> _PotentialServiceList;
        private Customer _SelectedCustomer;        
        private Service _SelectedPotentialService;
        private Service _SelectedActualService;
        #endregion

        #region properties


        public Helpers.RelayCommand AddPotentialService { get; set; }
        public Helpers.RelayCommand RemoveActualService { get; set; }
        public Helpers.RelayCommand SaveToDB { get; set; }


        /// <summary>
        /// The selected Customer
        /// </summary>
        public Customer SelectedCustomer
        {
            get
            {
                return _SelectedCustomer;
            }
            set
            {
                if (value != _SelectedCustomer)
                {
                    _SelectedCustomer = value;
                    OnPropertyChanged("SelectedCustomer");
                    UpdateLists();
                }
            }
        }

        /// <summary>
        /// The selected service from the list of services not currently offered to the customer
        /// </summary>
        public Service SelectedPotentialService
        {
            get
            {
                return _SelectedPotentialService;
            }
            set
            {
                if (value != _SelectedPotentialService)
                {
                    _SelectedPotentialService = value;
                    OnPropertyChanged("SelectedPotentialService");
                }
            }
        }


        /// <summary>
        /// An actual service the customer currently has attached to it
        /// </summary>
        public Service SelectedActualService
        {
            get
            {
                return _SelectedActualService;
            }
            set
            {
                if (value != _SelectedActualService)
                {
                    _SelectedActualService = value;
                    OnPropertyChanged("SelectedActualService");
                }
            }
        }

        /// <summary>
        /// The list of customer service currently tied to the selected customer
        /// </summary>
        public ObservableCollection<Service> ActualServicesList
        {
            get { 
                return _CustomerServicesList;
            }
            set
            {
                if (_CustomerServicesList != value)
                {
                    _CustomerServicesList = value;
                    OnPropertyChanged("CustomerServiceList");
                }
            }
        }

        /// <summary>
        /// The list of service not attached to the selected customer
        /// </summary>
        public ObservableCollection<Service> PotentialServiceList
        {
            get
            {
                return _PotentialServiceList;
            }

            set
            {
                if (value != _PotentialServiceList)
                {
                    _PotentialServiceList = value;
                    OnPropertyChanged("PotentialServiceList");
                }
            }
        }
        #endregion

        #region methods
        /// <summary>
        /// Creates new collection and instantiates our commands
        /// </summary>
        public Customer_Service_View_Model()
        {
            ActualServicesList = new ObservableCollection<Service>();
            PotentialServiceList = new ObservableCollection<Service>();
            AddPotentialService = new Helpers.RelayCommand(PotentialToActiveService, PotentialServiceSelected);
            RemoveActualService = new Helpers.RelayCommand(ActiveToPotentialService, ActualServiceSelected);
            SaveToDB = new Helpers.RelayCommand(SaveEntriesToDB, ListsChanged);

        }

        /// <summary>
        /// Checks to see if the lists are different from the database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>A true if the lists are different from the database</returns>
        private bool ListsChanged(object obj)
        {
            bool listchanged = true;
            //try
            //{
            //    using (var db = new DataModelContext())
            //    {
            //        // create a temprory list of the actual services from the database
            //        List<Service> actualservices = new List<Service>();

            //        foreach (CustomerServiceAssociative item in db.CustomerServiceAssociatives)
            //        {
            //            // check for the cust serv asso if it has the same customer id
            //            if (SelectedCustomer.Id == item.CustomerID)
            //            {
            //                // if the service does belong to the customer AND it is in the pontential services list, we know the lists have changed
            //                if (PotentialServiceList.Contains(item.Service))
            //                {
            //                    listchanged = true;
            //                    break;
            //                }
            //                actualservices.Add(item.Service);
            //            }
            //        }

            //        //now check the local actual services list if it has a service that we did not have from the database
            //        foreach (var item in actualservices)
            //        {
            //            if (!ActualServicesList.Contains(item))
            //            {
            //                listchanged = true;
            //                break;
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message);
            //}

            return listchanged;
        }

        /// <summary>
        /// Save the entries from our form to the database
        /// </summary>
        /// <param name="obj"></param>
        private void SaveEntriesToDB(object obj)
        {
            try
            {
                using (var db = new DataModel())
                {
                    // clear the customerServiceAssociatves table
                    //SelectedCustomer.CustomerServiceAssociatives.Clear();
                    bool addtodb = true;
                    //now add a new Customer Service Associative with the selected customer and each service in our ActualService List
                    foreach (var service in ActualServicesList)
                    {
                        foreach (var item in db.CustomerServiceAssociatives)
                        {
                            // if we already have a match do not add to db
                            if (SelectedCustomer.Id == item.CustomerID && service.Id == item.ServiceID)
                            {
                                addtodb = false;
                            }
                        }
                        if (addtodb)
                        {
                            db.CustomerServiceAssociatives.Add(new CustomerServiceAssociative()
                            {
                                CustomerID = SelectedCustomer.Id,
                                ServiceID = service.Id,
                            });
                        }
                        addtodb = true;
                    }

                    foreach (var service in PotentialServiceList)
                    {
                        foreach (var custserv in db.CustomerServiceAssociatives)
                        {
                            if (custserv.CustomerID == SelectedCustomer.Id)
                            {
                                if (service.Id == custserv.ServiceID)
                                {
                                    db.CustomerServiceAssociatives.Remove(custserv);
                                }
                            }
                        }
                    }

                    db.SaveChanges();
                    System.Windows.Forms.MessageBox.Show("Services attached to customer");
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Checks for an non null Actual Service
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool ActualServiceSelected(object obj)
        {
            return SelectedActualService != null;
        }

        /// <summary>
        /// Transfers the service from actual to pontential service list
        /// </summary>
        /// <param name="obj"></param>
        private void ActiveToPotentialService(object obj)
        {
            PotentialServiceList.Add(SelectedActualService);
            ActualServicesList.Remove(SelectedActualService);
            SelectedActualService = null;
        }

        /// <summary>
        /// Checks for an actual Potential Service selected
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool PotentialServiceSelected(object obj)
        {
            return SelectedPotentialService != null;
        }

        /// <summary>
        /// Transfers the service from pontential to actual service list
        /// </summary>
        /// <param name="obj"></param>
        private void PotentialToActiveService(object obj)
        {
            ActualServicesList.Add(SelectedPotentialService);
            PotentialServiceList.Remove(SelectedPotentialService);
            SelectedPotentialService = null;
        }

        /// <summary>
        /// Updates the services with the values from the database
        /// </summary>
        public void UpdateLists()
        {
            // reset our local lists
            PotentialServiceList.Clear();
            ActualServicesList.Clear();
            try
            {
                // get each service and assign to appropriate list
                using (var db = new DataModel())
                {

                        foreach (var customerservice in db.CustomerServiceAssociatives)
	                    {

                            // get the ones that are attached
                            if (customerservice.CustomerID == SelectedCustomer.Id)
                            {
                                ActualServicesList.Add(customerservice.Service);
                            }

	                    }

                        foreach (var item in db.Services)
                        {
                            // get the ones not attached
                            if (!ActualServicesList.Contains(item))
                            {
                                PotentialServiceList.Add(item);
                            }
                        }

                        
                    
                }
                
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        #endregion

    }
}
