using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RFC.Attributes
{
    public class CloneAtr : Attribute
    {
        private IEnumerable<Type> types;
        public CloneAtr()
        {
            types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsDefined(typeof(CloneAtr)));
        }
        public IEnumerable<Type> GetClasses()
        {
            return types;
        }
    }
}
