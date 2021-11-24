using System;
using System.Collections.Generic;

namespace TurfManager.Models
{
    public partial class Summary
    {
        public int SummaryId { get; set; }
        public DateTime SummaryDateGenerated { get; set; }
        public DateTime SummaryDateWst { get; set; }
        public string SummaryDateString { get; set; }
        public decimal? SummaryMaxTemp { get; set; }
        public decimal? SummaryMinTemp { get; set; }
        public decimal? SummaryGddtotal { get; set; }
        public bool? SummaryApplication { get; set; }
        public int? SummaryAction { get; set; }
        //test again
        //public string? SummaryActionName { get; set; }
        //public string? SummaryActionIcon { get; set; }

    }
}
