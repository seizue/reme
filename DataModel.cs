using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reme
{
  
    public class DataModel
    {
        public int ID { get; set; }
        public string ITEMS { get; set; }
        public int PRICE { get; set; }
        // Add other properties as needed


        // Constructor to initialize the ID
        public DataModel()
        {
            // You can generate the ID as needed, for example:
            ID = GenerateUniqueID();
        }
     

        private static int nextID = 1;

        private static int GenerateUniqueID()
        {
            return nextID++;
        }

    }

}
