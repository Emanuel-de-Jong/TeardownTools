using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeardownTools.Models
{
    public class ChangeModel
    {
        // PROPERTIES
        public string FunctionName { get; set; }
        public string[] Before { get; set; }
        public string[] After { get; set; }
        public string[] Code { get; set; }
    }
}
