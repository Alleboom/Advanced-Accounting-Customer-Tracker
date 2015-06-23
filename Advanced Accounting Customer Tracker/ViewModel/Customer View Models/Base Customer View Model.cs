using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Accounting_Customer_Tracker.ViewModel.Customer_View_Models
{
    /// <summary>
    /// Base Customer view models, supports basic variables to add or modify a customer record, such as a new name and phone number
    /// </summary>
    public class Base_Customer_View_Model : VMBase
    {
        private String _NewName, _NewPhoneNumber, _NewCellNumber, _NewEmail, _NewTaxForm, _NewAccountingMethod, _NewAddress;
        protected Customer _SelectedCustomer;
        #region Properties
        public String NewName
        {
            get
            {
                return _NewName;
            }
            set
            {
                if (value != _NewName)
                {
                    _NewName = value;
                    OnPropertyChanged("NewName");
                }
            }
        }
        public String NewPhoneNumber
        {
            get
            {
                return _NewPhoneNumber;
            }
            set
            {
                if (value != _NewPhoneNumber)
                {
                    _NewPhoneNumber = value;
                    OnPropertyChanged("NewPhoneNumber");
                }
            }
        }
        public String NewCellNumber
        {
            get
            {
                return _NewCellNumber;
            }
            set
            {
                if (value != _NewCellNumber)
                {
                    _NewCellNumber = value;
                    OnPropertyChanged("NewCellNumber");
                }
            }
        }
        public String NewEmail
        {
            get
            {
                return _NewEmail;
            }
            set
            {
                if (value != _NewEmail)
                {
                    _NewEmail = value;
                    OnPropertyChanged("NewEmail");
                }
            }
        }
        public String NewTaxForm
        {
            get
            {
                return _NewTaxForm;
            }
            set
            {
                if (value != _NewTaxForm)
                {
                    _NewTaxForm = value;
                    OnPropertyChanged("NewTaxForm");
                }
            }
        }
        public String NewAccountingMethod
        {
            get
            {
                return _NewAccountingMethod;
            }
            set
            {
                if (value != _NewAccountingMethod)
                {
                    _NewAccountingMethod = value;
                    OnPropertyChanged("NewAccountingMethod");
                }
            }
        }
        public String NewAddress
        {
            get
            {
                return _NewAddress;
            }
            set
            {
                if (value != _NewAddress)
                {
                    _NewAddress = value;
                    OnPropertyChanged("NewAddress");
                }
            }
        }
        /// <summary>
        /// The SelectedCustomer from our list
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
                }
            }
        }
        #endregion
    }
}
