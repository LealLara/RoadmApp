namespace RoadmApp.Domain.Models
{
    public class SuccessModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int LogId { get; set; }
        public List<object> Data { get; set; }

        public SuccessModel() { }

        public SuccessModel(bool success, string message, int logId, List<object> data)
        {
            Success = success;
            Message = message;
            LogId = logId;
            Data = data;
        }
    }
}