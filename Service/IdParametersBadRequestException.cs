
namespace Service
{
    [Serializable]
    internal class IdParametersBadRequestException : Exception
    {
        public IdParametersBadRequestException()
        {
        }

        public IdParametersBadRequestException(string? message) : base(message)
        {
        }

        public IdParametersBadRequestException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}