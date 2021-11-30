using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurfManager.Models
{
    public class SummaryView
    {
        public int summaryId { get; set; }
        public DateTime summaryDateGenerated { get; set; }
        public DateTime summaryDateWst { get; set; }
        public string summaryDateString { get; set; }
        public decimal? summaryMaxTemp { get; set; }
        public decimal? summaryMinTemp { get; set; }
        public decimal? summaryGddtotal { get; set; }
        public decimal? summaryGddcumulative { get; set; }
        public string? summaryBackgroundTR { get; set; }
        public bool? summaryApplication { get; set; }
        public int? summaryAction { get; set; }
        public string? summaryActionName { get; set; }
        public string? summaryActionIcon { get; set; }
    }
}
