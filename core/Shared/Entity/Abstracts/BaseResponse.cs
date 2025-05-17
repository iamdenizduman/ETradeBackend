namespace Shared.Entity.Abstracts
{
    public abstract class BaseResponse
    {
        public bool isSuccess { get; set; }
        public string text { get; set; }
    }
}
