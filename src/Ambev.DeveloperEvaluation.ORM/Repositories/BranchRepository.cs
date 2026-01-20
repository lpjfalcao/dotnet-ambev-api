using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class BranchRepository : RepositoryBase<Branch>
    {
        public BranchRepository(DefaultContext context) : base(context)
        {
            
        }
    }
}
