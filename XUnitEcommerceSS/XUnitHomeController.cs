using EccomerceSS.Context;
using EccomerceSS.Controllers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace XUnitEcommerceSS
{
    public class XUnitHomeController
    {
        private readonly EcommerceContext _context;

        public XUnitHomeController(EcommerceContext context)
        {
            _context = context;
        }
        [Fact]
        public async Task Test1()
        {
            var controller = new HomeController();
            

        }
    }
}
