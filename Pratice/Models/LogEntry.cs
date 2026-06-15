using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Models
{
    public class LogEntry
    {
        public DateTime Time { get; set; }

        public string Type { get; set; }

        public string Message { get; set; }

        public int Temperature { get; set; }

        public int Pressure { get; set; }
    }
}
