using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Accounting_Customer_Tracker.ViewModel.Service_View_Models
{
    public class Add_Service_View_Model : Base_Add_Edit_Service_View_Model
    {

        public Helpers.RelayCommand Save { get; set; }

        public Add_Service_View_Model()
        {
            Save = new Helpers.RelayCommand(SaveToDB, NameFilledOut);
        }

        private bool NameFilledOut(object obj)
        {
            return (NewName != "" || NewName != null);
        }

        private void SaveToDB(object obj)
        {
            try
            {
                using (var db = new DataModelContext())
                {
                    db.Services.Add(new Service
                    {
                        Description = NewDescription,
                        Name = NewName,
                    });

                    db.SaveChanges();

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
