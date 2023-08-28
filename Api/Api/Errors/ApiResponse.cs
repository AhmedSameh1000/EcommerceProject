namespace Api.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int status,string message=null)
        {
            this.Status = status;
            this.Message = message??GetDefaultMessageForStatusCode(status);
        }
        public int Status { get; set; }
        public string Message { get; set; }
        private string GetDefaultMessageForStatusCode(int status)
        {
            return status switch
            {
                400=>"Bad Request you Have Made",
                401=>"You Are No Authorized",
                404=>"Response Found it is not",
                500=>"Server Error Occured",
                _=>null
            };
        }
    }
}
