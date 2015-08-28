using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Accounting_Customer_Tracker.Data_Access_Layer
{
    public abstract class DataAccess
    {

        /// <summary>
        /// Method that looks at what class we are saving and adds it to the appropriate table
        /// </summary>
        /// <typeparam name="T">The class of the object to save. If the class is unsupported, method will throw a general exception</typeparam>
        /// <param name="ItemToAdd">The actuall instance of the class to add to the database</param>
        public static void AddToDB<T>(T ItemToAdd) where T : class
        {

            //Type _typeOfItemToAdd = ItemToAdd.GetType();

            //if (_typeOfItemToAdd.Equals(Customer))
            //{

            //}
        }
        }
}
