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

                if (innerEx.Message.Contains("FK_"))
                {
                    return "This object won't be deleted because there are dependent objects.";
                }
            }

            return null;
        }
    }
}
