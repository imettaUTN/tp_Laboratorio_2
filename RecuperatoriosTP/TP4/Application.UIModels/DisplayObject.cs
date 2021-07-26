using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UIModels
{
    public class DisplayObject
    {
        public DisplayObject() { }
        public DisplayObject(string name, int value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; set; }
        public int Value { get; set; }
    }

}
