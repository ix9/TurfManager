using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurfManager.Models
{
    public partial class vwActions
    {
        public int ID { get; set; }
        public string ActionDateString { get; set; }
        public string Action { get; set; }
        public string ActionName { get; set; }
        public string ActionIcon { get; set; }
    }
}

