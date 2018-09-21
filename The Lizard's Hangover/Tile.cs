using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace The_Lizard_s_Hangover
{
    /// <summary>
    /// Represents the properties of a single tile on a map
    /// </summary>
    public class Tile
    {
        //This is a constructor with a parameter that has a default value, which means it's optional
        //And since this constructor has no parameters that don't have default values both of the following
        //are acceptable ways to create this class and they would be equivalent:
        //var tileX = new Tile(false);
        //and
        //var tileY = new Tile();

        public Tile(bool isAccessible = false)
        {
            IsAccessible = isAccessible;
        }

        //Another constructor that offers another way to create the object
        //Now there are several ways to create a new tile given that we have two constructors with default values.
        //var a = new Tile();
        //var b = new Tile(true);
        //var c = new Tile("An Awesome Tile");
        //var d = new Tile("Another awesome tile", true);
        public Tile(string tileName, bool isAccessible = false)
        {
            _tileName = tileName;
            //^^^ Notice that since we're using the long form of the TileName property
            //we can assign the value to _tileName or TileName with the same result here
            //Later, with more complex properties it will make a difference which way you go
            //The difference is when you assign directly to the underlying value, no code in the 
            //property setter is executed. More on this next time we get together.
            IsAccessible = isAccessible;
        }


        //This is the short way to write a property and you should use it when you need to add a property
        //that looks and behaves like a public member. We can talk about the reasons why you'd do this..
        public bool IsAccessible { get; set; }

        public bool ContainsItem { get; set; }

        public bool TorchLit { get; set; }

        //Here's the way to write the long form of a property
        private string _tileName; // This is the private member that actually stores the value 

        public string TileName //this is the public member that is accessible from the outside of the class
        {
            get { return _tileName; } //This is a getter. It's the code that returns the value
            set { _tileName = value; } //The code that sets the value. 
        }
        
        private string _tileDescription = "";
        
        
        //This is just the default description for the tile. the starting point. ***Where is the best place
        //to write out each accessible tile's description.its alot of writing(so a different page) but 
        //wont need a class of its own, will it? whats the best way to do that?***
        public string TileDescription  
        {
            get { return _tileDescription; }
            set { _tileDescription = value; }

        }

        //You could also use public members like this
        //public string TileName;

        //This is legal of course, but you shouldn't do it. I'll explain why later. Just get in the habit of
        //using properties instead

    }
}
