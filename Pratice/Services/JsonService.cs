using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Pratice.Models;
using System.IO;

namespace Pratice.Services
{
    public class JsonService
    {
        public void SaveLogs(IEnumerable<LogEntry> logs) 
        {
            string json = JsonSerializer.Serialize(
                logs,
                new JsonSerializerOptions
                    { 
                        WriteIndented = true,
                }
            );   


            File.WriteAllText("logs.json", json);
        }
    }
}
