using RoadmApp.Application.Responses;
using RoadmApp.Domain.BusinessModel;

namespace RoadmApp.Api.PresentationModels.Results
{
    public class SuccessResults
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int LogId { get; set; }
        public List<object> Data { get; set; }

        public SuccessResults() { }
        public SuccessResults(bool success, string message, int logId, List<object> data)
        {
            Success = success;
            Message = message;
            LogId = logId;
            Data = data;
        }
        public SuccessResults Transform(SuccessModel success)
        {
            return new()
            {
                Success = success.Success,
                Message = success.Message,
                LogId = success.LogId,
                Data = success.Data,
            };
        }
    }
}