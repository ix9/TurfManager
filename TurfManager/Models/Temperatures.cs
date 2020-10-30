using System;
using System.Collections.Generic;

namespace TurfManager.Models
{
    public partial class Temperatures
    {
        public int ReadingKey { get; set; }
        public string ReadingDateString { get; set; }
        public DateTime ReadingDateTimeWst { get; set; }
        public decimal ReadingValue { get; set; }
    }
}
