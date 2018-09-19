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
    //Item sub-classes specific items each one has a pickup method that will give the player a choice
    //to pick up that item. the method needs to be ran when the player position matches the _mapgrid tile
    //that contains the item. then add it to the inventory if the player presses 'Y'.
    class Sword : Item
    {
       public Sword(): base()
        {

        }
       public Sword(string itemName , bool inPossession) : base( itemName , inPossession)
        {

        }
       public void PickupSword()
        {
            this.InPossession = true;
        }
    }
    class MapItem : Item
    {
        public MapItem() : base()
        {

        }
        public MapItem(string itemName, bool inPossession) : base(itemName, inPossession)
        {

        }
        public void PickupMap(Player _player)
        {
            if (_player.PlayerX == 3 && _player.PlayerY == 8)
            {
                this.InPossession = true;
                Console.WriteLine("you gotta map!");
            }
           
        }
    }

    class Potion : Item
    {
        public Potion() : base()
        {

        }
        public Potion(string itemName, bool inPossession) : base(itemName, inPossession)
        {

        }
        public void PickupPotion()
        {
            this.InPossession = true;
        }
    }

    class GemStone : Item
    {
        public GemStone() : base()
        {

        }
        public GemStone(string itemName, bool inPossession) : base(itemName, inPossession)
        {

        }
        public void PickupGemStone()
        {
            this.InPossession = true;
        }
    }
    class Torch : Item
    {
        public Torch() : base()
        {

        }
        public Torch(string itemName, bool inPossession) : base(itemName, inPossession)
        {

        }
        public void PickupTorch()
        {
            this.InPossession = true;
        }
    }
}
