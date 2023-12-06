using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace WiseSwitchApi.Helpers
{
    public static class ExceptionHandling
    {
        public static string GetErrorMessage(Exception ex)
        {
            if (ex is DbUpdateException && ex.InnerException is SqlException innerEx)
            {
                if (innerEx.Message.Contains("IX_"))
                {
                    return "This object already exists.";
                }
            }

            return null;
        }
    }
}
