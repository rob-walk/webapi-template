using System;

namespace WebApi.Common.Domain
{
    public class Eventlog : Entity
    {
        public long EventLogId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public string Username { get; set; }
        public string HostName { get; set; }
    }
}
