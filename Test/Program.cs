
using EccomerceSS.Context;
using EccomerceSS.Models;
using EccomerceSS.Repositories;
using EccomerceSS.Utilities.EmailSender;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var a = new ConfigurationBuilder().AddJsonFile("data.json", true, true);
            var b= a.Build();
            IEmailSender sender = new EmailSender(b);
            await sender.SendAsync("seba.zonta@gmail.com","test","test");
            
            
        }
    }
}
