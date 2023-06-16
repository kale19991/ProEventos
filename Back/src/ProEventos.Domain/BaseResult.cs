using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace ProEventos.Domain
{
    public enum ErrorType
    {
        BadRequest,
        NotFound,
        Unauthorized,
        Exception,
        ValidationError,
        NotEspecified,
        NoError
    }


    public class BaseResult
    {
        public ValidationResult? ValidationResult { get; }
        public Exception? Exception { get; }
        public bool Success { get; }
        public string? ErrorMessage { get; }

        public ErrorType ErrorType { get; }

        protected BaseResult(ValidationResult? validationResult, Exception? exception, bool success, string? errorMessage, ErrorType errorType = ErrorType.NotEspecified)
        {
            ValidationResult = validationResult;
            Exception = exception;
            Success = success;
            ErrorMessage = errorMessage;
            ErrorType = success ? ErrorType.NoError : errorType;
        }

        protected BaseResult(BaseResult baseResult)
        {
            this.ErrorMessage = baseResult.ErrorMessage;
            this.Exception = baseResult.Exception;
            this.Success = baseResult.Success;
            this.ValidationResult = baseResult.ValidationResult;
            this.ErrorType = baseResult.ErrorType;

        }
    }

    public class BaseResult<T> : BaseResult // where T : class
    {
        public T? Data { get; private set; }

        public static BaseResult<T> BuildSuccesss(T data)
        {
            return new BaseResult<T>(data, null, null, true, null, ErrorType.NoError);
        }
        public static BaseResult<T> BuildFail(string errorMessage, ErrorType errorType = ErrorType.BadRequest)
        {
            return new BaseResult<T>(default(T), null, null, false, errorMessage, errorType);
        }

        public static BaseResult<T> BuildFail(Exception exception, string errorMessage, ErrorType errorType = ErrorType.Exception)
        {
            return new BaseResult<T>(default(T), null, exception, false, errorMessage, errorType);
        }

        public static BaseResult<T> BuildFail(ValidationResult? validationResult, string? errorMessage)
        {
            return new BaseResult<T>(default(T), validationResult, null, false, errorMessage, ErrorType.ValidationError);
        }


        public BaseResult(T? data) : base(null, null, true, null)
        {
            Data = data;
        }


        public BaseResult(Exception exception, string errorMessage) : base(null, exception, false, errorMessage, ErrorType.Exception)
        {
            this.Data = default(T);
        }


        public BaseResult(string? errorMessage, ErrorType errorType = ErrorType.NotEspecified) : base(null, null, false, errorMessage, errorType)
        {
            this.Data = default(T);
        }

        public BaseResult(ValidationResult validationResult, string? errorMessage) : base(validationResult, null, validationResult.IsValid, errorMessage, validationResult.IsValid ? ErrorType.NoError : ErrorType.ValidationError)
        {
            this.Data = default(T);
        }

        public BaseResult(BaseResult baseResult) : base(baseResult)
        {
            this.Data = default(T);
        }

        protected BaseResult(T? data, ValidationResult? validationResult, Exception? exception, bool success, string? errorMessage, ErrorType errorType)
            : base(validationResult, exception, success, errorMessage, errorType)
        {
            this.Data = data;
        }
    }
}