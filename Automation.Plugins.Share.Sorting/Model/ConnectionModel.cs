using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Automation.Plugins.YZ.Sorting.Model
{
    public class ConnectionModel
    {
        public string IP { get; set; }
        public string DataBaseName { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
