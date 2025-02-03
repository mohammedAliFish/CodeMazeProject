
namespace Service
{
    [Serializable]
    internal class CompanyCollectionBadRequest : Exception
    {
        public CompanyCollectionBadRequest()
        {
        }

        public CompanyCollectionBadRequest(string? message) : base(message)
        {
        }

        public CompanyCollectionBadRequest(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}