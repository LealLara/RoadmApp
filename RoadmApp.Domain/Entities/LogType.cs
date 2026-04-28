namespace RoadmApp.Domain.Entities
{
    public class LogType
    {
        public int LogTypeId { get; private set; }
        public string LogTypeName { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
    }
}