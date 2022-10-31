using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _ABRAMS__CST_150_Milestone_2
{
    internal class Inventory

    {
        public Inventory(string code, string name, string cost, string quantity, string category)
        {
            Code = code;
            Name = name;
            Cost = cost;
            Quantity = quantity;
            Category = category;
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }
        public string Quantity { get; set; }
        public string Category { get; set; }

        public string fileFormat()
        {
            return Code + "," + Name + "," + Cost + "," + Quantity + "," + Category;
        }

        public string printFormat()
        {
            return Code + "\t\t" + Name + "\t\t" + Cost + "\t\t" + Quantity + "\t\t" + Category;
        }

    }
}
