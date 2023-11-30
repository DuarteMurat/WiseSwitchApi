namespace WiseSwitchApi.Helpers
{
    public class ApiResponse
    {
        public bool IsError { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }
    }
}
