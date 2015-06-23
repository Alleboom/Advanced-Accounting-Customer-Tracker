using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Advanced_Accounting_Customer_Tracker.ViewModel.Customer_View_Models
{
    public class Add_Customer_View_Model : Base_Customer_View_Model
    {
        public Helpers.RelayCommand Save {get;set;}

        public Add_Customer_View_Model()
        {
            Save = new Helpers.RelayCommand(SaveToDb, RequiredFieldsFilled);
        }

        private bool RequiredFieldsFilled(object obj)
        {
            return NewName != null;
        }

        private void SaveToDb(object obj)
        {
            try
            {
                using (var db = new DataModelContext())
                {
                    db.Database.Log = Console.WriteLine;
                    db.Customers.Add(new Customer()
                    {
                        Name = NewName,
                        Accounting_Method = NewAccountingMethod,
                        Address = NewAddress,
                        Cell_Phone_Number = NewCellNumber,
                        Email = NewEmail,
                        Phone_Number = NewPhoneNumber,
                        Tax_Form = NewTaxForm,
                    });

                    db.SaveChanges();

                    EveryCustomer = null;
                    CloseAction();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
