using GarageInventory.Shared.Enums;

namespace GarageInventory.Core.Results
{
    public class OperationResult<TResult> where TResult : class
    {
        public TResult? Value { get; private set; }
        public bool IsSuccess { get; private set; } = false;
        public OperationResultErrors? Error { get; private set; }
        public string? ExceptionText { get; private set; }


        private OperationResult(TResult result, OperationResultErrors? error = null, string? exceptionText = null)
        {
            Value = result;
            IsSuccess = error == null;
            Error = error;
            ExceptionText = exceptionText;
        }


        public static OperationResult<TResult> Success(TResult result)
        {
            return new OperationResult<TResult>(result);
        }

        public static OperationResult<TResult> Failure(OperationResultErrors error)
        {
            return new OperationResult<TResult>(null, error);
        }

        public static OperationResult<TResult> Exception(Exception exception)
        {
            return new OperationResult<TResult>(null, OperationResultErrors.Exception, 
                $"Exception.Message - {exception.Message}. Exception.InnerException - {exception.InnerException?.Message}");
        }
    }
}
