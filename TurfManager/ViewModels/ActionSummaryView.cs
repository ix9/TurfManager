using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurfManager.Models
{
    public partial class ActionSummaryView
    {
        public int actionID { get; set; }
        public string actionName { get; set; }
        public string actionIcon { get; set; }
        public DateTime? actionLastDate { get; set; }
        public int? actionDaysAgo { get; set; }

    }
}

