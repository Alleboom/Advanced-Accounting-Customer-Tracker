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
        

        /// <summary>
        /// Default constructor, creates a new RelayCommand
        /// </summary>
        public Edit_Service_View_Model()
        {
            Save = new Helpers.RelayCommand(SaveChangesToDB, ChangesMade);
        }

        /// <summary>
        /// The selected service to be modified.
        /// </summary>
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


        /// <summary>
        /// Checks for any changes made between the selected services and the controls present on the form
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True for changes, False for equal values</returns>
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


        /// <summary>
        /// Saves the changes made to the service to the database
        /// </summary>
        /// <param name="obj"></param>
        private void SaveChangesToDB(object obj)
        {
            try
            {
                using (var db = new DataModel())
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
                using (System.IO.TextWriter log = new System.IO.StreamWriter("log.txt"))
                {
                    log.WriteLine(ex.Message + " " + System.DateTime.Today.ToString());
                }
            }
        }

    }
}
