using System.Net;

namespace AddressManagement.ClassLibrary.Classes
{
    public class Result
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class Result<TValue> : Result
    {
        public TValue? Value { get => _value; set => _value = value; }
        private TValue? _value;

        public Result()
        {
        }
    }
}
