using Microsoft.AspNetCore.Mvc;

namespace WiseSwitchApi.Helpers
{
    public class ControllerHelper
    {
        private readonly DataHelper _dataHelper;

        public ControllerHelper(DataHelper dataHelper)
        {
            _dataHelper = dataHelper;
        }


        public async Task<IActionResult> TryGet(string dataOperation, object value)
        {
            try
            {
                var model = await _dataHelper.GetDataAsync(dataOperation, value);
                if (model == null) return DataNull();

                // Success.
                return Success(model);
            }
            catch
            {
                // Generic error.
                return Error();
            }
        }

        public async Task<IActionResult> TryPost(string dataOperation, object value)
        {
            try
            {
                var model = await _dataHelper.PostDataAsync(dataOperation, value);
                if (model == null) return DataNull();

                // Success.
                return Success(model);
            }
            catch (Exception ex)
            {
                // Get error message if exception is one expected.
                var message = ExceptionHandling.GetErrorMessage(ex);
                
                // If there is message, return it.
                if (message != null) return Error409Conflict(message);

                // Generic error.
                return Error();
            }
        }

        public async Task<IActionResult> TryPut(string dataOperation, object value)
        {
            try
            {
                var model = await _dataHelper.PutDataAsync(dataOperation, value);
                if (model == null) return DataNull();

                // Success.
                return Success(model);
            }
            catch (Exception ex)
            {
                // Get error message if exception is one expected.
                var message = ExceptionHandling.GetErrorMessage(ex);

                // If there is message, return it.
                if (message != null) return Error409Conflict(message);

                // Generic error.
                return Error();
            }
        }

        public async Task<IActionResult> TryDelete(string dataOperation, object value)
        {
            try
            {
                var model = await _dataHelper.DeleteDataAsync(dataOperation, value);
                if (model == null) return DataNull();

                // Success.
                return Success(model);
            }
            catch
            {
                // Generic error.
                return Error();
            }
        }


        public static IActionResult DataNull()
        {
            return new JsonResult(ApiResponse.ErrorDataReturnedNull) { StatusCode = StatusCodes.Status204NoContent };
        }

        public static IActionResult Error()
        {
            return new JsonResult(ApiResponse.GenericError) { StatusCode = StatusCodes.Status500InternalServerError };
        }

        public static IActionResult Error409Conflict(string message)
        {
            return new JsonResult(ApiResponse.CustomError(message)) { StatusCode = StatusCodes.Status409Conflict };
        }

        public static IActionResult Success(object data)
        {
            return new JsonResult(data) { StatusCode = StatusCodes.Status200OK };
        }
    }
}
