namespace WiseSwitchApi.Helpers
{
    public class ApiResponse
    {
        public bool IsError { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }


        public static ApiResponse GenericError => new ApiResponse { IsError = true, Message = "Error: something went wrong." };

        public static ApiResponse ErrorDataReturnedNull => new ApiResponse { IsError = true, Message = "Error: data returned null." };


        public static ApiResponse CustomError(string message)
        {
            return new ApiResponse { IsError = true, Message = message };
        }
    }
}
