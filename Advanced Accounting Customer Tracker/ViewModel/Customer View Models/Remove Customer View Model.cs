using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Accounting_Customer_Tracker.ViewModel.Customer_View_Models
{
    public class Remove_Customer_View_Model : Base_Customer_View_Model
    {

        public Helpers.RelayCommand Remove { get; set; }

        public Remove_Customer_View_Model()
        {
            Remove = new Helpers.RelayCommand(RemoveFromDB, ItemSelected);
        }

        private bool ItemSelected(object obj)
        {
            return SelectedCustomer != null;
        }

        private void RemoveFromDB(object obj)
        {
            try
            {
                using (var db = new DataModelContext())
                {
                    db.Customers.Attach(SelectedCustomer);
                    db.Customers.Remove(SelectedCustomer);
                    db.SaveChanges();
                }

                EveryCustomer = null;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

    }
}
