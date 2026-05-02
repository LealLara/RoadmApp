using RoadmApp.Domain.BusinessModel;

namespace RoadmApp.Api.PresentationModels.Results
{
    public class SuccessDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int LogId { get; set; }
        public List<object> Data { get; set; }

        public SuccessDto() { }
        public SuccessDto(bool success, string message, int logId, List<object> data)
        {
            Success = success;
            Message = message;
            LogId = logId;
            Data = data;
        }
        public SuccessDto Transform(Success success)
        {
            return new()
            {
                Success = success.SuccessFlag,
                Message = success.Message,
                LogId = success.LogId,
                Data = success.Data,
            };
        }
    }
}