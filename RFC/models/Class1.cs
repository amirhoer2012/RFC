using RFC.Attributes;
using RFC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFC.models
{
    [CloneAtr]
    public class Class1:Class2, Interface1
    {
        public Class1(){
            ID = Guid.NewGuid();
        }
        public Guid ID { get; set; }
        public string ClassName;
        private int? counter;
        public int NumberOfCalling()
        {
            return (int)(counter == null ? counter = 0 : counter++);
        }
    }
}
