using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Advanced_Accounting_Customer_Tracker.Globals
{
    public class Globals : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Customer> _CustomerList = new ObservableCollection<Customer>();
        private ObservableCollection<Service> _ServiceList = new ObservableCollection<Service>();

        public event EventHandler MasterListUpdated;

        /// <summary>
        /// A single Customer List for all controls to use. 
        /// Many controls need an observable collection, so this is list of each one.
        /// </summary>
        public ObservableCollection<Customer> CustomerList
        {
            get
            {
                try
                {
                    using(var db = new DataModel())
                    {
                        _CustomerList.Clear();
                        foreach (var cust in db.Customers)
                        {
                            _CustomerList.Add(cust);
                        }
                    }
                    this.OnPropertyChanged("CustomerList");
                    MasterListUpdated.Invoke(this, new EventArgs());
                }
                catch(Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message);
                    using (System.IO.TextWriter log = new System.IO.StreamWriter("log.txt"))
                    {
                        log.WriteLine(e.Message  + " " + System.DateTime.Today.ToString());
                    }
                }
                return _CustomerList;
            }
        }

        /// <summary>
        /// A single Service List for all controls to use. 
        /// Many controls need an observable collection, so this is list of each one.
        /// </summary>
        public ObservableCollection<Service> ServiceList
        {
            get
            {
                try
                {
                    _ServiceList.Clear();
                    using(var db = new DataModel())
                    {
                        foreach (var item in db.Services)
                        {
                            _ServiceList.Add(item);
                        }
                    }
                    MasterListUpdated.Invoke(this, new EventArgs());
                }
                catch(Exception e)
                {
                    System.Windows.MessageBox.Show(e.Message);
                    using(System.IO.TextWriter text = new System.IO.StreamWriter("log.txt"))
                    {
                        text.WriteLine(e.Message + " " + System.DateTime.Today.ToString());
                    }
                }

                return _ServiceList;
            }
        }

        protected void OnPropertyChanged(string prop)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(prop));
            }
        }

    }
}
