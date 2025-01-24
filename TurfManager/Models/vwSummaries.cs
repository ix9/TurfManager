using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurfManager.Models
{
    public partial class vwSummaries
    {
        public int ID { get; set; }
        public string SummaryDateString { get; set; }
        public DateTime SummaryDateTime { get; set; }
        public decimal MaxTemp { get; set; }
        public decimal MinTemp { get; set; }
        public decimal GDDNumber { get; set; }
    }
}

