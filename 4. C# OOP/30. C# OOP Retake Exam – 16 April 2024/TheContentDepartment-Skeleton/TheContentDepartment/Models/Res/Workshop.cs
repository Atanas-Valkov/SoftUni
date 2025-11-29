using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheContentDepartment.Models.Entities
{
    internal class Workshop : Resource
    {
        private const int ConstantPriority = 2;
        public Workshop(string name, string creator) 
            : base(name, creator, ConstantPriority)
        {
        }
    }
}
