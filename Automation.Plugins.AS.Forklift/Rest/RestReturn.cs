
using Automation.Plugins.Common.Forklift;
namespace Automation.Plugins.AS.Forklift.Rest
{
    public class RestReturn
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ForkliftTask Data { get; set; }
    }

    public class RestReturn<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
