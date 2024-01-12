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
                var data = await _dataHelper.GetDataAsync(dataOperation, value);
                if (data == null) return DataIsNull();

                // Success.
                return Success(data);
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
                if (model == null) return DataIsNull();

                // Success.
                return Success(model);
            }
            catch (Exception ex)
            {
                // Get custom error message, if exception is one expected.
                var message = ExceptionHandling.GetCustomErrorMessage(ex);
                
                // If there is a custom message, return it.
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
                if (model == null) return DataIsNull();

                // Success.
                return Success(model);
            }
            catch (Exception ex)
            {
                // Get error message if exception is one expected.
                var message = ExceptionHandling.GetCustomErrorMessage(ex);

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
                if (model == null) return DataIsNull();

                // Success.
                return Success(model);
            }
            catch (Exception ex)
            {
                // Get error message if exception is one expected.
                var message = ExceptionHandling.GetCustomErrorMessage(ex);

                // If there is message, return it.
                if (message != null) return Error409Conflict(message);

                // Generic error.
                return Error();
            }
        }


        #region Prepared <private> controller responses

        private static IActionResult DataIsNull()
        {
            return new JsonResult(ApiResponse.DataReturnedNull) { StatusCode = StatusCodes.Status204NoContent };
        }

        private static IActionResult Error()
        {
            return new JsonResult(ApiResponse.GenericError) { StatusCode = StatusCodes.Status500InternalServerError };
        }

        private static IActionResult Error409Conflict(string message)
        {
            return new JsonResult(ApiResponse.CustomError(message)) { StatusCode = StatusCodes.Status409Conflict };
        }

        private static IActionResult Success(object data)
        {
            return new JsonResult(data) { StatusCode = StatusCodes.Status200OK };
        }

        #endregion Prepared controller responses
    }
}
