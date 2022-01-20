using EccomerceSS.Context;
using EccomerceSS.Models;
using System;
using System.Collections.Generic;

namespace Testing
{
    public class Test
    {
        static void Main(string[] args)
        {
            using (var db = new EcommerceContext())
            {
                db.navegationBars.AddRange(new List<NavegationBar>
                {
                    new NavegationBar{
                    text = "Contact",
                    actionMethod = "Contact",
                    controllerMethod = "Home"},
                    new NavegationBar{
                    text = "About",
                    actionMethod = "About",
                    controllerMethod = "Home"},
                    new NavegationBar{
                    text = "Home",
                    actionMethod = "Index",
                    controllerMethod = "Home"},
                    new NavegationBar{
                    text = "New Products",
                    actionMethod = "Products",
                    controllerMethod = "Home"}
                });
                db.SaveChanges();

            }
        }
    }
}
