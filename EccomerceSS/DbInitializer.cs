

using EccomerceSS.Context;
using EccomerceSS.Models;
using System.Collections.Generic;
using System.Linq;

namespace EccomerceSS
{
    public static class DbInitializer
    {
        public static void Initialize(EcommerceContext db)
        {

            #region navegationBarInsert
            if (!db.navegationBars.Any())
            db.navegationBars.AddRange(new List<NavegationBar>
                {
                    new NavegationBar{
                    text = "Contact",
                    actionMethod = "Contact",
                    controllerMethod = "Home",
                    rolRequiredToAccess="User"},
                    new NavegationBar{
                    text = "About",
                    actionMethod = "About",
                    controllerMethod = "Home",
                    rolRequiredToAccess="User"},
                    new NavegationBar{
                    text = "Home",
                    actionMethod = "Index",
                    controllerMethod = "Home",
                    rolRequiredToAccess="User"},
                    new NavegationBar{
                    text = "New Products",
                    actionMethod = "Products",
                    controllerMethod = "Home",
                    rolRequiredToAccess="User"}
                });
            #endregion
            #region indexProductsInsert
            if(!db.indexProducts.Any())
                db.indexProducts.AddRange(new List<IndexProducts>
                {new IndexProducts
                {name="Queso Cremoso",
                description="Quedo super riquisimo",
                price=new decimal(190.6),
                photoPath="~/Media/IndexProducts/queso cremoso.jpg"},
                 new IndexProducts
                {description="madalenas valente",
                name="madalenas",
                price=new decimal(140),
                photoPath="~/Media/IndexProducts/madalenas valente.jpg"
                },
                 new IndexProducts
                {description="madalenas comunes",
                name="madalenas",
                price=new decimal(1250),
                photoPath="~/Media/IndexProducts/madalena.jpg"
                },
                 new IndexProducts
                {description="masitas pa el mate",
                name="masitas",
                price=new decimal(200),
                photoPath="~/Media/IndexProducts/masitas.jpg"
                },
                 new IndexProducts
                {description="queso para las pizzas",
                name="Queso Cremoso",
                price=new decimal(350),
                photoPath="~/Media/IndexProducts/queso cremoso.jpg"
                }
                });
            #endregion
            db.SaveChanges();
        }
    }
}
