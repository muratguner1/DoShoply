namespace DoShoply.Core.Common
{
    public class BaseResponseModel
    {
        public bool Success { get; set; }
        public dynamic Message { get; set; }
        public dynamic Exception { get; set; }
        public object Result { get; set; }
    }
}
