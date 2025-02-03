
using Contracts.Interface;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges) => 
            await FindAll(trackChanges).OrderBy(c => c.CompanyName).ToListAsync(); 

        public async Task<Company> GetCompanyAsync(Guid companyId, bool trackChanges) =>
            await FindByCondition(c => c.CompanyGuid.Equals(companyId), trackChanges).SingleOrDefaultAsync();

        //public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
        //    FindAll(trackChanges)
        //        .OrderBy(c => c.CompanyName)
        //        .ToList();
        public async Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) => 
            await FindByCondition(x => ids.Contains(x.CompanyGuid), trackChanges).ToListAsync();
        //public Company GetCompany(Guid companyGuid, bool trackChanges) =>
        //    FindByCondition(c => c.CompanyGuid.Equals(companyGuid), trackChanges)
        //        .SingleOrDefault();


        public void CreateCompany(Company company) => Create(company);

        public void DeleteCompany(Company company) => Delete(company);

    }
}
