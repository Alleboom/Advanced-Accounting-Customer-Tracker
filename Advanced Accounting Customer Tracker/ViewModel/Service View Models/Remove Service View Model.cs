using Advanced_Accounting_Customer_Tracker.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Accounting_Customer_Tracker.ViewModel.Service_View_Models
{
    public class Remove_Service_View_Model : Base_Service_View_Model
    {

        public RelayCommand Remove { get; set; }
        public Service SelectedService { get; set; }



        public Remove_Service_View_Model(){
            Remove = new RelayCommand(RemoveFromDB, ServiceSelected);
            EveryService = null;
        }

        private bool ServiceSelected(object obj)
        {
            return SelectedService != null;
        }

        private void RemoveFromDB(object obj)
        {
            try
            {
                using (var db = new DataModelContext())
                {
                    db.Services.Attach(SelectedService);
                    db.Services.Remove(SelectedService);
                    db.SaveChanges();
                }
                EveryService = null;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

    }
}
