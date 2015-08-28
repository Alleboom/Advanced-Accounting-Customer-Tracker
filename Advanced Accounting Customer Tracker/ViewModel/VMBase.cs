﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Accounting_Customer_Tracker.ViewModel
{
    abstract public class VMBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Action CloseAction { get; set; }

        protected void OnPropertyChanged(string prop)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(prop));
            }
        }

        /// <summary>
        /// The list of customers in the database, returned as an observable collection
        /// </summary>
        public ObservableCollection<Customer> EveryCustomer
        {
            
            get
            {
                
                var list = new ObservableCollection<Customer>();
                try {
                    using (var db = new DataModel())
                    {
                        foreach (var item in db.Customers)
                        {
                            list.Add(item);
                        }
                    }
                }catch(Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message);
                }

                return list;
                
            }

            set
            {
                OnPropertyChanged("EveryCustomer");
            }
        }

        public ObservableCollection<Service> EveryService
        {
            get
            {
                var list = new ObservableCollection<Service>();
                try {
                    using (var db = new DataModel())
                    {
                        foreach (var item in db.Services)
                        {
                            list.Add(item);
                        }
                    }
                }
                catch(Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message);
                }
                return list;
            }
            set
            {
                OnPropertyChanged("EveryService");
            }
        }

        public VMBase()
        {

        }

    }
}
