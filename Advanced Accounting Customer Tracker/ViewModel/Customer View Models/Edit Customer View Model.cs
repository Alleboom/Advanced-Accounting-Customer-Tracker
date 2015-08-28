using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Accounting_Customer_Tracker.ViewModel.Customer_View_Models
{
    public class Edit_Customer_View_Model : Base_Customer_View_Model
    {

        public Helpers.RelayCommand Save { get; set; }

        public Edit_Customer_View_Model()
        {
            Save = new Helpers.RelayCommand(SaveToDb, PropertiesChanged);
        }

        /// <summary>
        /// Lets us know if any of the customers properties in the view have changed
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True if controls have different values than the original object</returns>
        private bool PropertiesChanged(object obj)
        {
            //check to see if properties have changed
            if (_SelectedCustomer != null){
                return ((NewAccountingMethod != _SelectedCustomer.Accounting_Method ||
                    NewAddress != _SelectedCustomer.Address ||
                    NewCellNumber != _SelectedCustomer.Cell_Phone_Number ||
                    NewEmail != _SelectedCustomer.Email ||
                    NewName != _SelectedCustomer.Name ||
                    NewPhoneNumber != _SelectedCustomer.Phone_Number ||
                    NewTaxForm != _SelectedCustomer.Tax_Form ) &&
                    _SelectedCustomer != null);
            }
            else{
                return false;
            }
        }

        /// <summary>
        /// Saves the selected customer back to the database with the changes made to the control
        /// </summary>
        /// <param name="obj"></param>
        private void SaveToDb(object obj)
        {
            try
            {
                using (var db = new DataModel())
                {

                    SelectedCustomer.Accounting_Method = NewAccountingMethod;
                    SelectedCustomer.Address = NewAddress;
                    SelectedCustomer.Cell_Phone_Number = NewCellNumber;
                    SelectedCustomer.Email = NewEmail;
                    SelectedCustomer.Name = NewName;
                    SelectedCustomer.Phone_Number = NewPhoneNumber;
                    SelectedCustomer.Tax_Form = NewTaxForm;
                    db.Customers.Attach(SelectedCustomer);
                    db.Entry(SelectedCustomer).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                EveryCustomer = null;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Changes the values in the control to the values of the 
        /// selected customer and updates our pointer to that customer object
        /// </summary>
        public new Customer SelectedCustomer
        {
            get
            {
                return _SelectedCustomer;
            }
            set
            {
                if (_SelectedCustomer != value)
                {
                    _SelectedCustomer = value;
                    OnPropertyChanged("SelectedCusomter");
                    NewAccountingMethod = _SelectedCustomer.Accounting_Method;
                    NewName = _SelectedCustomer.Name;
                    NewPhoneNumber = _SelectedCustomer.Phone_Number;
                    NewCellNumber = _SelectedCustomer.Cell_Phone_Number;
                    NewEmail = _SelectedCustomer.Email;
                    NewTaxForm = _SelectedCustomer.Tax_Form;
                    NewAddress = _SelectedCustomer.Address;
                }
            }
        }
        

    }
}
