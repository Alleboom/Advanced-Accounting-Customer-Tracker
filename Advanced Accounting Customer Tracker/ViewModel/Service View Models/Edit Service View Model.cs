using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Accounting_Customer_Tracker.ViewModel.Service_View_Models
{
    class Edit_Service_View_Model : Base_Add_Edit_Service_View_Model
    {



        private Service _SelectedService;
        public Helpers.RelayCommand Save { get; set; }
        

        public Edit_Service_View_Model()
        {
            Save = new Helpers.RelayCommand(SaveChangesToDB, ChangesMade);
        }


        public Service SelectedService
        {
            get
            {
                return _SelectedService;
            }

            set
            {
                if (value != _SelectedService)
                {
                    _SelectedService = value;
                    OnPropertyChanged("SelectedService");
                    NewDescription = _SelectedService.Description;
                    NewName = _SelectedService.Name;
                }
            }
        }

        private bool ChangesMade(object obj)
        {
            if (SelectedService != null)
            {
                return (SelectedService.Name != NewName || SelectedService.Description != NewDescription);
            }
            else
            {
                return false;
            }
        }

        private void SaveChangesToDB(object obj)
        {
            try
            {
                using (var db = new DataModelContext())
                {
                    SelectedService.Name = NewName;
                    SelectedService.Description = NewDescription;                    
                    db.Services.Attach(SelectedService);
                    db.Entry(SelectedService).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();
                }
                EveryService = null;
            }
            catch ( Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

    }
}
