using System;

namespace API.Errors
{
    public class ApiResponse
    {

        public int StatusCode { get; set; } 
        public string Message { get; set; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(StatusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch {
                400 => "A Bad request, you have made!",
                401 => "Authorised, you aren't",
                404 => "Resource found, it wasn't",
                500 => "Server Error, go to backend guy",
                _   => "Unexpected Error!"
            };
        }
    }
}