using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurfManager.Models
{
    public partial class ActionSummary
    {
        public int ActionID { get; set; }
        public string ActionName { get; set; }
        public string ActionIcon { get; set; }
        public DateTime? ActionLastDate { get; set; }
        public int? ActionDaysAgo { get; set; }

    }
}

