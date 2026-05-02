namespace RoadmApp.Application.Responses
{
    public class LogModel
    {
        public int LogId { get; private set; }
        public string LogMessage { get; private set; }
        public int LogTypeId { get; private set; }
        public int UserId { get; private set; }

        public LogModel() { }
        public LogModel(string logMessage, int logTypeId, int userId) : this()
        {
            LogMessage = logMessage;
            LogTypeId = logTypeId;
            UserId = userId;
        }
        public LogModel(int logId, string logMessage, int logTypeId, int userId, DateTime createdAt) : this()
        {
            LogId = logId;
            LogMessage = logMessage;
            LogTypeId = logTypeId;
            UserId = userId;
        }
    }
}