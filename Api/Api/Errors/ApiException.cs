namespace Api.Errors
{
    public class ApiException : ApiResponse
    {
        public ApiException(int status, string message = null,string details=null) : base(status, message)
        {
            this.Details = details;
        }
        public string Details { get; set; }
    }
}
