﻿using Entities.Models;

namespace Contracts.Interface
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllCompanies(bool trackChanges);
        Company GetCompany(Guid companyId, bool   trackChanges);

        void CreateCompany(Company company);
        void DeleteCompany(Company company);
    }
}
