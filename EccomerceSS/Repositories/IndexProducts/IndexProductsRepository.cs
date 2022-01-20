using EccomerceSS.Context;
using EccomerceSS.Models;

namespace EccomerceSS.Repositories
{
    public class IndexProductsRepository : RepositoryBase<IndexProducts>,IIndexProductsRepository
    {
        public IndexProductsRepository(EcommerceContext context) : base(context)
        {
        }
    }
}
