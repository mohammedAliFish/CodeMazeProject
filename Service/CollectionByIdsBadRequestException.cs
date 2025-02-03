
namespace Service
{
    [Serializable]
    internal class CollectionByIdsBadRequestException : Exception
    {
        public CollectionByIdsBadRequestException()
        {
        }

        public CollectionByIdsBadRequestException(string? message) : base(message)
        {
        }

        public CollectionByIdsBadRequestException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}