using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Lizard_s_Hangover
{
    public class Item
    {
        public Item()
        {

        }
        
        public Item(string itemName ,  bool inPossession = false)
        {
            _itemName = itemName;
            InPossession = inPossession;
        }

        public bool InPossession { get; set; }

        private string _itemName;

        public string ItemName
        {
            get {  return _itemName; } 
            set {  _itemName = value;  }

        }

       
        



    }
   
    

}
