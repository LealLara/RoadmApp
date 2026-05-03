namespace RoadmApp.Domain.BusinessModel
{
    public class Success
    {
        public bool SuccessFlag { get; set; }
        public string Message { get; set; }
        public int LogId { get; set; }
        public List<object> Data { get; set; }

        public Success() { }

        public Success(bool successFlag, string message, int logId, List<object> data)
        {
            SuccessFlag = successFlag;
            Message = message;
            LogId = logId;
            Data = data;
        }
    }
}