namespace EverydayToolkit.ViewModels
{
    public class SuccessResult : BaseResult<ResultType>
    {
        public object Data { get; set; }

        public SuccessResult()
        {
            Result = ResultType.Success;
        }

        public SuccessResult(object data)
        {
            Data = data;
        }
    }
}
