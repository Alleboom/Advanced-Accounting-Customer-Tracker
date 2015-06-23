using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Accounting_Customer_Tracker.ViewModel.Service_View_Models
{
    public class Base_Add_Edit_Service_View_Model : VMBase
    {

        private String _newName, _newDescription;

        /// <summary>
        /// The new name to copy over into the db
        /// </summary>
        public String NewName
        {
            get
            {
                return _newName;
            }
            set
            {
                if (value != _newName)
                {
                    _newName = value;
                    OnPropertyChanged("NewName");
                }
            }
        }

        /// <summary>
        /// The new description to copy over into the db
        /// </summary>
        public String NewDescription
        {
            get
            {
                return _newDescription;
            }
            set
            {
                if (value != _newDescription) 
                {
                    _newDescription = value;
                    OnPropertyChanged("NewDescription");
                }
            }
        }

    }
}
