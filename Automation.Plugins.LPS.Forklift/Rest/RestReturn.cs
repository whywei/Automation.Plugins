
using Automation.Plugins.Common.Forklift;
namespace Automation.Plugins.LPS.Forklift.Rest
{
    public class RestReturn
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ForkliftJsonTask Data { get; set; }
    }

    public class RestReturn<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
