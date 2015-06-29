using System.Collections.Generic;

namespace EverydayToolkit.ViewModels
{
    public class ErrorResult : BaseResult<ResultType>
    {
        public IEnumerable<string> Errors { get; private set; } 

        public ErrorResult()
        {
            Result = ResultType.Error;
        }

        public ErrorResult(IEnumerable<string> errors)
        {
            Errors = errors;
        }
    }
}