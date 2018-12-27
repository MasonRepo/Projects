using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flooring_Project.FileData;
using System.Threading.Tasks;
using System.Configuration;

namespace Flooring_Project
{
    public static class Factory
    {
        public static Services Create()
        {
           
            string Mode = ConfigurationManager.AppSettings["Mode"].ToString();
            
            switch (Mode)
            {
                case "Production":
                    return new Services(new OrderRepo(), new TaxRepo(), new ProductRepo());
                case "Test":
                    return new Services(new MockRepo(), new TaxRepo(), new ProductRepo());
                default:
                    throw new Exception("There isn't a valid Mode in the Config App!");
            }
        }
    }
}
