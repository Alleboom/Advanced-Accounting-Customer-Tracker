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

        /// <summary>
        /// Default constructor, creates a new Relay command
        /// </summary>
        public Add_Service_View_Model()
        {
            Save = new Helpers.RelayCommand(SaveToDB, NameFilledOut);
        }

        /// <summary>
        /// Checks to make sure Service has a name before saving.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Whether the control has text or not</returns>
        private bool NameFilledOut(object obj)
        {
            return (NewName != "" || NewName != null);
        }

        /// <summary>
        /// Saves to the database
        /// </summary>
        /// <param name="obj"></param>
        private void SaveToDB(object obj)
        {
            try
            {
                using (var db = new DataModel())
                {
                    db.Database.Log = Console.WriteLine;
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
