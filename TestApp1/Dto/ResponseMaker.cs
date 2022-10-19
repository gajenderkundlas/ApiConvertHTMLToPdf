namespace TestApp1.Dto
{
    /// <summary>
    /// This class will be used to in every response 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseMaker<T>
    {
        public bool Success { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorDetails { get; set; }
        public T Data { get; set; }
    }
}
