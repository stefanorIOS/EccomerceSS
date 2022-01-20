using EccomerceSS.Context;
using EccomerceSS.Models;

namespace EccomerceSS.Repositories
{
    public class NavegationBarRepository : RepositoryBase<NavegationBar>, INavegationBarRepository
    {
        public NavegationBarRepository(EcommerceContext context) : base(context)
        {
        }
    }
}
