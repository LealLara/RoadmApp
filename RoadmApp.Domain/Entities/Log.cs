namespace RoadmApp.Domain.Entities
{
    public class Log
    {
        public int LogId { get; private set; }
        public string LogMessage { get; private set; }
        public int LogTypeId { get; private set; }
        public int UserId { get; private set; }

        public Log() { }
        public Log(string logMessage, int logTypeId, int userId) : this()
        {
            LogMessage = logMessage;
            LogTypeId = logTypeId;
            UserId = userId;
        } 
    }
}