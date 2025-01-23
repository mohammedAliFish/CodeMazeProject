
using Contracts.Interface;
using Entities.Models;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.CompanyName)
                .ToList();

        public Company GetCompany(Guid companyGuid, bool trackChanges) =>
            FindByCondition(c => c.CompanyGuid.Equals(companyGuid), trackChanges)
                .SingleOrDefault();
    }
}
