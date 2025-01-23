﻿
namespace Entities.Exceptions
{
    public sealed class CompanyNotFoundException : NotFoundException
    {
        public CompanyNotFoundException(Guid companyId) : base($"The company with id : {companyId} doen't exist in the database") { }
    }
}
